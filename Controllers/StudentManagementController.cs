using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STRANDVENTURE.Data;
using STRANDVENTURE.Models;
using STRANDVENTURE.Security;
using STRANDVENTURE.Services;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace STRANDVENTURE.Controllers
{
    public class StudentManagementController : Controller
    {
        private readonly ILogger<StudentManagementController> _logger;
        private readonly IEmployeeService _employeeService;
        private readonly IStudentService _studentService;
        private readonly ISectionService _sectionService;
        private readonly ISectionStudentService _sectionStudentService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ApplicationDbContext _db;

        public StudentManagementController(
            ILogger<StudentManagementController> logger,
            IEmployeeService employeeService,
            IStudentService studentService,
            ISectionService sectionService,
            ISectionStudentService sectionStudentService,
            IPasswordHasher passwordHasher,
            ApplicationDbContext db)
        {
            _logger = logger;
            _employeeService = employeeService;
            _db = db;
            _studentService = studentService;
            _sectionService = sectionService;
            _sectionStudentService = sectionStudentService;
            _passwordHasher = passwordHasher;
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

        // Returns students for DataTables (ajax) filtered by logged-in teacher's sections (service-based)
        [HttpGet]
        public async Task<IActionResult> ListStudents(CancellationToken ct)
        {
            if (HttpContext.Session.GetString("UserRole") != "Teacher" && HttpContext.Session.GetString("UserRole") != "SuperAdmin")
                return Unauthorized();

            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrWhiteSpace(email))
                return Unauthorized();

            var employee = await _employeeService.GetByEmailAsync(email);
            if (employee is null)
                return Unauthorized();

            // Get all active sections for super admin
            var sections = await _sectionService.ListActiveAsync(ct);
            var activeSections = sections.ToList();
            var sectionsById = activeSections.ToDictionary(s => s.Id, s => s);

            // Gather all section-student links under those sections (service)
            var links = new List<SectionStudent>();
            foreach (var sec in activeSections)
            {
                var secLinks = await _sectionStudentService.ListBySectionAsync(sec.Id, ct);
                links.AddRange(secLinks.Where(l => l.IsActive));
            }

            // Load students via service and join in-memory
            var allStudents = await _studentService.ListAllAsync(ct);
            var studentById = allStudents.ToDictionary(s => s.Id, s => s);

            // Preload assessment completion status
            var linkedStudentIds = links.Select(l => l.StudentId).Distinct().ToList();
            var completedStudentIds = await _db.StudentAssessmentResults
                .Where(r => linkedStudentIds.Contains(r.StudentId))
                .Select(r => r.StudentId)
                .ToListAsync(ct);
            var completedSet = completedStudentIds.ToHashSet();

            // Pick latest enrollment per student
            var latest = links
                .GroupBy(l => l.StudentId)
                .Select(g => g.OrderByDescending(x => x.EnrolledAt).First())
                .Select(l =>
                {
                    studentById.TryGetValue(l.StudentId, out var stu);
                    sectionsById.TryGetValue(l.SectionId, out var sec);
                    return new
                    {
                        id = stu?.Id ?? Guid.Empty,
                        name = stu?.Name ?? string.Empty,
                        lrn = stu?.LRN ?? string.Empty,
                        sectionId = sec?.Id ?? Guid.Empty,
                        sectionName = sec?.Name ?? string.Empty,
                        birthday = stu?.Birthday ?? DateTime.MinValue,
                        assessmentStatus = completedSet.Contains(l.StudentId) ? "Completed" : "Pending"
                    };
                })
                .Where(x => x.id != Guid.Empty && studentById[x.id].IsActive)
                .ToList();

            return Json(new { data = latest });
        }

        // NEW: Strand scores per student for pie chart
        [HttpGet]
        public async Task<IActionResult> StudentStrandScores(Guid studentId, CancellationToken ct)
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "Teacher" && role != "SuperAdmin")
                return Unauthorized();

            if (studentId == Guid.Empty)
                return BadRequest(new { message = "studentId required." });

            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrWhiteSpace(email))
                return Unauthorized();

            var employee = await _employeeService.GetByEmailAsync(email);
            if (employee is null)
                return Unauthorized();

            var isSuperAdmin = role == "SuperAdmin";

            // Must exist and be active
            var student = await _db.Students.FirstOrDefaultAsync(s => s.Id == studentId && s.IsActive, ct);
            if (student is null) return NotFound(new { message = "Student not found." });

            // For super admin, skip teacher section check

            // Get honored result (if any)
            var result = await _db.StudentAssessmentResults.AsNoTracking().FirstOrDefaultAsync(r => r.StudentId == studentId, ct);
            if (result is null)
                return Ok(new { data = Array.Empty<object>() });

            var scores = await _db.StudentAssessmentStrandScores
                .Where(s => s.AttemptId == result.AttemptId)
                .Include(s => s.Strand)
                .OrderBy(s => s.Strand.Name)
                .Select(s => new { strand = s.Strand.Name, percent = s.ScorePercent })
                .ToListAsync(ct);

            return Json(new { data = scores });
        }

        // Returns all active sections under the logged-in teacher for dropdowns (service-based)
        [HttpGet]
        public async Task<IActionResult> TeacherSections(CancellationToken ct)
        {
            if (HttpContext.Session.GetString("UserRole") != "Teacher" && HttpContext.Session.GetString("UserRole") != "SuperAdmin")
                return Unauthorized();

            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrWhiteSpace(email))
                return Unauthorized();

            var employee = await _employeeService.GetByEmailAsync(email);
            if (employee is null)
                return Unauthorized();

            var sections = await _sectionService.ListActiveAsync(ct);
            var result = sections
                .OrderBy(s => s.Name)
                .Select(s => new { id = s.Id, name = s.Name })
                .ToList();

            return Json(new { data = result });
        }

        public sealed class CreateStudentRequest
        {
            public string LRN { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
            public DateTime Birthday { get; set; }
            public Guid SectionId { get; set; }
        }

        // Create student and enroll to selected section (service-based)
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentRequest req, CancellationToken ct)
        {
            if (HttpContext.Session.GetString("UserRole") != "Teacher" && HttpContext.Session.GetString("UserRole") != "SuperAdmin")
                return Unauthorized();

            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrWhiteSpace(email))
                return Unauthorized();

            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(req.LRN) || string.IsNullOrWhiteSpace(req.Name) || req.SectionId == Guid.Empty)
                return BadRequest(new { message = "Invalid payload." });

            var employee = await _employeeService.GetByEmailAsync(email);
            if (employee is null)
                return Unauthorized();

            // LRN must be unique
            var existing = await _studentService.GetByLRNAsync(req.LRN.Trim(), ct);
            if (existing is not null)
                return Conflict(new { message = "LRN already exists." });

            // Section must be active
            var section = await _sectionService.GetByIdAsync(req.SectionId, ct);
            if (section is null || !section.IsActive)
                return Unauthorized();

            // Create student via service
            var student = new Student
            {
                LRN = req.LRN.Trim(),
                Name = req.Name.Trim(),
                Birthday = req.Birthday.Date,
                PasswordHash = _passwordHasher.Hash("Student@123"),
                IsActive = true
            };
            student = await _studentService.CreateAsync(student, ct);

            // Link to section via service
            var link = new SectionStudent
            {
                SectionId = section.Id,
                StudentId = student.Id,
                IsActive = true
            };
            await _sectionStudentService.CreateAsync(link, ct);

            return Ok(new { success = true, id = student.Id });
        }

        public sealed class UpdateStudentRequest
        {
            public Guid Id { get; set; }
            public string LRN { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
            public DateTime Birthday { get; set; }
            public Guid SectionId { get; set; }
        }

        // Update student details and re-enroll to a section if needed (service-based)
        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentRequest req, CancellationToken ct)
        {
            if (HttpContext.Session.GetString("UserRole") != "Teacher" && HttpContext.Session.GetString("UserRole") != "SuperAdmin")
                return Unauthorized();

            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrWhiteSpace(email))
                return Unauthorized();

            if (req.Id == Guid.Empty || string.IsNullOrWhiteSpace(req.LRN) || string.IsNullOrWhiteSpace(req.Name) || req.SectionId == Guid.Empty)
                return BadRequest(new { message = "Invalid payload." });

            var employee = await _employeeService.GetByEmailAsync(email);
            if (employee is null)
                return Unauthorized();

            var isSuperAdmin = HttpContext.Session.GetString("UserRole") == "SuperAdmin";

            // Load student
            var student = await _db.Students.FirstOrDefaultAsync(s => s.Id == req.Id, ct);
            if (student is null || !student.IsActive)
                return NotFound(new { message = "Student not found." });

            // For non-admins, ensure the teacher can manage this student (has an active link under teacher sections)
            // For super admin, skip teacher section check

            // LRN uniqueness (allow same student)
            var lrnTrim = req.LRN.Trim();
            var lrnOwner = await _db.Students.FirstOrDefaultAsync(s => s.LRN == lrnTrim, ct);
            if (lrnOwner is not null && lrnOwner.Id != student.Id)
                return Conflict(new { message = "LRN already exists." });

            // Validate section target
            var targetSection = await _sectionService.GetByIdAsync(req.SectionId, ct);
            if (targetSection is null || !targetSection.IsActive)
                return Unauthorized();

            // Update student fields
            student.LRN = lrnTrim;
            student.Name = req.Name.Trim();
            student.Birthday = req.Birthday.Date;
            await _studentService.UpdateAsync(student, ct);

            // Update section enrollment:
            // - For non-admin: only modify links under the teacher's sections
            // - For admin: modify all links
            var allLinks = await _sectionStudentService.ListByStudentAsync(student.Id, ct);

            foreach (var link in allLinks.Where(l => l.IsActive && l.SectionId != req.SectionId))
            {
                link.IsActive = false;
                await _sectionStudentService.UpdateAsync(link, ct);
            }

            var targetLink = allLinks.FirstOrDefault(l => l.SectionId == req.SectionId);
            if (targetLink is null)
            {
                await _sectionStudentService.CreateAsync(new SectionStudent
                {
                    SectionId = req.SectionId,
                    StudentId = student.Id,
                    IsActive = true
                }, ct);
            }
            else if (!targetLink.IsActive)
            {
                targetLink.IsActive = true;
                await _sectionStudentService.UpdateAsync(targetLink, ct);
            }

            return Ok(new { success = true });
        }

        // -------- NEW: RETAKE ASSESSMENT (delete result record) --------
        public sealed class RetakeAssessmentRequest { public Guid StudentId { get; set; } }

        [HttpPost]
        public async Task<IActionResult> RetakeAssessment([FromBody] RetakeAssessmentRequest req, CancellationToken ct)
        {
            if (HttpContext.Session.GetString("UserRole") != "Teacher" && HttpContext.Session.GetString("UserRole") != "SuperAdmin")
                return Unauthorized();

            if (req.StudentId == Guid.Empty)
                return BadRequest(new { message = "StudentId required." });

            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrWhiteSpace(email))
                return Unauthorized();

            var employee = await _employeeService.GetByEmailAsync(email);
            if (employee is null)
                return Unauthorized();

            var isSuperAdmin = HttpContext.Session.GetString("UserRole") == "SuperAdmin";

            var student = await _db.Students.FirstOrDefaultAsync(s => s.Id == req.StudentId, ct);
            if (student is null || !student.IsActive)
                return NotFound(new { message = "Student not found." });

            // For super admin, skip teacher section check

            // Load honored result
            var result = await _db.StudentAssessmentResults.AsNoTracking().FirstOrDefaultAsync(r => r.StudentId == student.Id, ct);
            if (result is null)
                return NotFound(new { message = "No assessment result to remove." });

            // We want to fully reset: delete the attempt and all cascading data (answers, strand scores, achievements, result)
            // Remove attempt (cascade will delete result + dependents per model configuration)
            using var tx = await _db.Database.BeginTransactionAsync(ct);
            try
            {
                var attempt = await _db.StudentAssessmentAttempts.FirstOrDefaultAsync(a => a.Id == result.AttemptId, ct);
                if (attempt != null)
                {
                    _db.StudentAssessmentAttempts.Remove(attempt); // cascades to result, answers, strand scores, achievements
                }
                else
                {
                    // Fallback: if attempt missing (data inconsistency), remove result directly
                    var staleResult = await _db.StudentAssessmentResults.FirstOrDefaultAsync(r => r.Id == result.Id, ct);
                    if (staleResult != null) _db.StudentAssessmentResults.Remove(staleResult);
                }
                await _db.SaveChangesAsync(ct);
                await tx.CommitAsync(ct);
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                await tx.RollbackAsync(ct);
                _logger.LogError(ex, "Failed to reset assessment for student {StudentId}", student.Id);
                return StatusCode(500, new { message = "Failed to reset assessment." });
            }
        }

        // -------- NEW: DELETE STUDENT (hard delete + related assessment data) --------
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(Guid id, CancellationToken ct)
        {
            if (HttpContext.Session.GetString("UserRole") != "Teacher" && HttpContext.Session.GetString("UserRole") != "SuperAdmin")
                return Unauthorized();
            if (id == Guid.Empty) return BadRequest(new { message = "Id required." });

            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrWhiteSpace(email))
                return Unauthorized();

            var employee = await _employeeService.GetByEmailAsync(email);
            if (employee is null) return Unauthorized();
            var isSuperAdmin = HttpContext.Session.GetString("UserRole") == "SuperAdmin";

            var student = await _db.Students.FirstOrDefaultAsync(s => s.Id == id, ct);
            if (student is null) return NotFound(new { message = "Student not found." });

            // For super admin, skip teacher section check

            using var tx = await _db.Database.BeginTransactionAsync(ct);
            try
            {
                // Collect attempt IDs (if any)
                var attemptIds = await _db.StudentAssessmentAttempts
                    .Where(a => a.StudentId == id)
                    .Select(a => a.Id)
                    .ToListAsync(ct);

                if (attemptIds.Count > 0)
                {
                    // Dependent: achievements, answers, strand scores, results (some may cascade but be explicit for clarity)
                    await _db.StudentAssessmentAchievements
                        .Where(a => attemptIds.Contains(a.AttemptId))
                        .ExecuteDeleteAsync(ct);
                    await _db.StudentAssessmentAnswers
                        .Where(a => attemptIds.Contains(a.AttemptId))
                        .ExecuteDeleteAsync(ct);
                    await _db.StudentAssessmentStrandScores
                        .Where(s => attemptIds.Contains(s.AttemptId))
                        .ExecuteDeleteAsync(ct);
                    await _db.StudentAssessmentResults
                        .Where(r => r.StudentId == id || attemptIds.Contains(r.AttemptId))
                        .ExecuteDeleteAsync(ct);
                    await _db.StudentAssessmentAttempts
                        .Where(a => attemptIds.Contains(a.Id))
                        .ExecuteDeleteAsync(ct);
                }

                // Section links
                await _db.SectionStudents.Where(ss => ss.StudentId == id).ExecuteDeleteAsync(ct);

                // Finally student
                _db.Students.Remove(student);
                await _db.SaveChangesAsync(ct);

                await tx.CommitAsync(ct);
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                await tx.RollbackAsync(ct);
                _logger.LogError(ex, "Failed to delete student {StudentId}", id);
                return StatusCode(500, new { message = "Delete failed." });
            }
        }

        // -------- BULK UPLOAD --------
        public sealed class BulkUploadReport
        {
            public int Created { get; set; }
            public int DuplicateLRN { get; set; }
            public int DuplicateName { get; set; }
            public int InvalidRows { get; set; }
            public List<string> Errors { get; set; } = new();
        }

        [HttpGet]
        public IActionResult BulkUploadTemplate()
        {
            var csv = "LRN,Name,Birthday\n123456789012,Juan Dela Cruz,2008-05-21\n";
            return File(Encoding.UTF8.GetBytes(csv), "text/csv", "students_template.csv");
        }

        [HttpPost]
        [RequestSizeLimit(5_000_000)]
        public async Task<IActionResult> BulkUploadStudents(IFormFile? file, Guid sectionId, CancellationToken ct)
        {
            if (HttpContext.Session.GetString("UserRole") != "Teacher" && HttpContext.Session.GetString("UserRole") != "SuperAdmin")
                return Unauthorized();

            if (file == null || file.Length == 0)
                return BadRequest(new { message = "No file uploaded." });

            if (sectionId == Guid.Empty)
                return BadRequest(new { message = "Section is required." });

            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrWhiteSpace(email))
                return Unauthorized();

            var employee = await _employeeService.GetByEmailAsync(email);
            if (employee is null)
                return Unauthorized();

            var section = await _sectionService.GetByIdAsync(sectionId, ct);
            if (section is null || !section.IsActive)
                return Unauthorized();

            var report = new BulkUploadReport();

            try
            {
                using var stream = file.OpenReadStream();
                using var reader = new StreamReader(stream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true);

                string? headerLine = await reader.ReadLineAsync();
                if (headerLine is null)
                    return BadRequest(new { message = "Empty file." });

                var headers = headerLine.Split(',', StringSplitOptions.TrimEntries);
                int idxLRN = Array.FindIndex(headers, h => string.Equals(h, "LRN", StringComparison.OrdinalIgnoreCase));
                int idxName = Array.FindIndex(headers, h => string.Equals(h, "Name", StringComparison.OrdinalIgnoreCase));
                int idxBirthday = Array.FindIndex(headers, h => string.Equals(h, "Birthday", StringComparison.OrdinalIgnoreCase));

                if (idxLRN < 0 || idxName < 0 || idxBirthday < 0)
                    return BadRequest(new { message = "Headers must include: LRN, Name, Birthday." });

                var existing = await _studentService.ListAllAsync(ct);
                var existingLRNs = existing.Where(s => s.IsActive)
                    .Select(s => (s.LRN ?? string.Empty).Trim())
                    .ToHashSet(StringComparer.OrdinalIgnoreCase);
                var existingNames = existing.Where(s => s.IsActive)
                    .Select(s => (s.Name ?? string.Empty).Trim())
                    .ToHashSet(StringComparer.OrdinalIgnoreCase);

                // Track duplicates within the same upload file
                var batchSeenLRNs = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                var batchSeenNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                using var tx = await _db.Database.BeginTransactionAsync(ct);

                int lineNumber = 1;
                while (!reader.EndOfStream)
                {
                    lineNumber++;
                    var line = await reader.ReadLineAsync();
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    var cols = SplitCsv(line);
                    if (cols.Length <= Math.Max(idxBirthday, Math.Max(idxLRN, idxName)))
                    {
                        report.InvalidRows++;
                        report.Errors.Add($"Line {lineNumber}: Not enough columns.");
                        continue;
                    }

                    var lrn = (cols[idxLRN] ?? string.Empty).Trim();
                    var name = (cols[idxName] ?? string.Empty).Trim();
                    var birthdayRaw = (cols[idxBirthday] ?? string.Empty).Trim();

                    // Required checks (LRN and Name must be present)
                    if (string.IsNullOrWhiteSpace(lrn))
                    {
                        report.InvalidRows++;
                        report.Errors.Add($"Line {lineNumber}: LRN is required.");
                        continue;
                    }
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        report.InvalidRows++;
                        report.Errors.Add($"Line {lineNumber}: Name is required.");
                        continue;
                    }

                    // LRN format
                    if (lrn.Length != 12 || !lrn.All(char.IsDigit))
                    {
                        report.InvalidRows++;
                        report.Errors.Add($"Line {lineNumber}: LRN must be exactly 12 digits.");
                        continue;
                    }

                    // Uniqueness: LRN (DB + within file)
                    if (existingLRNs.Contains(lrn) || batchSeenLRNs.Contains(lrn))
                    {
                        report.DuplicateLRN++;
                        report.Errors.Add($"Line {lineNumber}: Duplicate LRN '{lrn}'.");
                        continue;
                    }

                    // Uniqueness: Name (DB + within file)
                    if (existingNames.Contains(name) || batchSeenNames.Contains(name))
                    {
                        report.DuplicateName++;
                        report.Errors.Add($"Line {lineNumber}: Duplicate Name '{name}'.");
                        continue;
                    }

                    // Birthday parse
                    if (!TryParseBirthday(birthdayRaw, out var birthday))
                    {
                        report.InvalidRows++;
                        report.Errors.Add($"Line {lineNumber}: Invalid Birthday '{birthdayRaw}'.");
                        continue;
                    }

                    // Create student
                    var student = new Student
                    {
                        LRN = lrn,
                        Name = name,
                        Birthday = birthday,
                        PasswordHash = _passwordHasher.Hash("Student@123"),
                        IsActive = true
                    };
                    student = await _studentService.CreateAsync(student, ct);

                    await _sectionStudentService.CreateAsync(new SectionStudent
                    {
                        SectionId = section.Id,
                        StudentId = student.Id,
                        IsActive = true
                    }, ct);

                    // Update seen sets (so subsequent rows are checked against newly added)
                    existingLRNs.Add(lrn);
                    existingNames.Add(name);
                    batchSeenLRNs.Add(lrn);
                    batchSeenNames.Add(name);

                    report.Created++;
                }

                await _db.SaveChangesAsync(ct);
                await tx.CommitAsync(ct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Bulk upload failed.");
                return StatusCode(500, new { message = "Bulk upload failed." });
            }

            return Ok(new { success = true, report });
        }

        // -------- NEW: BULK DELETE STUDENTS --------
        public sealed class BulkDeleteStudentsRequest
        {
            [Required, MinLength(1)]
            public List<Guid> Ids { get; set; } = new();
        }

        [HttpPost]
        public async Task<IActionResult> BulkDeleteStudents([FromBody] BulkDeleteStudentsRequest req, CancellationToken ct)
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "Teacher" && role != "SuperAdmin")
                return Unauthorized();

            if (req is null || req.Ids is null || req.Ids.Count == 0)
                return BadRequest(new { message = "No ids provided." });

            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrWhiteSpace(email))
                return Unauthorized();

            var employee = await _employeeService.GetByEmailAsync(email);
            if (employee is null)
                return Unauthorized();

            var isSuperAdmin = role == "SuperAdmin";

            var ids = req.Ids.Distinct().ToList();
            var notFound = new List<Guid>();
            var unauthorized = new List<Guid>();
            var errors = new List<string>();
            int deleted = 0;

            // Preload teacher section ids for permission checks if needed
            // For super admin, skip teacher section check

            foreach (var id in ids)
            {
                try
                {
                    var student = await _db.Students.FirstOrDefaultAsync(s => s.Id == id, ct);
                    if (student is null)
                    {
                        notFound.Add(id);
                        continue;
                    }

                    // For super admin, skip teacher section check

                    using var tx = await _db.Database.BeginTransactionAsync(ct);
                    try
                    {
                        var attemptIds = await _db.StudentAssessmentAttempts
                            .Where(a => a.StudentId == id)
                            .Select(a => a.Id)
                            .ToListAsync(ct);

                        if (attemptIds.Count > 0)
                        {
                            await _db.StudentAssessmentAchievements
                                .Where(a => attemptIds.Contains(a.AttemptId))
                                .ExecuteDeleteAsync(ct);
                            await _db.StudentAssessmentAnswers
                                .Where(a => attemptIds.Contains(a.AttemptId))
                                .ExecuteDeleteAsync(ct);
                            await _db.StudentAssessmentStrandScores
                                .Where(s => attemptIds.Contains(s.AttemptId))
                                .ExecuteDeleteAsync(ct);
                            await _db.StudentAssessmentResults
                                .Where(r => r.StudentId == id || attemptIds.Contains(r.AttemptId))
                                .ExecuteDeleteAsync(ct);
                            await _db.StudentAssessmentAttempts
                                .Where(a => attemptIds.Contains(a.Id))
                                .ExecuteDeleteAsync(ct);
                        }

                        await _db.SectionStudents.Where(ss => ss.StudentId == id).ExecuteDeleteAsync(ct);

                        _db.Students.Remove(student);
                        await _db.SaveChangesAsync(ct);

                        await tx.CommitAsync(ct);
                        deleted++;
                    }
                    catch (Exception ex)
                    {
                        await tx.RollbackAsync(ct);
                        errors.Add($"{id}: {ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    errors.Add($"{id}: {ex.Message}");
                }
            }

            return Ok(new
            {
                success = errors.Count == 0,
                requested = ids.Count,
                deleted,
                notFound,
                unauthorized,
                errors
            });
        }

        // NEW: Pre-check which students can be deleted (permission + existence only)
        [HttpPost]
        public async Task<IActionResult> CanDeleteStudents([FromBody] BulkDeleteStudentsRequest req, CancellationToken ct)
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "Teacher" && role != "SuperAdmin")
                return Unauthorized();

            if (req is null || req.Ids is null || req.Ids.Count == 0)
                return BadRequest(new { message = "No ids provided." });

            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrWhiteSpace(email))
                return Unauthorized();

            var employee = await _employeeService.GetByEmailAsync(email);
            if (employee is null)
                return Unauthorized();

            var isSuperAdmin = role == "SuperAdmin";

            var ids = req.Ids.Distinct().ToList();

            var existing = await _db.Students
                .Where(s => ids.Contains(s.Id))
                .Select(s => new { s.Id, s.Name })
                .ToListAsync(ct);
            var existingIds = existing.Select(x => x.Id).ToList();
            var nameById = existing.ToDictionary(x => x.Id, x => x.Name);

            var ok = new List<Guid>();
            var notFound = ids.Except(existingIds).ToList();
            var unauthorized = new List<object>();

            // For super admin, skip teacher section check

            foreach (var id in existingIds)
            {
                // For super admin, skip teacher section check

                ok.Add(id);
            }

            return Ok(new { ok, notFound, unauthorized });
        }

        private static bool TryParseBirthday(string value, out DateTime date)
        {
            // Accept yyyy-MM-dd or MM/dd/yyyy
            var formats = new[] { "yyyy-MM-dd", "MM/dd/yyyy", "M/d/yyyy" };
            return DateTime.TryParseExact(value, formats, System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out date);
        }

        private static string[] SplitCsv(string line)
        {
            // Simple split (no quoted commas). Extend if needed.
            return line.Split(',', StringSplitOptions.None);
        }
    }
}
