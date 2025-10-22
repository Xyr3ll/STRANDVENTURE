using Microsoft.EntityFrameworkCore;
using STRANDVENTURE.Data;
using STRANDVENTURE.Services;
using System.ComponentModel.Design;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Register custom services
builder.Services.AddScoped<ICaptchaService, CaptchaService>();
builder.Services.AddSingleton<STRANDVENTURE.Security.IPasswordHasher, STRANDVENTURE.Security.Pbkdf2PasswordHasher>();

// Add Entity Framework
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories + per-entity services
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ISectionService, SectionService>();
builder.Services.AddScoped<ISectionStudentService, SectionStudentService>();
builder.Services.AddScoped<IStrandService, StrandService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IQuestionOptionService, QuestionOptionService>();
builder.Services.AddScoped<IQuestionOptionStrandWeightService, QuestionOptionStrandWeightService>();
builder.Services.AddScoped<IAssessmentBulkImportService, AssessmentBulkImportService>();
builder.Services.AddScoped<IAssessmentAnalyticsService, AssessmentAnalyticsService>();
builder.Services.AddScoped<IAssessmentProgressService, AssessmentProgressService>();
builder.Services.AddScoped<IStudentAssessmentAttemptService, StudentAssessmentAttemptService>();
builder.Services.AddScoped<IStudentStrandQuizResultService, StudentStrandQuizResultService>();
var app = builder.Build();

// Apply EF Core migrations automatically on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();   
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
