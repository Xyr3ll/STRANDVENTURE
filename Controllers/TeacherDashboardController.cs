using Microsoft.AspNetCore.Mvc;
using STRANDVENTURE.Models;
using STRANDVENTURE.Security;
using STRANDVENTURE.Services;

namespace STRANDVENTURE.Controllers {
    public class TeacherDashboardController : Controller {

        private readonly ILogger<TeacherDashboardController> _logger;
        private readonly ICaptchaService _captchaService;
        private readonly IEmployeeService _employeeService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IStudentService _studentService;
        private readonly ISectionService _sectionService;
        private readonly ISectionStudentService _sectionStudentService;
        private readonly IAssessmentAnalyticsService _analytics; // use service abstraction

        public TeacherDashboardController(
            ILogger<TeacherDashboardController> logger,
            ICaptchaService captchaService,
            IEmployeeService employeeService,
            IPasswordHasher passwordHasher,
            IStudentService studentService,
            ISectionService sectionService,
            ISectionStudentService sectionStudentService,
            IAssessmentAnalyticsService analytics) {
            _logger = logger;
            _captchaService = captchaService;
            _employeeService = employeeService;
            _studentService = studentService;
            _passwordHasher = passwordHasher;
            _sectionService = sectionService;
            _sectionStudentService = sectionStudentService;
            _analytics = analytics;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index() {
            // Session guard (consistent with other controllers)
            if (HttpContext.Session.GetString("UserRole") != "Teacher" && HttpContext.Session.GetString("UserRole") != "SuperAdmin")
                return RedirectToAction("TeacherLogin", "Home");

            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrWhiteSpace(email))
                return RedirectToAction("TeacherLogin", "Home");

            var employee = await _employeeService.GetByEmailAsync(email);
            if (employee is null)
                return RedirectToAction("TeacherLogin", "Home");

            // Load all active sections (teacher filtering removed)
            var sections = await _sectionService.ListActiveAsync();
            var activeSections = sections.OrderBy(s => s.Name).ToList();

            // Build per-section totals and unique student set across teacher sections
            var sectionProgress = new List<TeacherDashboardViewModel.SectionProgressVm>();
            var uniqueStudentIds = new HashSet<Guid>();

            foreach (var sec in activeSections) {
                var links = await _sectionStudentService.ListBySectionAsync(sec.Id);
                var activeLinks = links.Where(l => l.IsActive).ToList();

                foreach (var l in activeLinks)
                    uniqueStudentIds.Add(l.StudentId);

                sectionProgress.Add(new TeacherDashboardViewModel.SectionProgressVm {
                    SectionId = sec.Id,
                    SectionName = sec.Name,
                    Completed = 0, // placeholder updated below once we know honored results
                    Total = activeLinks.Count
                });
            }

            var totalStudents = uniqueStudentIds.Count;

            // Honored results via analytics service
            var honoredResults = await _analytics.GetHonoredResultsAsync(uniqueStudentIds);
            var completedAssessments = honoredResults.Count; // completion == having an honored result
            var pendingAssessments = totalStudents - completedAssessments;

            // Per-section completion update
            if (completedAssessments > 0) {
                var honoredSet = honoredResults.Select(r => r.StudentId).ToHashSet();
                foreach (var sp in sectionProgress) {
                    // Count active links again (could cache earlier if needed)
                    var links = await _sectionStudentService.ListBySectionAsync(sp.SectionId);
                    sp.Completed = links.Count(l => l.IsActive && honoredSet.Contains(l.StudentId));
                }
            }

            // Strand distribution via analytics service
            var strandDistRaw = await _analytics.GetStrandDistributionAsync(uniqueStudentIds);
            var strandDist = strandDistRaw
                .Select(sd => new TeacherDashboardViewModel.StrandDistributionVm {
                    StrandId = sd.StrandId,
                    Name = sd.Name,
                    Color = sd.Color,
                    Count = sd.Count,
                    Percent = sd.Percent
                })
                .ToList();

            var viewmodel = new TeacherDashboardViewModel {
                Employee = employee,
                TotalStudents = totalStudents,
                TotalSections = activeSections.Count,
                CompletedAssessments = completedAssessments,
                PendingAssessments = pendingAssessments,
                SectionsProgress = sectionProgress,
                StrandDistribution = strandDist
            };

            ViewData["PortalTitle"] = "Teacher Portal";
            ViewData["DisplayName"] = employee.Name;

            return View(viewmodel);
        }

        public class TeacherDashboardViewModel {
            public Employee Employee { get; set; } = null!;
            public int TotalStudents { get; set; }
            public int TotalSections { get; set; }
            public int CompletedAssessments { get; set; }
            public int PendingAssessments { get; set; }
            public List<SectionProgressVm> SectionsProgress { get; set; } = new();
            public List<StrandDistributionVm> StrandDistribution { get; set; } = new();

            public int CompletionRate =>
                TotalStudents == 0 ? 0 : (int)Math.Round(CompletedAssessments * 100.0 / TotalStudents);

            public class SectionProgressVm {
                public Guid SectionId { get; set; }
                public string SectionName { get; set; } = string.Empty;
                public int Completed { get; set; }
                public int Total { get; set; }
                public int CompletionRate => Total == 0 ? 0 : (int)Math.Round(Completed * 100.0 / Total);
            }

            public class StrandDistributionVm {
                public Guid StrandId { get; set; }
                public string Name { get; set; } = string.Empty;
                public string Color { get; set; } = "#888";
                public int Count { get; set; }
                public double Percent { get; set; }
            }
        }
    }
}
