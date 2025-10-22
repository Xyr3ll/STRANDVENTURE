using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using STRANDVENTURE.Models;
using STRANDVENTURE.Security;
using STRANDVENTURE.Services;

namespace STRANDVENTURE.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICaptchaService _captchaService;
    private readonly IEmployeeService _employeeService;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IStudentService _studentService;

    public HomeController(ILogger<HomeController> logger, ICaptchaService captchaService, IEmployeeService employeeService,IPasswordHasher passwordHasher, IStudentService studentService)
    {
        _logger = logger;
        _captchaService = captchaService;
        _employeeService = employeeService;
        _studentService = studentService;
        _passwordHasher = passwordHasher;
    }

    public IActionResult Index()
    {
        return RedirectToAction("StudentLogin");
    }

    [HttpGet]
    public async Task<IActionResult> StudentLogin() {
        var vm = new StudentLoginViewModel();
        GenerateNewCaptchaStudentView(vm);
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> StudentLogin(StudentLoginViewModel model)
    {
        var sessionCaptcha = HttpContext.Session.GetString("StudentCaptcha");
        if (!_captchaService.ValidateCaptcha(model.Input.CaptchaInput, sessionCaptcha))
        {
            ModelState.AddModelError("Input.CaptchaInput", "Invalid CAPTCHA code. Please try again.");
        }

        if (!ModelState.IsValid)
        {
            GenerateNewCaptchaStudentView(model);
            return View(model);
        }

        try
        {
            if (await ValidateStudentCredentials(model.Input.LRN, model.Input.Password))
            {
                HttpContext.Session.SetString("UserRole", "Student");
                HttpContext.Session.SetString("UserLRN", model.Input.LRN);

                if (model.Input.RememberMe)
                {
                    var cookieOptions = new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddDays(30),
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict
                    };
                    Response.Cookies.Append("RememberStudent", model.Input.LRN, cookieOptions);
                }

                _logger.LogInformation("Student {LRN} logged in successfully", model.Input.LRN);
                Student? studentdata = await _studentService.GetByLRNAsync(model.Input.LRN);

                // Keep existing dashboard route if it's still a Razor Page
                return RedirectToAction("Index","StudentDashboard",new {id = studentdata?.Id });
            }
            else
            {
                model.ErrorMessage = "Invalid LRN or password. Please try again.";
                _logger.LogWarning("Failed login attempt for student: {LRN}", model.Input.LRN);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during student login for {LRN}", model.Input.LRN);
            model.ErrorMessage = "An error occurred during login. Please try again.";
        }

        model.Input.Password = string.Empty;
        model.Input.CaptchaInput = string.Empty;
        GenerateNewCaptchaStudentView(model);

        return View(model);
    }

    [HttpGet]
    public IActionResult StudentForgotPassword()
    {
        var vm = new StudentForgotPasswordViewModel();
        GenerateNewCaptchaStudentView(vm);
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> StudentForgotPassword(StudentForgotPasswordViewModel model, CancellationToken ct)
    {
        var sessionCaptcha = HttpContext.Session.GetString("StudentCaptcha");
        if (!_captchaService.ValidateCaptcha(model.Input.CaptchaInput, sessionCaptcha))
        {
            ModelState.AddModelError("Input.CaptchaInput", "Invalid CAPTCHA code. Please try again.");
        }

        if (!ModelState.IsValid)
        {
            GenerateNewCaptchaStudentView(model);
            return View(model);
        }

        try
        {
            var student = await _studentService.GetByLRNAsync(model.Input.LRN, ct);
            if (student is null || !student.IsActive)
            {
                model.ErrorMessage = "Student not found or inactive.";
                GenerateNewCaptchaStudentView(model);
                return View(model);
            }

            if (student.Birthday.Date != model.Input.Birthday.Date)
            {
                model.ErrorMessage = "Birthday does not match our records.";
                GenerateNewCaptchaStudentView(model);
                return View(model);
            }

            student.PasswordHash = _passwordHasher.Hash(model.Input.NewPassword);
            await _studentService.UpdateAsync(student, ct);

            model = new StudentForgotPasswordViewModel
            {
                SuccessMessage = "Password has been reset. You can now sign in.",
            };
            GenerateNewCaptchaStudentView(model);
            return View(model);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error resetting student password for {LRN}", model.Input.LRN);
            model.ErrorMessage = "An error occurred while resetting the password.";
            GenerateNewCaptchaStudentView(model);
            return View(model);
        }
    }

    [HttpPost]
    public IActionResult RefreshStudentCaptcha()
    {
        var captcha = _captchaService.GenerateCaptcha();
        HttpContext.Session.SetString("StudentCaptcha", captcha.CaptchaText);
        return Json(new { image = captcha.CaptchaImageBase64 });
    }

    public IActionResult LogoutStudent()
    {
        // Clear server-side session
        HttpContext.Session.Clear();

        // Remove any persistence cookies
        Response.Cookies.Delete("RememberStudent");
        Response.Cookies.Delete(".AspNetCore.Session");

        // Extra safety: tell the browser not to cache this response
        Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate, max-age=0";
        Response.Headers["Pragma"] = "no-cache";
        Response.Headers["Expires"] = "0";

        return RedirectToAction("StudentLogin");
    }

    public IActionResult LogoutTeacher() {
        // Clear server-side session
        HttpContext.Session.Clear();

        // Remove any persistence cookies
        Response.Cookies.Delete("RememberEmployee");
        Response.Cookies.Delete("RememberStudent");
        Response.Cookies.Delete(".AspNetCore.Session");

        // Extra safety: tell the browser not to cache this response
        Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate, max-age=0";
        Response.Headers["Pragma"] = "no-cache";
        Response.Headers["Expires"] = "0";

        return RedirectToAction("TeacherLogin");
    }

    public IActionResult TeacherLogin()
    {
        var vm = new TeacherLoginViewModel();
        GenerateNewCaptchaTeacherView(vm);
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> TeacherLogin(TeacherLoginViewModel model) {
        var sessionCaptcha = HttpContext.Session.GetString("TeacherCaptcha");
        if (!_captchaService.ValidateCaptcha(model.Input.CaptchaInput, sessionCaptcha)) {
            ModelState.AddModelError("Input.CaptchaInput", "Invalid CAPTCHA code. Please try again.");
        }

        if (!ModelState.IsValid) {
            GenerateNewCaptchaTeacherView(model);
            return View(model);
        }

        try {
            if (await ValidateTeacherCredentials(model.Input.Email, model.Input.Password)) {
                var employee = await _employeeService.GetByEmailAsync(model.Input.Email);
                if (employee is null) {
                    model.ErrorMessage = "Account not found.";
                    GenerateNewCaptchaTeacherView(model);
                    return View(model);
                }

                // Set role based on employee.Role (SuperAdmin or Teacher)
                HttpContext.Session.SetString("UserRole", employee.Role.ToString());
                HttpContext.Session.SetString("UserEmail", model.Input.Email);

                if (employee.Role == EmployeeRole.SuperAdmin) {
                    _logger.LogInformation("SuperAdmin {Email} logged in successfully", model.Input.Email);
                    return RedirectToAction("Index", "TeacherManagement", new { id = employee?.Id });
                }

                if (model.Input.RememberMe) {
                    var cookieOptions = new CookieOptions {
                        Expires = DateTimeOffset.UtcNow.AddDays(30),
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict
                    };
                    Response.Cookies.Append("RememberEmployee", model.Input.Email, cookieOptions);
                }
                Employee? employeedata = employee;
                _logger.LogInformation("Employee {Email} logged in successfully", model.Input.Email);
                return RedirectToAction("Index", "TeacherDashboard", new { id = employeedata?.Id });
            } else {
                model.ErrorMessage = "Invalid Email or password. Please try again.";
                _logger.LogWarning("Failed login attempt for employee: {Email}", model.Input.Email);
            }
        } catch (Exception ex) {
            _logger.LogError(ex, "Error during teacher login for {Email}", model.Input.Email);
            model.ErrorMessage = "An error occurred during login. Please try again.";
        }

        model.Input.Password = string.Empty;
        model.Input.CaptchaInput = string.Empty;
        GenerateNewCaptchaTeacherView(model);

        return View(model);
    }


    [HttpPost]
    public IActionResult RefreshTeacherCaptcha() {
        var captcha = _captchaService.GenerateCaptcha();
        HttpContext.Session.SetString("TeacherCaptcha", captcha.CaptchaText);
        return Json(new { image = captcha.CaptchaImageBase64 });
    }

    [HttpGet]
    public IActionResult TeacherForgotPassword()
    {
        var vm = new TeacherForgotPasswordViewModel();
        GenerateNewCaptchaTeacherView(vm);
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> TeacherForgotPassword(TeacherForgotPasswordViewModel model, CancellationToken ct)
    {
        var sessionCaptcha = HttpContext.Session.GetString("TeacherCaptcha");
        if (!_captchaService.ValidateCaptcha(model.Input.CaptchaInput, sessionCaptcha))
        {
            ModelState.AddModelError("Input.CaptchaInput", "Invalid CAPTCHA code. Please try again.");
        }

        if (!ModelState.IsValid)
        {
            GenerateNewCaptchaTeacherView(model);
            return View(model);
        }

        try
        {
            var employee = await _employeeService.GetByEmailAsync(model.Input.Email, ct);
            if (employee is null || !employee.IsActive)
            {
                model.ErrorMessage = "Account not found or inactive.";
                GenerateNewCaptchaTeacherView(model);
                return View(model);
            }

            employee.PasswordHash = _passwordHasher.Hash(model.Input.NewPassword);
            await _employeeService.UpdateAsync(employee, ct);

            model = new TeacherForgotPasswordViewModel
            {
                SuccessMessage = "Password has been reset. You can now sign in.",
            };
            GenerateNewCaptchaTeacherView(model);
            return View(model);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error resetting teacher password for {Email}", model.Input.Email);
            model.ErrorMessage = "An error occurred while resetting the password.";
            GenerateNewCaptchaTeacherView(model);
            return View(model);
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private void GenerateNewCaptchaStudentView(StudentLoginViewModel model)
    {
        var captcha = _captchaService.GenerateCaptcha();
        model.CaptchaImageBase64 = captcha.CaptchaImageBase64;
        HttpContext.Session.SetString("StudentCaptcha", captcha.CaptchaText);
    }

    private void GenerateNewCaptchaStudentView(StudentForgotPasswordViewModel model)
    {
        var captcha = _captchaService.GenerateCaptcha();
        model.CaptchaImageBase64 = captcha.CaptchaImageBase64;
        HttpContext.Session.SetString("StudentCaptcha", captcha.CaptchaText);
    }

    private void GenerateNewCaptchaTeacherView(TeacherLoginViewModel model) {
        var captcha = _captchaService.GenerateCaptcha();
        model.CaptchaImageBase64 = captcha.CaptchaImageBase64;
        HttpContext.Session.SetString("TeacherCaptcha", captcha.CaptchaText);
    }

    private void GenerateNewCaptchaTeacherView(TeacherForgotPasswordViewModel model) {
        var captcha = _captchaService.GenerateCaptcha();
        model.CaptchaImageBase64 = captcha.CaptchaImageBase64;
        HttpContext.Session.SetString("TeacherCaptcha", captcha.CaptchaText);
    }

    private async Task<bool> ValidateStudentCredentials(string lrn, string password)
    {
        Student? student = await _studentService.GetByLRNAsync(lrn);

        if (student is null || !student.IsActive)
            return false;

        return _passwordHasher.Verify(password, student.PasswordHash);
    }

    private async Task<bool> ValidateTeacherCredentials(string email, string password) {
        Employee? employee = await _employeeService.GetByEmailAsync(email);

        if (employee is null || !employee.IsActive)
            return false;

        return _passwordHasher.Verify(password, employee.PasswordHash);
    }
}
