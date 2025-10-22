using Microsoft.AspNetCore.Mvc;
using STRANDVENTURE.Models;
using STRANDVENTURE.Services;
using STRANDVENTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace STRANDVENTURE.Controllers
{
    public class StudentReportsController : Controller
    {
        private readonly ILogger<StudentReportsController> _logger;
        private readonly IEmployeeService _employeeService;
        private readonly ApplicationDbContext _db; // still used for some aggregate queries (results/strands)
        private readonly ISectionService _sectionService;
        private readonly ISectionStudentService _sectionStudentService;
        private readonly IStudentService _studentService;
        private readonly IStudentAssessmentAttemptService _attemptService;

        public StudentReportsController(
            ILogger<StudentReportsController> logger,
            IEmployeeService employeeService,
            ApplicationDbContext db,
            ISectionService sectionService,
            ISectionStudentService sectionStudentService,
            IStudentService studentService,
            IStudentAssessmentAttemptService attemptService)
        {
            _logger = logger;
            _employeeService = employeeService;
            _db = db;
            _sectionService = sectionService;
            _sectionStudentService = sectionStudentService;
            _studentService = studentService;
            _attemptService = attemptService;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("UserRole") != "Teacher" && HttpContext.Session.GetString("UserRole") != "SuperAdmin")
                return RedirectToAction("TeacherLogin", "Home");

            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrWhiteSpace(email))
                return RedirectToAction("TeacherLogin", "Home");

            var employee = await _employeeService.GetByEmailAsync(email);
            if (employee is null)
                return RedirectToAction("TeacherLogin", "Home");

            ViewData["PortalTitle"] = "Teacher Portal";
            ViewData["DisplayName"] = employee.Name;

            var vm = new TeacherPortalViewModel { Employee = employee };
            return View(vm);
        }

        // Returns completion stats for the teacher's students, optionally filtered by section
        [HttpGet]
        public async Task<IActionResult> CompletionStats(Guid? sectionId, CancellationToken ct)
        {
            if (HttpContext.Session.GetString("UserRole") != "Teacher" && HttpContext.Session.GetString("UserRole") != "SuperAdmin")
                return Unauthorized();

            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrWhiteSpace(email))
                return Unauthorized();

            var employee = await _employeeService.GetByEmailAsync(email);
            if (employee is null)
                return Unauthorized();

            // For super admin, use all active sections
            var sections = await _sectionService.ListActiveAsync(ct);
            var sectionIds = sections.Select(s => s.Id).ToList();
            if (sectionId.HasValue && sectionId.Value != Guid.Empty)
                sectionIds = sectionIds.Where(id => id == sectionId.Value).ToList();

            if (sectionIds.Count == 0)
                return Ok(new { data = new { totalStudents = 0, completedStudents = 0, percent = 0m } });

            // All active student links under these sections
            var studentIds = new HashSet<Guid>();
            foreach (var sid in sectionIds)
            {
                var links = await _sectionStudentService.ListBySectionAsync(sid, ct);
                foreach (var l in links.Where(l => l.IsActive)) studentIds.Add(l.StudentId);
            }

            var total = studentIds.Count;
            if (total == 0)
                return Ok(new { data = new { totalStudents = 0, completedStudents = 0, percent = 0m } });

            // CHANGE: Use honored results table (one per completed student) instead of attempts
            var completedCount = await _db.StudentAssessmentResults
                .AsNoTracking()
                .Where(r => studentIds.Contains(r.StudentId))
                .Select(r => r.StudentId)
                .Distinct()
                .CountAsync(ct);

            var percent = total == 0 ? 0m : Math.Round((decimal)completedCount * 100m / (decimal)total, 2);

            return Ok(new { data = new { totalStudents = total, completedStudents = completedCount, percent } });
        }

        // Pie chart data now also returns colors from Strand.Color
        [HttpGet]
        public async Task<IActionResult> StrandDistribution(Guid? sectionId, CancellationToken ct)
        {
            if (HttpContext.Session.GetString("UserRole") != "Teacher" && HttpContext.Session.GetString("UserRole") != "SuperAdmin")
                return Unauthorized();

            var auth = await EnsureTeacherAsync(sectionId, ct);
            if (auth is null) return Unauthorized();
            var (_, _, studentIds) = auth.Value;

            if (studentIds.Count == 0)
                return Ok(new { labels = Array.Empty<string>(), values = Array.Empty<int>(), colors = Array.Empty<string>() });

            // Get counts of results by recommended strand (excluding null recommendations)
            var rawCounts = await _db.StudentAssessmentResults
                .AsNoTracking()
                .Where(r => studentIds.Contains(r.StudentId) && r.RecommendedStrandId != null)
                .GroupBy(r => r.RecommendedStrandId)
                .Select(g => new { StrandId = g.Key!.Value, Count = g.Count() })
                .ToListAsync(ct);

            if (rawCounts.Count == 0)
                return Ok(new { labels = Array.Empty<string>(), values = Array.Empty<int>(), colors = Array.Empty<string>() });

            // Load strands once (names + colors)
            var strandData = await _db.Strands.AsNoTracking().ToDictionaryAsync(s => s.Id, s => new { s.Name, s.Color }, ct);

            var ordered = rawCounts.OrderByDescending(x => x.Count).ToList();
            var labels = new List<string>();
            var values = new List<int>();
            var colors = new List<string>();
            foreach (var rc in ordered)
            {
                if (strandData.TryGetValue(rc.StrandId, out var info))
                {
                    labels.Add(info.Name);
                    values.Add(rc.Count);
                    // Ensure a valid css color (fallback black)
                    var col = string.IsNullOrWhiteSpace(info.Color) ? "#000000" : info.Color.Trim();
                    colors.Add(col);
                }
            }

            return Ok(new { labels, values, colors });
        }

        // Recent activity: students who have completed an assessment (newest first) via results instead of attempts
        [HttpGet]
        public async Task<IActionResult> RecentActivity(Guid? sectionId, int take = 10, CancellationToken ct = default)
        {
            if (HttpContext.Session.GetString("UserRole") != "Teacher" && HttpContext.Session.GetString("UserRole") != "SuperAdmin")
                return Unauthorized();

            var auth = await EnsureTeacherAsync(sectionId, ct);
            if (auth is null) return Unauthorized();
            var (_, sectionIds, studentIds) = auth.Value;

            if (studentIds.Count == 0)
                return Ok(new { data = Array.Empty<object>() });

            // Pull recent honored results for these students
            var results = await _db.StudentAssessmentResults
                .AsNoTracking()
                .Where(r => studentIds.Contains(r.StudentId))
                .OrderByDescending(r => r.FinalizedAt)
                .Take(take)
                .Select(r => new { r.StudentId, r.FinalizedAt })
                .ToListAsync(ct);

            if (results.Count == 0)
                return Ok(new { data = Array.Empty<object>() });

            var resultStudentIds = results.Select(r => r.StudentId).Distinct().ToList();

            // Build section enrollment mapping using section-student service
            var sectionLinks = new List<SectionStudent>();
            foreach (var sid in sectionIds)
            {
                var links = await _sectionStudentService.ListBySectionAsync(sid, ct);
                sectionLinks.AddRange(links.Where(l => l.IsActive && resultStudentIds.Contains(l.StudentId)));
            }

            var sectionByStudent = sectionLinks
                .GroupBy(l => l.StudentId)
                .Select(g => g.OrderByDescending(x => x.EnrolledAt).First())
                .ToDictionary(x => x.StudentId, x => x.SectionId);

            // Section names
            var sections = await _sectionService.ListActiveAsync(ct);
            var sectionNameMap = sections.Where(s => sectionIds.Contains(s.Id)).ToDictionary(s => s.Id, s => s.Name);

            // Student names
            var allStudents = await _studentService.ListAllAsync(ct);
            var nameMap = allStudents.Where(s => resultStudentIds.Contains(s.Id)).ToDictionary(s => s.Id, s => s.Name);

            var data = results
                .OrderByDescending(r => r.FinalizedAt)
                .Select(r => new
                {
                    studentId = r.StudentId,
                    name = nameMap.TryGetValue(r.StudentId, out var n) ? n : string.Empty,
                    sectionName = (sectionByStudent.TryGetValue(r.StudentId, out var secId) && sectionNameMap.TryGetValue(secId, out var sn)) ? sn : string.Empty,
                    completedAt = r.FinalizedAt
                });

            return Ok(new { data });
        }

        // Strand breakdown with counts and percent per strand (keep real impl for now)
        [HttpGet]
        public async Task<IActionResult> StrandBreakdown(Guid? sectionId, CancellationToken ct)
        {
            var auth = await EnsureTeacherAsync(sectionId, ct);
            if (auth is null) return Unauthorized();
            var (_, _, studentIds) = auth.Value;

            var strands = await _db.Strands.AsNoTracking().OrderBy(s => s.Name).ToListAsync(ct);
            if (studentIds.Count == 0)
            {
                var empty = strands.Select(s => new { strandId = s.Id, strandName = s.Name, count = 0, percent = 0m, color = s.Color });
                return Ok(new { data = empty, total = 0 });
            }

            var resultCounts = await _db.StudentAssessmentResults
                .AsNoTracking()
                .Where(r => studentIds.Contains(r.StudentId))
                .GroupBy(r => r.RecommendedStrandId)
                .Select(g => new { StrandId = g.Key, Count = g.Count() })
                .ToListAsync(ct);

            var countMap = resultCounts.ToDictionary(x => x.StrandId, x => x.Count);
            var total = resultCounts.Sum(x => x.Count);
            if (total == 0)
            {
                var empty = strands.Select(s => new { strandId = s.Id, strandName = s.Name, count = 0, percent = 0m, color = s.Color });
                return Ok(new { data = empty, total = 0 });
            }

            var data = strands.Select(s => new
            {
                strandId = s.Id,
                strandName = s.Name,
                count = countMap.TryGetValue(s.Id, out var c) ? c : 0,
                percent = Math.Round(((decimal)(countMap.TryGetValue(s.Id, out var cc) ? cc : 0) * 100m) / total, 2),
                color = s.Color
            });

            return Ok(new { data, total });
        }

        // NEW: List students who have not yet completed their assessment (no result record)
        [HttpGet]
        public async Task<IActionResult> IncompleteStudents(Guid? sectionId, CancellationToken ct)
        {
            var auth = await EnsureTeacherAsync(sectionId, ct);
            if (auth is null) return Unauthorized();
            var (employee, sectionIds, studentIds) = auth.Value;

            if (studentIds.Count == 0)
                return Ok(new { data = Array.Empty<object>() });

            // Distinct students with results (completed)
            var completedIds = await _db.StudentAssessmentResults
                .AsNoTracking()
                .Where(r => studentIds.Contains(r.StudentId))
                .Select(r => r.StudentId)
                .Distinct()
                .ToListAsync(ct);
            var completedSet = new HashSet<Guid>(completedIds);

            var incompleteIds = studentIds.Where(id => !completedSet.Contains(id)).ToList();
            if (incompleteIds.Count == 0)
                return Ok(new { data = Array.Empty<object>() });

            // Section enrollment mapping for incomplete students
            var sectionLinks = new List<SectionStudent>();
            foreach (var sid in sectionIds)
            {
                var links = await _sectionStudentService.ListBySectionAsync(sid, ct);
                sectionLinks.AddRange(links.Where(l => l.IsActive && incompleteIds.Contains(l.StudentId)));
            }

            var latestSectionPerStudent = sectionLinks
                .GroupBy(l => l.StudentId)
                .Select(g => g.OrderByDescending(x => x.EnrolledAt).First())
                .ToDictionary(x => x.StudentId, x => x.SectionId);

            var sections = await _sectionService.ListActiveAsync(ct);
            var sectionNameMap = sections.Where(s => sectionIds.Contains(s.Id)).ToDictionary(s => s.Id, s => s.Name);

            // Student names
            var allStudents = await _studentService.ListAllAsync(ct);
            var studentMap = allStudents.Where(s => incompleteIds.Contains(s.Id)).ToDictionary(s => s.Id, s => s.Name);

            var data = incompleteIds
                .Select(id => new
                {
                    studentId = id,
                    name = studentMap.TryGetValue(id, out var n) ? n : string.Empty,
                    sectionName = (latestSectionPerStudent.TryGetValue(id, out var secId) && sectionNameMap.TryGetValue(secId, out var sn)) ? sn : string.Empty
                })
                .OrderBy(x => x.sectionName).ThenBy(x => x.name);

            return Ok(new { data });
        }

        // NEW: Teacher triggers notification for a given student (id) - creates record if not exists
        [HttpPost]
        public async Task<IActionResult> NotifyStudent(Guid studentId, CancellationToken ct)
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "Teacher" && role != "SuperAdmin") return Unauthorized();
            if (studentId == Guid.Empty) return BadRequest(new { ok = false, message = "Invalid student" });

            try
            {
                var exists = await _db.StudentNotifyAssessments.AsNoTracking().AnyAsync(n => n.StudentId == studentId, ct);
                if (exists)
                    return Ok(new { ok = true, created = false });

                _db.StudentNotifyAssessments.Add(new StudentNotifyAssessment { StudentId = studentId });
                await _db.SaveChangesAsync(ct);
                return Ok(new { ok = true, created = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "NotifyStudent failed for {StudentId}", studentId);
                return StatusCode(500, new { ok = false, message = "Error" });
            }
        }

        // Helper to get teacher + section + student scope (still partly uses db for performance)
        private async Task<(Employee Employee, List<Guid> SectionIds, List<Guid> StudentIds)?> EnsureTeacherAsync(Guid? sectionId = null, CancellationToken ct = default)
        {
            if (HttpContext.Session.GetString("UserRole") != "Teacher" && HttpContext.Session.GetString("UserRole") != "SuperAdmin")
                return null;

            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrWhiteSpace(email))
                return null;

            var employee = await _employeeService.GetByEmailAsync(email);
            if (employee is null)
                return null;

            // For super admin, use all active sections
            var sections = await _sectionService.ListActiveAsync(ct);
            var activeSectionIds = sections.Select(s => s.Id).ToList();
            if (sectionId.HasValue && sectionId.Value != Guid.Empty)
                activeSectionIds = activeSectionIds.Where(id => id == sectionId.Value).ToList();

            var studentIds = new HashSet<Guid>();
            foreach (var sid in activeSectionIds)
            {
                var links = await _sectionStudentService.ListBySectionAsync(sid, ct);
                foreach (var l in links.Where(l => l.IsActive)) studentIds.Add(l.StudentId);
            }

            return (employee, activeSectionIds, studentIds.ToList());
        }
    }
}
