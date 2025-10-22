using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STRANDVENTURE.Data;
using STRANDVENTURE.Models;
using STRANDVENTURE.Services;

namespace STRANDVENTURE.Controllers;

/// <summary>
/// SuperAdmin quiz management per strand (CRUD + set live quiz + question assignment)
/// </summary>
public sealed class StrandQuizManagementController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly IEmployeeService _employeeService;

    public StrandQuizManagementController(ApplicationDbContext db, IEmployeeService employeeService)
    {
        _db = db;
        _employeeService = employeeService;
    }

    private bool IsSuperAdmin() => HttpContext.Session.GetString("UserRole") == "SuperAdmin";

    private async Task<Employee?> GetCurrentEmployeeAsync()
    {
        var email = HttpContext.Session.GetString("UserEmail");
        if (string.IsNullOrWhiteSpace(email)) return null;
        return await _employeeService.GetByEmailAsync(email);
    }

    #region Quiz List Page
    [HttpGet]
    public async Task<IActionResult> Index(Guid strandId, CancellationToken ct)
    {
        if (!IsSuperAdmin()) return RedirectToAction("TeacherLogin", "Home");
        if (strandId == Guid.Empty) return RedirectToAction("Index", "StrandManagement");

        var strand = await _db.Strands.AsNoTracking().FirstOrDefaultAsync(s => s.Id == strandId, ct);
        if (strand is null) return RedirectToAction("Index", "StrandManagement");

        var emp = await GetCurrentEmployeeAsync();
        ViewData["PortalTitle"] = "Super Admin Portal";
        ViewData["DisplayName"] = emp?.Name ?? "";
        ViewData["StrandName"] = strand.Name;
        ViewData["StrandId"] = strand.Id;
        var vm = new TeacherPortalViewModel { Employee = emp ?? new Employee() };
        return View(vm);
    }

    [HttpGet]
    public async Task<IActionResult> List(Guid strandId, CancellationToken ct)
    {
        if (!IsSuperAdmin()) return Forbid();
        if (strandId == Guid.Empty) return BadRequest(new { message = "Missing strand id" });

        var data = await _db.StrandQuizzes
            .Where(q => q.StrandId == strandId)
            .OrderByDescending(q => q.IsLive).ThenBy(q => q.Title)
            .Select(q => new {
                id = q.Id,
                title = q.Title,
                description = q.Description,
                timeLimitSeconds = q.TimeLimitSeconds,
                totalQuestions = q.TotalQuestions,
                randomizeQuestions = q.RandomizeQuestions,
                randomizeOptions = q.RandomizeOptions,
                isActive = q.IsActive,
                isLive = q.IsLive,
                createdAt = q.CreatedAt
            })
            .ToListAsync(ct);
        return Json(new { data });
    }
    #endregion

    #region Create / Update / Delete / SetLive
    public sealed class CreateQuizRequest
    {
        public Guid StrandId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int? TimeLimitSeconds { get; set; }
        public bool RandomizeQuestions { get; set; } = true;
        public bool RandomizeOptions { get; set; } = true;
        public bool IsActive { get; set; } = true;
        public bool IsLive { get; set; } = false; // allow marking live on create
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateQuizRequest req, CancellationToken ct)
    {
        if (!IsSuperAdmin()) return Forbid();
        if (req.StrandId == Guid.Empty || string.IsNullOrWhiteSpace(req.Title))
            return BadRequest(new { message = "Invalid payload" });

        var strandExists = await _db.Strands.AnyAsync(s => s.Id == req.StrandId, ct);
        if (!strandExists) return NotFound(new { message = "Strand not found" });

        var dup = await _db.StrandQuizzes.AnyAsync(q => q.StrandId == req.StrandId && q.Title == req.Title.Trim(), ct);
        if (dup) return Conflict(new { message = "Quiz title already exists for this strand" });

        var emp = await GetCurrentEmployeeAsync();
        if (emp is null) return Unauthorized();

        var quiz = new StrandQuiz
        {
            StrandId = req.StrandId,
            Title = req.Title.Trim(),
            Description = string.IsNullOrWhiteSpace(req.Description) ? null : req.Description.Trim(),
            TimeLimitSeconds = req.TimeLimitSeconds,
            RandomizeQuestions = req.RandomizeQuestions,
            RandomizeOptions = req.RandomizeOptions,
            IsActive = req.IsActive,
            IsLive = req.IsLive,
            CreatedBy = emp.Id,
            TotalQuestions = 0
        };

        using var tx = await _db.Database.BeginTransactionAsync(ct);
        if (quiz.IsLive)
        {
            // Unset any existing live quiz for the strand
            var prevLives = await _db.StrandQuizzes.Where(q => q.StrandId == quiz.StrandId && q.IsLive).ToListAsync(ct);
            foreach (var q in prevLives) q.IsLive = false;
        }
        _db.StrandQuizzes.Add(quiz);
        await _db.SaveChangesAsync(ct);
        await tx.CommitAsync(ct);
        return Ok(new { success = true, id = quiz.Id });
    }

    public sealed class UpdateQuizRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int? TimeLimitSeconds { get; set; }
        public bool RandomizeQuestions { get; set; }
        public bool RandomizeOptions { get; set; }
        public bool IsActive { get; set; }
        public bool IsLive { get; set; }
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromBody] UpdateQuizRequest req, CancellationToken ct)
    {
        if (!IsSuperAdmin()) return Forbid();
        if (req.Id == Guid.Empty || string.IsNullOrWhiteSpace(req.Title))
            return BadRequest(new { message = "Invalid payload" });

        var quiz = await _db.StrandQuizzes.FirstOrDefaultAsync(q => q.Id == req.Id, ct);
        if (quiz is null) return NotFound(new { message = "Quiz not found" });

        // Unique title per strand (ignore self)
        var dup = await _db.StrandQuizzes.AnyAsync(q => q.StrandId == quiz.StrandId && q.Title == req.Title.Trim() && q.Id != quiz.Id, ct);
        if (dup) return Conflict(new { message = "Quiz title already exists for this strand" });

        quiz.Title = req.Title.Trim();
        quiz.Description = string.IsNullOrWhiteSpace(req.Description) ? null : req.Description.Trim();
        quiz.TimeLimitSeconds = req.TimeLimitSeconds;
        quiz.RandomizeQuestions = req.RandomizeQuestions;
        quiz.RandomizeOptions = req.RandomizeOptions;
        quiz.IsActive = req.IsActive;

        using var tx = await _db.Database.BeginTransactionAsync(ct);
        if (req.IsLive && !quiz.IsLive)
        {
            var others = await _db.StrandQuizzes.Where(q => q.StrandId == quiz.StrandId && q.IsLive && q.Id != quiz.Id).ToListAsync(ct);
            foreach (var o in others) o.IsLive = false;
            quiz.IsLive = true;
        }
        else if (!req.IsLive && quiz.IsLive)
        {
            // Allow unsetting live; no replacement set here
            quiz.IsLive = false;
        }
        await _db.SaveChangesAsync(ct);
        await tx.CommitAsync(ct);
        return Ok(new { success = true });
    }

    [HttpPost]
    public async Task<IActionResult> SetLive(Guid id, CancellationToken ct)
    {
        if (!IsSuperAdmin()) return Forbid();
        if (id == Guid.Empty) return BadRequest(new { message = "Invalid id" });
        var quiz = await _db.StrandQuizzes.FirstOrDefaultAsync(q => q.Id == id, ct);
        if (quiz is null) return NotFound(new { message = "Quiz not found" });

        using var tx = await _db.Database.BeginTransactionAsync(ct);
        var others = await _db.StrandQuizzes.Where(q => q.StrandId == quiz.StrandId && q.IsLive && q.Id != quiz.Id).ToListAsync(ct);
        foreach (var o in others) o.IsLive = false;
        quiz.IsLive = true;
        await _db.SaveChangesAsync(ct);
        await tx.CommitAsync(ct);
        return Ok(new { success = true });
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        if (!IsSuperAdmin()) return Forbid();
        if (id == Guid.Empty) return BadRequest(new { message = "Invalid id" });
        var quiz = await _db.StrandQuizzes.FirstOrDefaultAsync(q => q.Id == id, ct);
        if (quiz is null) return NotFound(new { message = "Quiz not found" });
        _db.StrandQuizzes.Remove(quiz);
        await _db.SaveChangesAsync(ct);
        return Ok(new { success = true });
    }
    #endregion

    #region Question Assignment
    // UPDATED: use QuizQuestion / QuizQuestionOption instead of global assessment Question
    [HttpGet]
    public async Task<IActionResult> Questions(Guid quizId, CancellationToken ct)
    {
        if (!IsSuperAdmin()) return RedirectToAction("TeacherLogin", "Home");
        if (quizId == Guid.Empty) return RedirectToAction("Index", "StrandManagement");
        var quiz = await _db.StrandQuizzes.Include(q => q.Strand).FirstOrDefaultAsync(q => q.Id == quizId, ct);
        if (quiz is null) return RedirectToAction("Index", "StrandManagement");
        var emp = await GetCurrentEmployeeAsync();
        ViewData["PortalTitle"] = "Super Admin Portal";
        ViewData["DisplayName"] = emp?.Name ?? "";
        ViewData["QuizTitle"] = quiz.Title;
        ViewData["StrandName"] = quiz.Strand.Name;
        ViewData["QuizId"] = quiz.Id;
        ViewData["StrandId"] = quiz.StrandId;
        var vm = new TeacherPortalViewModel { Employee = emp ?? new Employee() };
        return View(vm);
    }

    [HttpGet]
    public async Task<IActionResult> QuizQuestions(Guid quizId, CancellationToken ct)
    {
        if (!IsSuperAdmin()) return Forbid();
        if (quizId == Guid.Empty) return BadRequest(new { message = "quizId required" });
        var list = await _db.QuizQuestions
            .Where(x => x.StrandQuizId == quizId)
            .OrderBy(x => x.DisplayOrder ?? int.MaxValue).ThenBy(x => x.CreatedAt)
            .Select(x => new {
                id = x.Id,
                text = x.Text,
                options = x.Options.Count,
                hasCorrect = x.Options.Any(o => o.IsCorrect)
            })
            .ToListAsync(ct);
        return Json(new { data = list });
    }

    public sealed class CreateQuizQuestionRequest
    {
        public Guid QuizId { get; set; }
        public string Text { get; set; } = string.Empty;
        public int? DisplayOrder { get; set; }
    }

    [HttpPost]
    public async Task<IActionResult> CreateQuizQuestion([FromBody] CreateQuizQuestionRequest req, CancellationToken ct)
    {
        if (!IsSuperAdmin()) return Forbid();
        if (req.QuizId == Guid.Empty || string.IsNullOrWhiteSpace(req.Text)) return BadRequest(new { message = "Invalid payload" });
        var quiz = await _db.StrandQuizzes.FirstOrDefaultAsync(q => q.Id == req.QuizId, ct);
        if (quiz is null) return NotFound(new { message = "Quiz not found" });
        if (req.DisplayOrder.HasValue)
        {
            var existsOrder = await _db.QuizQuestions.AnyAsync(q => q.StrandQuizId == req.QuizId && q.DisplayOrder == req.DisplayOrder, ct);
            if (existsOrder) return Conflict(new { message = "Display order already in use" });
        }
        var emp = await GetCurrentEmployeeAsync();
        if (emp is null) return Unauthorized();
        var q = new QuizQuestion { StrandQuizId = req.QuizId, Text = req.Text.Trim(), DisplayOrder = req.DisplayOrder, CreatedBy = emp.Id };
        _db.QuizQuestions.Add(q);
        await _db.SaveChangesAsync(ct);
        // update cached total
        quiz.TotalQuestions = await _db.QuizQuestions.CountAsync(x => x.StrandQuizId == req.QuizId, ct);
        await _db.SaveChangesAsync(ct);
        return Ok(new { success = true, id = q.Id });
    }

    public sealed class UpdateQuizQuestionRequest
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int? DisplayOrder { get; set; }
        public bool IsActive { get; set; } = true;
    }

    [HttpPost]
    public async Task<IActionResult> UpdateQuizQuestion([FromBody] UpdateQuizQuestionRequest req, CancellationToken ct)
    {
        if (!IsSuperAdmin()) return Forbid();
        if (req.Id == Guid.Empty || string.IsNullOrWhiteSpace(req.Text)) return BadRequest(new { message = "Invalid payload" });
        var q = await _db.QuizQuestions.FirstOrDefaultAsync(x => x.Id == req.Id, ct);
        if (q is null) return NotFound(new { message = "Question not found" });
        if (req.DisplayOrder.HasValue)
        {
            var existsOrder = await _db.QuizQuestions.AnyAsync(x => x.StrandQuizId == q.StrandQuizId && x.DisplayOrder == req.DisplayOrder && x.Id != q.Id, ct);
            if (existsOrder) return Conflict(new { message = "Display order already in use" });
        }
        q.Text = req.Text.Trim();
        q.DisplayOrder = req.DisplayOrder;
        q.IsActive = req.IsActive;
        await _db.SaveChangesAsync(ct);
        return Ok(new { success = true });
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteQuizQuestion(Guid id, CancellationToken ct)
    {
        if (!IsSuperAdmin()) return Forbid();
        if (id == Guid.Empty) return BadRequest(new { message = "Invalid id" });
        var q = await _db.QuizQuestions.FirstOrDefaultAsync(x => x.Id == id, ct);
        if (q is null) return NotFound(new { message = "Question not found" });
        var quizId = q.StrandQuizId;
        _db.QuizQuestions.Remove(q);
        await _db.SaveChangesAsync(ct);
        var quiz = await _db.StrandQuizzes.FirstOrDefaultAsync(x => x.Id == quizId, ct);
        if (quiz != null)
        {
            quiz.TotalQuestions = await _db.QuizQuestions.CountAsync(x => x.StrandQuizId == quizId, ct);
            await _db.SaveChangesAsync(ct);
        }
        return Ok(new { success = true });
    }

    // Options
    [HttpGet]
    public async Task<IActionResult> QuizQuestionOptions(Guid questionId, CancellationToken ct)
    {
        if (!IsSuperAdmin()) return Forbid();
        if (questionId == Guid.Empty) return BadRequest(new { message = "questionId required" });
        var list = await _db.QuizQuestionOptions
            .Where(o => o.QuizQuestionId == questionId)
            .OrderBy(o => o.Letter)
            .Select(o => new { id = o.Id, letter = o.Letter, text = o.Text, isCorrect = o.IsCorrect })
            .ToListAsync(ct);
        return Json(new { data = list });
    }

    public sealed class UpsertOptionRequest
    {
        public Guid QuestionId { get; set; }
        public Guid? Id { get; set; }
        public string Letter { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
    }

    [HttpPost]
    public async Task<IActionResult> UpsertQuizQuestionOption([FromBody] UpsertOptionRequest req, CancellationToken ct)
    {
        if (!IsSuperAdmin()) return Forbid();
        if (req.QuestionId == Guid.Empty || string.IsNullOrWhiteSpace(req.Letter) || string.IsNullOrWhiteSpace(req.Text))
            return BadRequest(new { message = "Invalid payload" });
        var question = await _db.QuizQuestions.FirstOrDefaultAsync(q => q.Id == req.QuestionId, ct);
        if (question is null) return NotFound(new { message = "Question not found" });
        QuizQuestionOption? opt = null;
        if (req.Id.HasValue)
        {
            opt = await _db.QuizQuestionOptions.FirstOrDefaultAsync(o => o.Id == req.Id && o.QuizQuestionId == req.QuestionId, ct);
            if (opt is null) return NotFound(new { message = "Option not found" });
        }
        // Validate letter uniqueness
        var letterUsed = await _db.QuizQuestionOptions.AnyAsync(o => o.QuizQuestionId == req.QuestionId && o.Letter == req.Letter && (!req.Id.HasValue || o.Id != req.Id.Value), ct);
        if (letterUsed) return Conflict(new { message = "Letter already used" });
        if (req.IsCorrect)
        {
            var alreadyCorrect = await _db.QuizQuestionOptions.AnyAsync(o => o.QuizQuestionId == req.QuestionId && o.IsCorrect && (!req.Id.HasValue || o.Id != req.Id.Value), ct);
            if (alreadyCorrect) return Conflict(new { message = "A correct option already exists" });
        }
        if (opt == null)
        {
            opt = new QuizQuestionOption { QuizQuestionId = req.QuestionId, Letter = req.Letter.ToUpperInvariant(), Text = req.Text.Trim(), IsCorrect = req.IsCorrect };
            _db.QuizQuestionOptions.Add(opt);
        }
        else
        {
            opt.Letter = req.Letter.ToUpperInvariant();
            opt.Text = req.Text.Trim();
            opt.IsCorrect = req.IsCorrect;
        }
        await _db.SaveChangesAsync(ct);
        return Ok(new { success = true, id = opt.Id });
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteQuizQuestionOption(Guid id, CancellationToken ct)
    {
        if (!IsSuperAdmin()) return Forbid();
        if (id == Guid.Empty) return BadRequest(new { message = "Invalid id" });
        var opt = await _db.QuizQuestionOptions.FirstOrDefaultAsync(o => o.Id == id, ct);
        if (opt is null) return NotFound(new { message = "Option not found" });
        _db.QuizQuestionOptions.Remove(opt);
        await _db.SaveChangesAsync(ct);
        return Ok(new { success = true });
    }
    #endregion
}
