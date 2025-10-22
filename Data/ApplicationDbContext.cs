using Microsoft.EntityFrameworkCore;
using STRANDVENTURE.Models;
using STRANDVENTURE.Services;

namespace STRANDVENTURE.Data
{
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSets
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SectionStudent> SectionStudents { get; set; }
        public DbSet<Strand> Strands { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
        public DbSet<QuestionOptionStrandWeight> QuestionOptionStrandWeights { get; set; }
        public DbSet<StrandQuiz> StrandQuizzes { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        public DbSet<QuizQuestionOption> QuizQuestionOptions { get; set; }

        // Assessment persistence
        public DbSet<StudentAssessmentAttempt> StudentAssessmentAttempts { get; set; }
        public DbSet<StudentAssessmentAnswer> StudentAssessmentAnswers { get; set; }
        public DbSet<StudentAssessmentStrandScore> StudentAssessmentStrandScores { get; set; }
        public DbSet<StudentAssessmentResult> StudentAssessmentResults { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<StudentAssessmentAchievement> StudentAssessmentAchievements { get; set; }
        public DbSet<StudentNotifyAssessment> StudentNotifyAssessments { get; set; }
        public DbSet<StudentStrandQuizResult> StudentStrandQuizResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            // Employee
            modelBuilder.Entity<Employee>(entity => {
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.Role).HasConversion<string>().HasMaxLength(20);
            });

            // Student
            modelBuilder.Entity<Student>(entity => {
                entity.HasIndex(e => e.LRN).IsUnique();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.Birthday).HasColumnType("date");
            });

            // Section
            modelBuilder.Entity<Section>(entity => {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                // Teacher navigation and TeacherId foreign key removed
            });

            // SectionStudent
            modelBuilder.Entity<SectionStudent>(entity => {
                entity.Property(e => e.EnrolledAt).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.HasOne(ss => ss.Section).WithMany(s => s.SectionStudents).HasForeignKey(ss => ss.SectionId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(ss => ss.Student).WithMany(s => s.SectionStudents).HasForeignKey(ss => ss.StudentId).OnDelete(DeleteBehavior.Cascade);
                entity.HasIndex(ss => new { ss.SectionId, ss.StudentId }).IsUnique();
            });

            // Strand
            modelBuilder.Entity<Strand>(entity => {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.Color).HasMaxLength(20).HasDefaultValue("#000000");
            });

            // Question
            modelBuilder.Entity<Question>(entity => {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.HasIndex(e => e.QuestionOrder).IsUnique();
                entity.HasOne(q => q.CreatedByEmployee).WithMany(e => e.CreatedQuestions).HasForeignKey(q => q.CreatedBy).OnDelete(DeleteBehavior.Restrict);
            });

            // QuestionOption
            modelBuilder.Entity<QuestionOption>(entity => {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.HasOne(qo => qo.Question).WithMany(q => q.QuestionOptions).HasForeignKey(qo => qo.QuestionId).OnDelete(DeleteBehavior.Cascade);
                entity.HasIndex(qo => new { qo.QuestionId, qo.OptionLetter }).IsUnique();
                entity.HasIndex(qo => new { qo.QuestionId, qo.IsCorrect }).HasFilter("[IsCorrect] = 1").IsUnique();
            });

            // QuestionOptionStrandWeight
            modelBuilder.Entity<QuestionOptionStrandWeight>(entity => {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.HasOne(qosw => qosw.QuestionOption).WithMany(qo => qo.QuestionOptionStrandWeights).HasForeignKey(qosw => qosw.QuestionOptionId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(qosw => qosw.Strand).WithMany(s => s.QuestionOptionStrandWeights).HasForeignKey(qosw => qosw.StrandId).OnDelete(DeleteBehavior.Cascade);
                entity.HasIndex(qosw => new { qosw.QuestionOptionId, qosw.StrandId }).IsUnique();
            });

            // StrandQuiz
            modelBuilder.Entity<StrandQuiz>(entity => {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.HasOne(q => q.Strand).WithMany().HasForeignKey(q => q.StrandId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(q => q.CreatedByEmployee).WithMany().HasForeignKey(q => q.CreatedBy).OnDelete(DeleteBehavior.Restrict);
                entity.HasIndex(q => new { q.StrandId, q.Title }).IsUnique(); // prevent duplicate quiz titles per strand
                entity.HasIndex(q => new { q.StrandId, q.IsLive }).HasFilter("[IsLive] = 1").IsUnique();
            });

            // QuizQuestion
            modelBuilder.Entity<QuizQuestion>(entity => {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.HasOne(q => q.StrandQuiz).WithMany(z => z.Questions).HasForeignKey(q => q.StrandQuizId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(q => q.CreatedByEmployee).WithMany().HasForeignKey(q => q.CreatedBy).OnDelete(DeleteBehavior.Restrict);
                entity.HasIndex(q => new { q.StrandQuizId, q.DisplayOrder }).HasFilter("[DisplayOrder] IS NOT NULL").IsUnique();
            });

            modelBuilder.Entity<QuizQuestionOption>(entity => {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.HasOne(o => o.QuizQuestion).WithMany(q => q.Options).HasForeignKey(o => o.QuizQuestionId).OnDelete(DeleteBehavior.Cascade);
                entity.HasIndex(o => new { o.QuizQuestionId, o.Letter }).IsUnique();
                entity.HasIndex(o => new { o.QuizQuestionId, o.IsCorrect }).HasFilter("[IsCorrect] = 1").IsUnique();
            });

            // StudentAssessmentAttempt
            modelBuilder.Entity<StudentAssessmentAttempt>(entity => {
                entity.Property(e => e.StartedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.IsCompleted).HasDefaultValue(false);
                entity.Property(e => e.TotalScorePercent).HasColumnType("decimal(5,2)");
                entity.HasOne(a => a.Student).WithMany().HasForeignKey(a => a.StudentId).OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(a => a.EarnedAchievements).WithOne(sa => sa.Attempt).HasForeignKey(sa => sa.AttemptId).OnDelete(DeleteBehavior.Cascade);
                entity.HasIndex(a => new { a.StudentId, a.AttemptNumber }).IsUnique();
            });

            // StudentAssessmentAnswer
            modelBuilder.Entity<StudentAssessmentAnswer>(entity => {
                entity.Property(e => e.SelectedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.HasOne(a => a.Attempt).WithMany(p => p.Answers).HasForeignKey(a => a.AttemptId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(a => a.Question).WithMany().HasForeignKey(a => a.QuestionId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(a => a.QuestionOption).WithMany().HasForeignKey(a => a.QuestionOptionId).OnDelete(DeleteBehavior.Restrict);
                entity.HasIndex(a => new { a.AttemptId, a.QuestionId }).IsUnique();
                entity.HasIndex(a => a.QuestionId);
                entity.HasIndex(a => a.QuestionOptionId);
            });

            // StudentAssessmentStrandScore
            modelBuilder.Entity<StudentAssessmentStrandScore>(entity => {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.ScorePercent).HasColumnType("decimal(5,2)");
                entity.HasOne(s => s.Attempt).WithMany(p => p.StrandScores).HasForeignKey(s => s.AttemptId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(s => s.Strand).WithMany().HasForeignKey(s => s.StrandId).OnDelete(DeleteBehavior.Restrict);
                entity.HasIndex(s => new { s.AttemptId, s.StrandId }).IsUnique();
                entity.HasIndex(s => s.StrandId);
            });

            // StudentAssessmentResult
            modelBuilder.Entity<StudentAssessmentResult>(entity => {
                entity.Property(e => e.FinalizedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.HasOne(r => r.Student).WithMany().HasForeignKey(r => r.StudentId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(r => r.Attempt).WithOne(a => a.Result).HasForeignKey<StudentAssessmentResult>(r => r.AttemptId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(r => r.RecommendedStrand).WithMany().HasForeignKey(r => r.RecommendedStrandId).OnDelete(DeleteBehavior.Restrict);
                entity.HasIndex(r => r.StudentId).IsUnique();
                entity.HasIndex(r => r.AttemptId).IsUnique();
            });

            // Achievement
            modelBuilder.Entity<Achievement>(entity => {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.HasIndex(a => a.Code).IsUnique();
                entity.Property(a => a.IsActive).HasDefaultValue(true);
            });

            // StudentAssessmentAchievement
            modelBuilder.Entity<StudentAssessmentAchievement>(entity => {
                entity.Property(e => e.UnlockedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.HasOne(saa => saa.Student).WithMany().HasForeignKey(saa => saa.StudentId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(saa => saa.Achievement).WithMany(a => a.StudentAchievements).HasForeignKey(saa => saa.AchievementId).OnDelete(DeleteBehavior.Restrict);
                entity.HasIndex(saa => new { saa.AttemptId, saa.AchievementId }).IsUnique();
            });

            // StudentNotifyAssessment
            modelBuilder.Entity<StudentNotifyAssessment>(entity => {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.HasOne(n => n.Student).WithMany().HasForeignKey(n => n.StudentId).OnDelete(DeleteBehavior.Cascade);
                entity.HasIndex(n => n.StudentId).IsUnique();
            });

            // StudentStrandQuizResult
            modelBuilder.Entity<StudentStrandQuizResult>(entity => {
                entity.Property(e => e.CompletedAt).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.ScorePercent).HasColumnType("decimal(5,2)");
                entity.HasOne(r => r.Student).WithMany().HasForeignKey(r => r.StudentId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(r => r.StrandQuiz).WithMany().HasForeignKey(r => r.StrandQuizId).OnDelete(DeleteBehavior.Restrict);
                entity.HasIndex(r => new { r.StudentId, r.StrandQuizId, r.AttemptNumber }).IsUnique();
                entity.HasIndex(r => r.StrandQuizId);
            });

            // Seeds
            SeedStrands(modelBuilder);
            SeedEmployee(modelBuilder);
            SeedAchievements(modelBuilder);
            SeedCulinaryQuiz(modelBuilder); // existing quiz
            SeedGraphicsQuiz(modelBuilder); // graphics quiz
            SeedSoftwareDevQuiz(modelBuilder); // software dev quiz
            SeedAbmQuiz(modelBuilder); // ABM quiz
            SeedHumssQuiz(modelBuilder); // HUMSS quiz
            SeedStemEngQuiz(modelBuilder); // STEM-Eng quiz
            SeedTourismQuiz(modelBuilder); // Tourism quiz
            SeedStemMedQuiz(modelBuilder); // STEM-Med quiz
        }

        private static readonly Guid SeedSuperAdminId = Guid.Parse("c1f6a527-8aac-4f51-aa59-0c3d8b451e18");
        private static readonly Guid SeedTeacher1Id   = Guid.Parse("a26b9b24-c1ac-47de-9555-9c41571a7bff");
        private static readonly Guid ACH_HALF_WAY = Guid.Parse("44444444-4444-4444-4444-444444444444");
        private static readonly Guid TOURISM    = Guid.Parse("6f5b7c7c-6d5e-4a4e-9b7a-0b7e4d6a9c11");
        private static readonly Guid ABM_STRAND = Guid.Parse("cab2e5d5-53e8-4f5e-bc1d-6d4a9f8b7e33");
        private static readonly Guid GRAPHICS   = Guid.Parse("5c3f9e2d-2c4d-4e6c-9d3a-2b4e7f8a6c55");
        private static readonly Guid HUMSS_VG   = Guid.Parse("2d4f6b7c-8e5a-4c3d-9f2e-7a6b5c4d3e77");
        private static readonly Guid CULINARY   = Guid.Parse("9e8d7c6b-5a4f-4d3c-8b2a-1f6e5d4c3b99");
        private static readonly Guid STEM_MED   = Guid.Parse("4a3b2c1d-5e6f-4789-8a9b-bc1d2e3f4a11");
        private static readonly Guid STEM_ENG   = Guid.Parse("1a2b3c4d-5e6f-4789-9a8b-cd1e2f3a4b22");
        private static readonly Guid SOFTWARE_DEV = Guid.Parse("7b8c9d1e-2f3a-4b5c-8d9e-a1b2c3d4e5f6");

        // Quiz ids
        private static readonly Guid QUIZ_CULINARY_FUND = Guid.Parse("66666666-6666-6666-6666-777777777777");
        private static readonly Guid QUIZ_GRAPHICS_BASICS = Guid.Parse("55555555-5555-5555-5555-777777777777");
        private static readonly Guid QUIZ_SOFTDEV_INTRO = Guid.Parse("11111111-1111-1111-1111-777777777777");
        private static readonly Guid QUIZ_ABM_ESSENTIALS = Guid.Parse("22222222-2222-2222-2222-777777777777");
        private static readonly Guid QUIZ_HUMSS_VISUAL = Guid.Parse("33333333-3333-3333-3333-777777777777");
        private static readonly Guid QUIZ_STEM_ENG_CORE = Guid.Parse("44444444-4444-4444-4444-777777777777");
        private static readonly Guid QUIZ_TOURISM_BASICS = Guid.Parse("88888888-8888-8888-8888-777777777777");
        private static readonly Guid QUIZ_STEM_MED_CORE = Guid.Parse("77777777-7777-7777-7777-777777777777");

        private void SeedStrands(ModelBuilder modelBuilder) {
            var created = new DateTime(2025,1,1,0,0,0,DateTimeKind.Utc);
            modelBuilder.Entity<Strand>().HasData(
                new Strand { Id = TOURISM, Name = "Tourism", Description = "Focuses on travel, hospitality operations, destination management, customer service and sustainable tourism basics.", IsActive = true, CreatedAt = created, Color = "#ff9800" },
                new Strand { Id = ABM_STRAND, Name = "ABM", Description = "Accountancy, Business & Management: accounting fundamentals, entrepreneurship, finance, marketing and business planning.", IsActive = true, CreatedAt = created, Color = "#3f51b5" },
                new Strand { Id = GRAPHICS, Name = "Graphics", Description = "Visual communication: layout, branding, digital illustration, imaging basics and introductory UI/UX concepts.", IsActive = true, CreatedAt = created, Color = "#9c27b0" },
                new Strand { Id = HUMSS_VG, Name = "HUMSS–VG", Description = "Humanities & Social Sciences track variant highlighting communication, culture, social inquiry and community engagement.", IsActive = true, CreatedAt = created, Color = "#009688" },
                new Strand { Id = CULINARY, Name = "Culinary", Description = "Food preparation, kitchen operations, baking, nutrition, sanitation, menu planning and basic culinary entrepreneurship.", IsActive = true, CreatedAt = created, Color = "#795548" },
                new Strand { Id = STEM_MED, Name = "STEM–Med", Description = "STEM pathway emphasizing biology, chemistry, health sciences, research skills and preparation for medical fields.", IsActive = true, CreatedAt = created, Color = "#e91e63" },
                new Strand { Id = STEM_ENG, Name = "STEM–Eng", Description = "STEM pathway focusing on physics, advanced math, design thinking, prototyping and applied engineering concepts.", IsActive = true, CreatedAt = created, Color = "#2196f3" },
                new Strand { Id = SOFTWARE_DEV, Name = "Software Dev", Description = "Programming fundamentals, algorithms, databases, version control and application development lifecycle projects.", IsActive = true, CreatedAt = created, Color = "#607d8b" }
            );
        }

        private void SeedEmployee(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = SeedSuperAdminId, Email = "superadmin@gmail.com", IsActive = true, Role = EmployeeRole.SuperAdmin, Name = "Super", PasswordHash = Security.PasswordHashing.HashForSeed("SuperAdmin@123") },
                new Employee { Id = SeedTeacher1Id, Email = "teacher1@gmail.com", IsActive = true, Role = EmployeeRole.Teacher, Name = "Teacher 1", PasswordHash = Security.PasswordHashing.HashForSeed("Admin@123") }
            );
        }

        private void SeedAchievements(ModelBuilder modelBuilder) {
            var created = new DateTime(2025,1,1,0,0,0,DateTimeKind.Utc);
            modelBuilder.Entity<Achievement>().HasData(new Achievement { Id = ACH_HALF_WAY, Code = "HALFWAY_HERO", Name = "Halfway Hero", Description = "Answered half of the questions in an assessment.", CreatedAt = created, Icon = "🛤️", Rarity = "Common", Category = "Progress" });
        }

        private void SeedCulinaryQuiz(ModelBuilder modelBuilder)
        {
            var created = new DateTime(2025,2,1,0,0,0,DateTimeKind.Utc);
            modelBuilder.Entity<StrandQuiz>().HasData(new StrandQuiz {
                Id = QUIZ_CULINARY_FUND,
                StrandId = CULINARY,
                Title = "Culinary Fundamentals",
                Description = "Kitchen safety, food prep, baking, service & basic entrepreneurship.",
                TimeLimitSeconds = 1200,
                TotalQuestions = 20,
                RandomizeQuestions = true,
                RandomizeOptions = true,
                IsActive = true,
                IsLive = true,
                CreatedBy = SeedTeacher1Id,
                CreatedAt = created
            });

            // Data source (question, options[4], correctIndex)
            var data = new (string q, string[] opts, int correct)[] {
                ("Why should knives be kept sharp in the kitchen?", new[]{"To cut faster","To reduce accidents and make cutting easier","To look professional","To impress customers"}, 1),
                ("Which of these is the safest way to thaw frozen meat?", new[]{"On the kitchen counter","Under direct sunlight","In the refrigerator","In hot water"}, 2),
                ("Which color chopping board is usually used for raw meat?", new[]{"Red","Blue","Green","Yellow"}, 0),
                ("What is the correct way to hold a knife while walking?", new[]{"Pointing it forward","Pointing it upward","Holding it at your side with the blade facing down","Hiding it behind your back"}, 2),
                ("Why should vegetables be washed before cooking?", new[]{"To remove dirt and chemicals","To make them taste better","To change their color","To cook them faster"}, 0),
                ("Which is the best practice when storing dry ingredients like flour and rice?", new[]{"Leave them in plastic bags","Store in airtight containers","Keep them near the stove","Put them in the refrigerator"}, 1),
                ("If a recipe says ‘julienne the carrots,’ what does it mean?", new[]{"Dice into cubes","Slice into thin strips","Chop into small pieces","Mash into paste"}, 1),
                ("What is the main purpose of marinating meat?", new[]{"To make it colorful","To make it soft and flavorful","To cook it halfway","To make it look bigger"}, 1),
                ("Which of these is a leavening agent in baking?", new[]{"Sugar","Baking powder","Salt","Butter"}, 1),
                ("Which method of cooking involves cooking food in hot oil?", new[]{"Boiling","Frying","Steaming","Stewing"}, 1),
                ("Which pastry is known for its many thin, flaky layers?", new[]{"Croissant","Muffin","Donut","Brownie"}, 0),
                ("What does ‘al dente’ mean when cooking pasta?", new[]{"Overcooked and mushy","Slightly firm to the bite","Undercooked","Burnt on the edges"}, 1),
                ("What is the first thing you should do when serving food to a customer?", new[]{"Smile and greet politely","Serve food immediately","Ask for payment first","Walk away silently"}, 0),
                ("Why is food presentation important?", new[]{"It makes food last longer","It makes food more attractive and appetizing","It cooks food faster","It helps food stay hot"}, 1),
                ("Which is an example of table service?", new[]{"Customers cook their own food","Food is placed on the table by waiters","Guests bring their own food","Food is served in the kitchen only"}, 1),
                ("Which menu type changes daily based on available ingredients?", new[]{"A la carte","Static menu","Table d’hôte","Market menu"}, 3),
                ("What do you call calculating the cost of ingredients to set a selling price?", new[]{"Pricing","Budgeting","Food costing","Estimating"}, 2),
                ("Why is portion control important in food business?", new[]{"To avoid food waste and control costs","To make food look bigger","To make customers order more","To cook faster"}, 0),
                ("Which is the BEST way to attract more customers to your food business?", new[]{"Keep prices high","Offer poor service","Provide good quality food and service","Avoid advertising"}, 2),
                ("If you dream of opening your own restaurant, which skill besides cooking is MOST important?", new[]{"Leadership and business management","Sleeping early","Memorizing recipes","Talking loudly"}, 0)
            };

            Guid BuildGuid(string hex) => Guid.Parse(hex);
            var questions = new List<QuizQuestion>();
            var options = new List<QuizQuestionOption>();
            // Use prefix 60F2A (hex-valid) similar deterministic approach; build ids from index
            string prefix = "60F2A"; // <= 5 chars
            for(int i=0;i<data.Length;i++){
                int display = i+1;
                string qIdHex = (prefix + display.ToString("D2")).PadRight(32,'0');
                // insert dashes
                var qGuid = BuildGuid(qIdHex.Insert(8,"-").Insert(13,"-").Insert(18,"-").Insert(23,"-"));
                questions.Add(new QuizQuestion {
                    Id = qGuid,
                    StrandQuizId = QUIZ_CULINARY_FUND,
                    Text = data[i].q,
                    DisplayOrder = display,
                    IsActive = true,
                    CreatedBy = SeedTeacher1Id,
                    CreatedAt = created
                });
                var letters = new[]{"A","B","C","D"};
                for(int o=0;o<4;o++){
                    string optHex = (prefix + display.ToString("D2") + (o+1).ToString("D2")).PadRight(32,'f');
                    var oGuid = BuildGuid(optHex.Insert(8,"-").Insert(13,"-").Insert(18,"-").Insert(23,"-"));
                    options.Add(new QuizQuestionOption {
                        Id = oGuid,
                        QuizQuestionId = qGuid,
                        Letter = letters[o],
                        Text = data[i].opts[o],
                        IsCorrect = o == data[i].correct,
                        CreatedAt = created
                    });
                }
            }

            modelBuilder.Entity<QuizQuestion>().HasData(questions);
            modelBuilder.Entity<QuizQuestionOption>().HasData(options);
        }

        private void SeedGraphicsQuiz(ModelBuilder modelBuilder)
        {
            var created = new DateTime(2025,2,2,0,0,0,DateTimeKind.Utc);
            modelBuilder.Entity<StrandQuiz>().HasData(new StrandQuiz {
                Id = QUIZ_GRAPHICS_BASICS,
                StrandId = GRAPHICS,
                Title = "Graphics & Multimedia Basics",
                Description = "Fundamentals of graphics tools, formats, design & multimedia careers.",
                TimeLimitSeconds = 1200,
                TotalQuestions = 20,
                RandomizeQuestions = true,
                RandomizeOptions = true,
                IsActive = true,
                IsLive = true,
                CreatedBy = SeedTeacher1Id,
                CreatedAt = created
            });

            var data = new (string q, string[] opts, int correct)[] {
                ("Which software is widely used for photo editing?", new[]{"Photoshop","Visual Studio","Notepad++","Eclipse"}, 0),
                ("Which of the following refers to the combination of text, images, audio, and video?", new[]{"Programming","Multimedia","Debugging","Coding"}, 1),
                ("Which file format is commonly used for images?", new[]{".jpg",".exe",".mp3",".txt"}, 0),
                ("What does DPI stand for in graphics?", new[]{"Digital Program Instruction","Dots Per Inch","Design Processing Input","Data Print Image"}, 1),
                ("Which of the following is an example of vector graphics software?", new[]{"Microsoft Word","Adobe Illustrator","VLC Media Player","Audacity"}, 1),
                ("Which color model is used for digital screens?", new[]{"CMYK","RGB","RBGY","HEX"}, 1),
                ("Which multimedia career focuses on creating animated characters?", new[]{"Programmer","Animator","Database Admin","Engineer"}, 1),
                ("What is the main purpose of a storyboard in multimedia projects?", new[]{"To write code","To plan the sequence of visuals","To edit sound","To test software"}, 1),
                ("Which file format is commonly used for video files?", new[]{".mp4",".docx",".pptx",".xls"}, 0),
                ("Which of the following jobs belongs to the Graphics and Multimedia pathway?", new[]{"Game Designer","Software Engineer","Surgeon","Accountant"}, 0),
                ("Which of the following is a raster-based graphic software?", new[]{"Adobe Photoshop","Adobe Illustrator","CorelDRAW","SketchUp"}, 0),
                ("Which file format is commonly used for audio in multimedia?", new[]{".png",".mp3",".gif",".exe"}, 1),
                ("Which principle of design refers to the arrangement of elements to create stability?", new[]{"Balance","Contrast","Rhythm","Emphasis"}, 0),
                ("Which software is commonly used for 3D animation?", new[]{"Blender","Notepad","Microsoft Word","MySQL"}, 0),
                ("Which of the following refers to the smallest unit of a digital image?", new[]{"Pixel","Byte","Dot","Node"}, 0),
                ("What does CMYK stand for in printing?", new[]{"Color Mode for Yellow and Keys","Cyan, Magenta, Yellow, Black","Clear, Mix, Yellow, Kinetic","Computer Mixed Yield Keys"}, 1),
                ("Which principle of design highlights the difference between elements?", new[]{"Unity","Contrast","Alignment","Proportion"}, 1),
                ("Which of the following software is mainly used for video editing?", new[]{"Adobe Premiere Pro","AutoCAD","NetBeans","Eclipse"}, 0),
                ("Which multimedia element gives movement to objects or characters?", new[]{"Animation","Typography","Layout","Storyboard"}, 0),
                ("Which career works mostly with visual communication and branding?", new[]{"Graphic Designer","Database Manager","Civil Engineer","Programmer"}, 0)
            };

            Guid BuildGuid(string hex) => Guid.Parse(hex);
            var questions = new List<QuizQuestion>();
            var options = new List<QuizQuestionOption>();
            string prefix = "40D2A"; // hex-safe prefix
            for(int i=0;i<data.Length;i++){
                int display = i+1;
                string qIdHex = (prefix + display.ToString("D2")).PadRight(32,'0');
                var qGuid = BuildGuid(qIdHex.Insert(8,"-").Insert(13,"-").Insert(18,"-").Insert(23,"-"));
                questions.Add(new QuizQuestion { Id = qGuid, StrandQuizId = QUIZ_GRAPHICS_BASICS, Text = data[i].q, DisplayOrder = display, IsActive = true, CreatedBy = SeedTeacher1Id, CreatedAt = created });
                var letters = new[]{"A","B","C","D"};
                for(int o=0;o<4;o++){
                    string optHex = (prefix + display.ToString("D2") + (o+1).ToString("D2")).PadRight(32,'f');
                    var oGuid = BuildGuid(optHex.Insert(8,"-").Insert(13,"-").Insert(18,"-").Insert(23,"-"));
                    options.Add(new QuizQuestionOption { Id = oGuid, QuizQuestionId = qGuid, Letter = letters[o], Text = data[i].opts[o], IsCorrect = o == data[i].correct, CreatedAt = created });
                }
            }
            modelBuilder.Entity<QuizQuestion>().HasData(questions);
            modelBuilder.Entity<QuizQuestionOption>().HasData(options);
        }

        private void SeedSoftwareDevQuiz(ModelBuilder modelBuilder)
        {
            var created = new DateTime(2025,2,3,0,0,0,DateTimeKind.Utc);
            modelBuilder.Entity<StrandQuiz>().HasData(new StrandQuiz {
                Id = QUIZ_SOFTDEV_INTRO,
                StrandId = SOFTWARE_DEV,
                Title = "Software Dev Intro",
                Description = "Foundations: concepts, tools, models & terminology.",
                TimeLimitSeconds = 1200,
                TotalQuestions = 20,
                RandomizeQuestions = true,
                RandomizeOptions = true,
                IsActive = true,
                IsLive = true,
                CreatedBy = SeedTeacher1Id,
                CreatedAt = created
            });

            var data = new (string q, string[] opts, int correct)[] {
                ("Which of the following is used to give instructions to a computer?", new[]{"Hardware","Software","Program/Code","Database"}, 2),
                ("Which programming language is commonly used for web development?", new[]{"HTML","Java","Python","All of the above"}, 3),
                ("What does \"bug\" mean in programming?", new[]{"A computer virus","A mistake or error in code","A type of software","A system update"}, 1),
                ("Which symbol is used to end a statement in Java?", new[]{", (comma)",". (period)","; (semicolon)",": (colon)"}, 2),
                ("What does IDE stand for in programming?", new[]{"Internal Design Editor","Integrated Development Environment","Internet Data Exchange","Interactive Debugging Engine"}, 1),
                ("In coding, what does \"loop\" mean?", new[]{"Repeating a set of instructions","Storing data in memory","Combining two programs","Fixing an error"}, 0),
                ("Which of the following is NOT a programming language?", new[]{"Python","Java","Photoshop","C++"}, 2),
                ("What is the first step in solving a programming problem?", new[]{"Debugging","Writing the code immediately","Planning and understanding the problem","Compiling the program"}, 2),
                ("Which of these is used to store multiple values in programming?", new[]{"Loop","Array","Variable","Function"}, 1),
                ("Which of the following jobs is most related to software development?", new[]{"Animator","Game Developer","Photographer","Video Editor"}, 1),
                ("Which programming language is often used for Artificial Intelligence and Data Science?", new[]{"C","Java","Python","HTML"}, 2),
                ("What does GUI stand for?", new[]{"General User Instruction","Graphical User Interface","Global Utility Input","Generated Utility Interaction"}, 1),
                ("Which of the following is used to manage and store data in software applications?", new[]{"Algorithm","Database","Flowchart","Compiler"}, 1),
                ("In HTML, which tag is used to display the largest heading?", new[]{"<h6>","<h1>","<head>","<title>"}, 1),
                ("Which of these is an open-source operating system often used by developers?", new[]{"Windows","Linux","macOS","Android"}, 1),
                ("What does an algorithm represent?", new[]{"A step-by-step solution to a problem","A debugging tool","A computer virus","A type of database"}, 0),
                ("Which software development model has sequential phases?", new[]{"Agile","Waterfall","Spiral","Prototype"}, 1),
                ("Which type of loop will always run at least once (in most languages)?", new[]{"For loop","While loop","Do-while loop","Nested loop"}, 2),
                ("Which profession tests software to ensure it works correctly?", new[]{"Software Tester","Graphic Designer","Animator","Editor"}, 0),
                ("What does API stand for in software development?", new[]{"Application Programming Interface","Advanced Program Instruction","Algorithm Processing Input","Automated Program Index"}, 0)
            };

            Guid BuildGuid(string hex) => Guid.Parse(hex);
            var questions = new List<QuizQuestion>();
            var options = new List<QuizQuestionOption>();
            string prefix = "10A2A"; // hex-safe prefix for ids
            for(int i=0;i<data.Length;i++){
                int display = i+1;
                string qIdHex = (prefix + display.ToString("D2")).PadRight(32,'0');
                var qGuid = BuildGuid(qIdHex.Insert(8,"-").Insert(13,"-").Insert(18,"-").Insert(23,"-"));
                questions.Add(new QuizQuestion { Id = qGuid, StrandQuizId = QUIZ_SOFTDEV_INTRO, Text = data[i].q, DisplayOrder = display, IsActive = true, CreatedBy = SeedTeacher1Id, CreatedAt = created });
                var letters = new[]{"A","B","C","D"};
                for(int o=0;o<4;o++){
                    string optHex = (prefix + display.ToString("D2") + (o+1).ToString("D2")).PadRight(32,'f');
                    var oGuid = BuildGuid(optHex.Insert(8,"-").Insert(13,"-").Insert(18,"-").Insert(23,"-"));
                    options.Add(new QuizQuestionOption { Id = oGuid, QuizQuestionId = qGuid, Letter = letters[o], Text = data[i].opts[o], IsCorrect = o == data[i].correct, CreatedAt = created });
                }
            }
            modelBuilder.Entity<QuizQuestion>().HasData(questions);
            modelBuilder.Entity<QuizQuestionOption>().HasData(options);
        }

        private void SeedAbmQuiz(ModelBuilder modelBuilder)
        {
            var created = new DateTime(2025,2,4,0,0,0,DateTimeKind.Utc);
            modelBuilder.Entity<StrandQuiz>().HasData(new StrandQuiz {
                Id = QUIZ_ABM_ESSENTIALS,
                StrandId = ABM_STRAND,
                Title = "ABM Essentials",
                Description = "Entrepreneurship, accounting, management, marketing, communication & problem solving basics.",
                TimeLimitSeconds = 1200,
                TotalQuestions = 20,
                RandomizeQuestions = true,
                RandomizeOptions = true,
                IsActive = true,
                IsLive = true,
                CreatedBy = SeedTeacher1Id,
                CreatedAt = created
            });

            var data = new (string q, string[] opts, int correct)[] {
                ("Which of the following best describes entrepreneurship?", new[]{"Working for a corporation","Starting and managing your own business","Studying consumer behavior","Writing financial reports"}, 1),
                ("The main goal of a business is to:", new[]{"Provide entertainment","Maximize profit","Create advertisements","Conduct research"}, 1),
                ("Which document is commonly used when starting a business?", new[]{"Business Plan","Sales Report","Balance Sheet","Purchase Order"}, 0),
                ("Bookkeeping primarily deals with:", new[]{"Forecasting market trends","Recording financial transactions","Training employees","Promoting products"}, 1),
                ("Which financial statement shows a company’s revenues and expenses?", new[]{"Balance Sheet","Statement of Cash Flows","Income Statement","Retained Earnings"}, 2),
                ("Assets minus liabilities equals:", new[]{"Profit","Owner’s Equity","Sales Revenue","Cash Flow"}, 1),
                ("Which of the following is NOT a management function?", new[]{"Planning","Organizing","Leading","Consuming"}, 3),
                ("A good leader must possess which of the following qualities?", new[]{"Laziness","Integrity","Avoiding risks","Ignoring teamwork"}, 1),
                ("Delegation in management means:", new[]{"Taking all the responsibilities","Assigning tasks to subordinates","Ignoring employees’ needs","Hiring only managers"}, 1),
                ("Marketing focuses mainly on:", new[]{"Customer needs and wants","Employee performance","Government policies","Bookkeeping"}, 0),
                ("Which is an example of a marketing tool?", new[]{"Ledger","Advertisement","Balance Sheet","Bank Statement"}, 1),
                ("The 4Ps of Marketing include Product, Price, Place, and:", new[]{"Plan","People","Promotion","Profit"}, 2),
                ("Which type of communication is most important in business?", new[]{"Effective oral and written communication","Gossiping","Non-verbal communication only","Using slang"}, 0),
                ("A memorandum (memo) is typically used for:", new[]{"Informal chatting","Internal communication","Advertising products","Financial transactions"}, 1),
                ("Which of the following is an example of business correspondence?", new[]{"Love letter","Business letter","Poem","Comic strip"}, 1),
                ("Critical thinking is best described as:", new[]{"Guessing the answer","Analyzing facts to form a judgment","Memorizing formulas","Copying others’ ideas"}, 1),
                ("When solving a business problem, the first step is to:", new[]{"Implement a solution immediately","Identify the problem","Evaluate alternatives","Write a financial report"}, 1),
                ("A SWOT analysis evaluates:", new[]{"Sales, Wages, Orders, Targets","Strengths, Weaknesses, Opportunities, Threats","Services, Work, Operations, Trends","Stock, Warehouse, Output, Tools"}, 1),
                ("Which college course is most directly related to accounting?", new[]{"BS Accountancy","BS Tourism","BS Hospitality Management","BS Psychology"}, 0),
                ("The ABM strand prepares students mainly for careers in:", new[]{"Medicine","Business and Management","Engineering","Agriculture"}, 1)
            };

            Guid BuildGuid(string hex) => Guid.Parse(hex);
            var questions = new List<QuizQuestion>();
            var options = new List<QuizQuestionOption>();
            string prefix = "30B2A"; // unique hex-safe prefix for ABM quiz
            for(int i=0;i<data.Length;i++){
                int display = i+1;
                string qIdHex = (prefix + display.ToString("D2")).PadRight(32,'0');
                var qGuid = BuildGuid(qIdHex.Insert(8,"-").Insert(13,"-").Insert(18,"-").Insert(23,"-"));
                questions.Add(new QuizQuestion { Id = qGuid, StrandQuizId = QUIZ_ABM_ESSENTIALS, Text = data[i].q, DisplayOrder = display, IsActive = true, CreatedBy = SeedTeacher1Id, CreatedAt = created });
                var letters = new[]{"A","B","C","D"};
                for(int o=0;o<4;o++){
                    string optHex = (prefix + display.ToString("D2") + (o+1).ToString("D2")).PadRight(32,'f');
                    var oGuid = BuildGuid(optHex.Insert(8,"-").Insert(13,"-").Insert(18,"-").Insert(23,"-"));
                    options.Add(new QuizQuestionOption { Id = oGuid, QuizQuestionId = qGuid, Letter = letters[o], Text = data[i].opts[o], IsCorrect = o == data[i].correct, CreatedAt = created });
                }
            }
            modelBuilder.Entity<QuizQuestion>().HasData(questions);
            modelBuilder.Entity<QuizQuestionOption>().HasData(options);
        }

        private void SeedHumssQuiz(ModelBuilder modelBuilder)
        {
            var created = new DateTime(2025,2,5,0,0,0,DateTimeKind.Utc);
            modelBuilder.Entity<StrandQuiz>().HasData(new StrandQuiz {
                Id = QUIZ_HUMSS_VISUAL,
                StrandId = HUMSS_VG,
                Title = "HUMSS Visual Graphics Basics",
                Description = "Visual communication, design principles, literacy & storytelling for HUMSS.",
                TimeLimitSeconds = 1200,
                TotalQuestions = 20,
                RandomizeQuestions = true,
                RandomizeOptions = true,
                IsActive = true,
                IsLive = true,
                CreatedBy = SeedTeacher1Id,
                CreatedAt = created
            });

            var data = new (string q, string[] opts, int correct)[] {
                ("What is the main purpose of visual graphics in communication?", new[]{"To make writing longer","To communicate ideas clearly","To replace written text completely","To decorate only"}, 1),
                ("In HUMSS, “doorways” usually refer to:", new[]{"Classroom doors","Applied subjects or specializations","Entrance exams","Group projects"}, 1),
                ("Which of the following is an example of visual communication?", new[]{"Radio broadcast","Poster design","Telephone conversation","Essay writing"}, 1),
                ("What principle of design is about the equal distribution of elements?", new[]{"Balance","Contrast","Repetition","Movement"}, 0),
                ("A logo is mainly created to:", new[]{"Entertain people","Represent a brand or identity","Fill space in posters","Replace photographs"}, 1),
                ("Which applied subject often includes visual graphics in HUMSS?", new[]{"Physical Education","Media and Information Literacy","Statistics","Philosophy"}, 1),
                ("Which design principle emphasizes differences in color, size, or shape?", new[]{"Harmony","Contrast","Alignment","Unity"}, 1),
                ("A digital tool commonly used for graphic design is:", new[]{"Microsoft Word","Adobe Photoshop","Notepad","Calculator"}, 1),
                ("What does visual storytelling aim to do?", new[]{"Tell stories only through music","Use visuals to support narration","Remove written words","Make reading more difficult"}, 1),
                ("Infographics are effective because they:", new[]{"Replace textbooks completely","Show data in a visual, easy-to-understand form","Focus only on photographs","Are purely decorative"}, 1),
                ("Which of the following is not a visual graphic output?", new[]{"Newsletter layout","Painting","Short story text","Infographic"}, 2),
                ("Visual graphics help in journalism by:", new[]{"Removing the need for facts","Making news more visual and engaging","Replacing interviews","Avoiding storytelling"}, 1),
                ("The principle of design that creates unity by repeating elements is:", new[]{"Repetition","Balance","Contrast","Emphasis"}, 0),
                ("Which of the following best describes visual literacy?", new[]{"Ability to draw realistic pictures","Ability to interpret and create visual messages","Skill in memorizing designs","Knowledge of art history only"}, 1),
                ("A layout that guides the reader’s eye smoothly across a page follows:", new[]{"Emphasis","Movement","Unity","Scale"}, 1),
                ("Which software is NOT primarily for visual graphics?", new[]{"Canva","Photoshop","PowerPoint","Excel"}, 3),
                ("A poster for an advocacy campaign should mainly:", new[]{"Be colorful only","Communicate the message clearly","Avoid text completely","Focus only on decorations"}, 1),
                ("Visual graphics are important in education because they:", new[]{"Distract learners with colors","Replace teachers","Simplify complex ideas visually","Make exams harder"}, 2),
                ("What principle of design makes one element stand out more than others?", new[]{"Emphasis","Unity","Proportion","Balance"}, 0),
                ("In the HUMSS strand, learning visual graphics helps students mainly by:", new[]{"Limiting them to traditional arts","Developing communication and creative skills","Avoiding technology use","Making them memorize graphic terms only"}, 1)
            };

            Guid BuildGuid(string hex) => Guid.Parse(hex);
            var questions = new List<QuizQuestion>();
            var options = new List<QuizQuestionOption>();
            string prefix = "20C2A"; // unique hex-safe prefix for HUMSS quiz
            for(int i=0;i<data.Length;i++){
                int display = i+1;
                string qIdHex = (prefix + display.ToString("D2")).PadRight(32,'0');
                var qGuid = BuildGuid(qIdHex.Insert(8,"-").Insert(13,"-").Insert(18,"-").Insert(23,"-"));
                questions.Add(new QuizQuestion { Id = qGuid, StrandQuizId = QUIZ_HUMSS_VISUAL, Text = data[i].q, DisplayOrder = display, IsActive = true, CreatedBy = SeedTeacher1Id, CreatedAt = created });
                var letters = new[]{"A","B","C","D"};
                for(int o=0;o<4;o++){
                    string optHex = (prefix + display.ToString("D2") + (o+1).ToString("D2")).PadRight(32,'f');
                    var oGuid = BuildGuid(optHex.Insert(8,"-").Insert(13,"-").Insert(18,"-").Insert(23,"-"));
                    options.Add(new QuizQuestionOption { Id = oGuid, QuizQuestionId = qGuid, Letter = letters[o], Text = data[i].opts[o], IsCorrect = o == data[i].correct, CreatedAt = created });
                }
            }
            modelBuilder.Entity<QuizQuestion>().HasData(questions);
            modelBuilder.Entity<QuizQuestionOption>().HasData(options);
        }

        private void SeedStemEngQuiz(ModelBuilder modelBuilder)
        {
            var created = new DateTime(2025,2,6,0,0,0,DateTimeKind.Utc);
            modelBuilder.Entity<StrandQuiz>().HasData(new StrandQuiz {
                Id = QUIZ_STEM_ENG_CORE,
                StrandId = STEM_ENG,
                Title = "STEM-Eng Core Concepts",
                Description = "Mechanics, electricity, energy, earth science & engineering thinking.",
                TimeLimitSeconds = 1200,
                TotalQuestions = 20,
                RandomizeQuestions = true,
                RandomizeOptions = true,
                IsActive = true,
                IsLive = true,
                CreatedBy = SeedTeacher1Id,
                CreatedAt = created
            });

            var data = new (string q, string[] opts, int correct)[] {
                ("What is the unit of force in mechanics?", new[]{"Joule","Watt","Newton","Pascal"}, 2),
                ("Which law states that for every action, there is an equal and opposite reaction?", new[]{"Newton's First Law","Newton's Second Law","Newton's Third Law","Law of Gravitation"}, 2),
                ("What is the formula for Ohm's Law?", new[]{"P = IV","V = IR","F = ma","Q = mcΔT"}, 1),
                ("Which of the following is a renewable energy source?", new[]{"Coal","Oil","Solar energy","Natural gas"}, 2),
                ("The ability of a material to resist being deformed by force is called:", new[]{"Elasticity","Conductivity","Magnetism","Density"}, 0),
                ("Which particle is responsible for electric current?", new[]{"Proton","Neutron","Electron","Photon"}, 2),
                ("What does a magnetic field surround?", new[]{"A moving electron","A resting electron","A piece of wood","A plastic rod"}, 0),
                ("Which branch of physics studies motion and forces?", new[]{"Optics","Mechanics","Thermodynamics","Quantum physics"}, 1),
                ("Which is an example of a vector quantity?", new[]{"Mass","Speed","Velocity","Temperature"}, 2),
                ("What layer of the Earth contains most of the Earth's mass?", new[]{"Crust","Mantle","Outer Core","Inner Core"}, 1),
                ("What is the SI unit of power?", new[]{"Joule","Watt","Newton","Volt"}, 1),
                ("In magnetism, like poles:", new[]{"Attract","Repel","Neutralize","Overlap"}, 1),
                ("Which type of wave requires a medium to travel?", new[]{"Electromagnetic wave","Sound wave","Light wave","Gamma ray"}, 1),
                ("What type of simple machine is a ramp?", new[]{"Lever","Pulley","Inclined plane","Wheel and axle"}, 2),
                ("The study of earthquakes is called:", new[]{"Geology","Seismology","Meteorology","Volcanology"}, 1),
                ("Which gas is most abundant in Earth's atmosphere?", new[]{"Oxygen","Nitrogen","Carbon dioxide","Argon"}, 1),
                ("In applied mathematics, the derivative of a constant is:", new[]{"Zero","One","The constant itself","Undefined"}, 0),
                ("Which of the following is an example of potential energy?", new[]{"A moving car","Water stored in a dam","Sound from a speaker","Electric current in a wire"}, 1),
                ("What happens when an object's net force is zero?", new[]{"It accelerates","It changes direction","It remains at rest or in uniform motion","It gains energy"}, 2),
                ("Which of the following best shows the application of engineering thinking?", new[]{"Solving puzzles for fun","Designing a bridge to carry heavy loads","Writing a poem","Memorizing dates of history"}, 1)
            };

            Guid BuildGuid(string hex) => Guid.Parse(hex);
            var questions = new List<QuizQuestion>();
            var options = new List<QuizQuestionOption>();
            string prefix = "70E2A"; // unique hex-safe prefix for STEM-Eng quiz
            for(int i=0;i<data.Length;i++){
                int display = i+1;
                string qIdHex = (prefix + display.ToString("D2")).PadRight(32,'0');
                var qGuid = BuildGuid(qIdHex.Insert(8,"-").Insert(13,"-").Insert(18,"-").Insert(23,"-"));
                questions.Add(new QuizQuestion { Id = qGuid, StrandQuizId = QUIZ_STEM_ENG_CORE, Text = data[i].q, DisplayOrder = display, IsActive = true, CreatedBy = SeedTeacher1Id, CreatedAt = created });
                var letters = new[]{"A","B","C","D"};
                for(int o=0;o<4;o++){
                    string optHex = (prefix + display.ToString("D2") + (o+1).ToString("D2")).PadRight(32,'f');
                    var oGuid = BuildGuid(optHex.Insert(8,"-").Insert(13,"-").Insert(18,"-").Insert(23,"-"));
                    options.Add(new QuizQuestionOption { Id = oGuid, QuizQuestionId = qGuid, Letter = letters[o], Text = data[i].opts[o], IsCorrect = o == data[i].correct, CreatedAt = created });
                }
            }
            modelBuilder.Entity<QuizQuestion>().HasData(questions);
            modelBuilder.Entity<QuizQuestionOption>().HasData(options);
        }

        private void SeedTourismQuiz(ModelBuilder modelBuilder)
        {
            var created = new DateTime(2025,2,7,0,0,0,DateTimeKind.Utc);
            modelBuilder.Entity<StrandQuiz>().HasData(new StrandQuiz {
                Id = QUIZ_TOURISM_BASICS,
                StrandId = TOURISM,
                Title = "Tourism Fundamentals",
                Description = "Accommodation, automation, planning, IPR, culture & systems.",
                TimeLimitSeconds = 1200,
                TotalQuestions = 20,
                RandomizeQuestions = true,
                RandomizeOptions = true,
                IsActive = true,
                IsLive = true,
                CreatedBy = SeedTeacher1Id,
                CreatedAt = created
            });

            var data = new (string q, string[] opts, int correct)[] {
                ("Which of the following best describes accommodation in tourism?", new[]{"The transport service used by tourists","The place where tourists stay during travel","The travel documents required for entry","The promotional material for tourism"}, 1),
                ("What is the main purpose of an automated system in the tourism industry?", new[]{"To reduce cultural promotion","To manage bookings and reservations efficiently","To replace traditional cuisines","To avoid using computers"}, 1),
                ("Which of the following is a source of tourism information?", new[]{"Travel agencies","Hardware stores","Gas stations","Local police stations"}, 0),
                ("Which is an important element in a travel plan?", new[]{"Food recipes","Tourist destinations and itineraries","Dance performances","Religious rituals"}, 1),
                ("What does IPR (Intellectual Property Rights) protect in the tourism industry?", new[]{"Tourist visas","Cultural dances","Original creative works like logos, slogans, and software","Hotel accommodations"}, 2),
                ("An example of electronic file handling is:", new[]{"Printing brochures","Sending an email attachment","Writing on paper","Cooking local cuisine"}, 1),
                ("Which device is essential to operate an automated information system?", new[]{"Typewriter","Calculator","Computer/Laptop","Fax machine"}, 2),
                ("Cooking international cuisines in tourism promotes:", new[]{"Political unity","Cultural diversity","Business taxation","Banking"}, 1),
                ("Which is an example of tourism accommodation?", new[]{"A restaurant","A hotel","An airport","A souvenir shop"}, 1),
                ("The main benefit of using automated systems in travel agencies is:", new[]{"Longer processing time","More errors in bookings","Faster and accurate reservations","Less use of technology"}, 2),
                ("Which of the following is a copyright-protected material?", new[]{"A travel agency’s software","A tourist’s personal bag","A country’s weather","A public road"}, 0),
                ("In tourism, a travel plan usually contains:", new[]{"Student grades","Tourist itinerary and budget","Political laws","Construction materials"}, 1),
                ("An example of electronic file handling software is:", new[]{"Microsoft Word","Paint brush","Calculator","Typewriter"}, 0),
                ("Which is an example of tourism promotion through food?", new[]{"Serving fast food only","Offering traditional dishes from a culture","Printing textbooks","Writing travel laws"}, 1),
                ("What is the importance of intellectual property in tourism promotions?", new[]{"To protect original creative works from being copied","To increase taxes for travelers","To stop advertising","To reduce accommodations"}, 0),
                ("Which of the following is NOT a type of tourism accommodation?", new[]{"Resort","Hostel","Campsite","Train station"}, 3),
                ("In an automated booking system, which information is usually stored?", new[]{"Tourist’s reservation details","Tourist’s favorite colors","Tourist’s handwriting","Tourist’s childhood story"}, 0),
                ("Electronic file handling ensures:", new[]{"Easy storage and retrieval of data","Increase in manual errors","Slow communication","Less use of computers"}, 0),
                ("Promoting food from different cultures mainly supports:", new[]{"Economic development and cultural tourism","Copyright violations","Less interest in tourism","Computer software development"}, 0),
                ("Which of the following is an example of tourism-related automated system?", new[]{"Airline reservation system","Chalkboard scheduling","Handwritten receipts","Printed brochures only"}, 0)
            };

            Guid BuildGuid(string hex) => Guid.Parse(hex);
            var questions = new List<QuizQuestion>();
            var options = new List<QuizQuestionOption>();
            string prefix = "80F2A"; // unique hex-safe prefix for tourism quiz ids
            for(int i=0;i<data.Length;i++){
                int display = i+1;
                string qIdHex = (prefix + display.ToString("D2")).PadRight(32,'0');
                var qGuid = BuildGuid(qIdHex.Insert(8,"-").Insert(13,"-").Insert(18,"-").Insert(23,"-"));
                questions.Add(new QuizQuestion { Id = qGuid, StrandQuizId = QUIZ_TOURISM_BASICS, Text = data[i].q, DisplayOrder = display, IsActive = true, CreatedBy = SeedTeacher1Id, CreatedAt = created });
                var letters = new[]{"A","B","C","D"};
                for(int o=0;o<4;o++){
                    string optHex = (prefix + display.ToString("D2") + (o+1).ToString("D2")).PadRight(32,'f');
                    var oGuid = BuildGuid(optHex.Insert(8,"-").Insert(13,"-").Insert(18,"-").Insert(23,"-"));
                    options.Add(new QuizQuestionOption { Id = oGuid, QuizQuestionId = qGuid, Letter = letters[o], Text = data[i].opts[o], IsCorrect = o == data[i].correct, CreatedAt = created });
                }
            }
            modelBuilder.Entity<QuizQuestion>().HasData(questions);
            modelBuilder.Entity<QuizQuestionOption>().HasData(options);
        }

        private void SeedStemMedQuiz(ModelBuilder modelBuilder)
        {
            var created = new DateTime(2025,2,8,0,0,0,DateTimeKind.Utc);
            modelBuilder.Entity<StrandQuiz>().HasData(new StrandQuiz {
                Id = QUIZ_STEM_MED_CORE,
                StrandId = STEM_MED,
                Title = "STEM-Med Core Concepts",
                Description = "Biology, systems, health, lab tools, diseases & public health.",
                TimeLimitSeconds = 1200,
                TotalQuestions = 20,
                RandomizeQuestions = true,
                RandomizeOptions = true,
                IsActive = true,
                IsLive = true,
                CreatedBy = SeedTeacher1Id,
                CreatedAt = created
            });

            var data = new (string q, string[] opts, int correct)[] {
                ("Which organ pumps blood throughout the body?", new[]{"Lungs","Heart","Brain","Kidney"}, 1),
                ("Which system controls movement with muscles and bones?", new[]{"Digestive system","Musculoskeletal system","Circulatory system","Nervous system"}, 1),
                ("Where does digestion begin?", new[]{"Stomach","Mouth","Small intestine","Esophagus"}, 1),
                ("Which part of the brain controls balance and coordination?", new[]{"Cerebrum","Cerebellum","Medulla oblongata","Hypothalamus"}, 1),
                ("Which is the basic unit of life?", new[]{"Atom","Cell","Tissue","Organ"}, 1),
                ("Which blood cells fight against infections?", new[]{"Red blood cells","Platelets","White blood cells","Plasma cells"}, 2),
                ("Photosynthesis mainly takes place in which part of a plant?", new[]{"Roots","Stem","Leaves","Flowers"}, 2),
                ("Which process describes how organisms pass traits to offspring?", new[]{"Respiration","Digestion","Heredity","Circulation"}, 2),
                ("Which disease is caused by a lack of insulin in the body?", new[]{"Asthma","Diabetes","Tuberculosis","Hypertension"}, 1),
                ("Which of the following is a communicable disease?", new[]{"Cancer","Flu (Influenza)","Diabetes","Asthma"}, 1),
                ("What is the main purpose of vaccines?", new[]{"To cure illnesses immediately","To boost immunity and prevent diseases","To remove toxins from the body","To strengthen muscles"}, 1),
                ("Which type of energy is measured in food?", new[]{"Light energy","Heat energy","Electrical energy","Chemical energy"}, 3),
                ("In chemistry, H₂O is the formula for what substance?", new[]{"Salt","Water","Oxygen","Carbon dioxide"}, 1),
                ("In medical imaging, X-rays are used to view what?", new[]{"Muscles","Bones","Skin","Blood"}, 1),
                ("Which global organization monitors and responds to international health emergencies?", new[]{"Red Cross","United Nations","World Health Organization (WHO)","CDC"}, 2),
                ("Which laboratory tool is used to measure liquid volume accurately?", new[]{"Beaker","Test tube","Graduated cylinder","Petri dish"}, 2),
                ("Which of these health problems is most studied in public health research?", new[]{"Global warming","Infectious diseases","Car design","Mobile apps"}, 1),
                ("What is a microscope used for?", new[]{"To see very small organisms or cells","To measure weight","To magnify stars in the sky","To cook food"}, 0),
                ("Which safety item should always be worn during lab experiments?", new[]{"Sunglasses","Lab coat and goggles","Chef’s hat","Sports shoes"}, 1),
                ("What is a stethoscope used for?", new[]{"To check blood pressure","To listen to heartbeats and breathing","To measure temperature","To test eyesight"}, 1)
            };

            Guid BuildGuid(string hex) => Guid.Parse(hex);
            var questions = new List<QuizQuestion>();
            var options = new List<QuizQuestionOption>();
            string prefix = "50E2A"; // unique hex-safe prefix for STEM-Med quiz ids
            for(int i=0;i<data.Length;i++){
                int display = i+1;
                string qIdHex = (prefix + display.ToString("D2")).PadRight(32,'0');
                var qGuid = BuildGuid(qIdHex.Insert(8,"-").Insert(13,"-").Insert(18,"-").Insert(23,"-"));
                questions.Add(new QuizQuestion { Id = qGuid, StrandQuizId = QUIZ_STEM_MED_CORE, Text = data[i].q, DisplayOrder = display, IsActive = true, CreatedBy = SeedTeacher1Id, CreatedAt = created });
                var letters = new[]{"A","B","C","D"};
                for(int o=0;o<4;o++){
                    string optHex = (prefix + display.ToString("D2") + (o+1).ToString("D2")).PadRight(32,'f');
                    var oGuid = BuildGuid(optHex.Insert(8,"-").Insert(13,"-").Insert(18,"-").Insert(23,"-"));
                    options.Add(new QuizQuestionOption { Id = oGuid, QuizQuestionId = qGuid, Letter = letters[o], Text = data[i].opts[o], IsCorrect = o == data[i].correct, CreatedAt = created });
                }
            }
            modelBuilder.Entity<QuizQuestion>().HasData(questions);
            modelBuilder.Entity<QuizQuestionOption>().HasData(options);
        }
    }
}