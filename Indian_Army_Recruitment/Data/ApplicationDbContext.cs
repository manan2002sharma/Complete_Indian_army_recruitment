using Indian_Army_Recruitment.Models;
using Microsoft.EntityFrameworkCore;
namespace Indian_Army_Recruitment.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}
        public DbSet<User> Users { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<VacancyExamResult> VacancyExamResults { get; set; }
        public DbSet<DocumentVerification> DocumentVerifications { get; set; }
        public DbSet<TrainingProgram> TrainingPrograms { get; set; }
        public DbSet<CandidateProfile> CandidateProfiles { get; set; }
        public DbSet<PlatformAccess> PlatformAccesses { get; set; }
        public DbSet<VacancyExam> VacancyExams { get; set; }
        public DbSet<RequiredDocument> RequiredDocuments { get; set; }
        public DbSet<CandidateDocument> CandidateDocuments { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder) { 
        //{
        //    modelBuilder.Entity<VacancyExamResult>()
        //       .Property(v => v.ExamResultId)
        //       .HasDefaultValueSql("NEWSEQUENTIALID()")
        //       .ValueGeneratedOnAdd();

        //    modelBuilder.Entity<Vacancy>()
        //       .Property(v => v.VacancyId)
        //       .HasDefaultValueSql("NEWSEQUENTIALID()")
        //       .ValueGeneratedOnAdd();

        //    modelBuilder.Entity<VacancyAnalysis>()
        //        .Property(va => va.ReportId)
        //        .HasDefaultValueSql("NEWSEQUENTIALID()")
        //        .ValueGeneratedOnAdd(); 

        //    modelBuilder.Entity<PlatformAccess>()
        //        .Property(pa => pa.PlatformId)
        //        .HasDefaultValueSql("NEWSEQUENTIALID()")
        //        .ValueGeneratedOnAdd();

        //    modelBuilder.Entity<User>()
        //        .Property(u => u.UserId)
        //        .HasDefaultValueSql("NEWSEQUENTIALID()")
        //        .ValueGeneratedOnAdd();

        //    modelBuilder.Entity<CandidateProfile>()
        //        .Property(cp => cp.UserId)
        //        .HasDefaultValueSql("NEWSEQUENTIALID()")
        //        .ValueGeneratedOnAdd();

        //    modelBuilder.Entity<RequiredDocument>()
        //        .Property(cp => cp.RequiredDocumentId)
        //        .HasDefaultValueSql("NEWSEQUENTIALID()")
        //        .ValueGeneratedOnAdd();

        //    modelBuilder.Entity<VacancyExam>()
        //        .Property(ve => ve.ExamId)
        //        .HasDefaultValueSql("NEWSEQUENTIALID()")
        //        .ValueGeneratedOnAdd();

        //    modelBuilder.Entity<Application>()
        //        .Property(ve => ve.ApplicationId)
        //        .HasDefaultValueSql("NEWSEQUENTIALID()")
        //        .ValueGeneratedOnAdd();

        //    modelBuilder.Entity<Test>()
        //        .Property(ve => ve.TestId)
        //        .HasDefaultValueSql("NEWSEQUENTIALID()")
        //        .ValueGeneratedOnAdd();

        //    modelBuilder.Entity<CandidateDocument>()
        //        .Property(ve => ve.CandidateDocumentId)
        //        .HasDefaultValueSql("NEWSEQUENTIALID()")
        //        .ValueGeneratedOnAdd();

        //    modelBuilder.Entity<TrainingProgram>()
        //        .Property(ve => ve.TrainingId)
        //        .HasDefaultValueSql("NEWSEQUENTIALID()")
        //        .ValueGeneratedOnAdd();

        //    modelBuilder.Entity<DocumentVerification>()
        //        .Property(ve => ve.VerificationId)
        //        .HasDefaultValueSql("NEWSEQUENTIALID()")
        //        .ValueGeneratedOnAdd();

        //    //relation

        //    //platformaccess and user
        //    modelBuilder.Entity<PlatformAccess>()
        //        .HasOne(pa => pa.User)
        //        .WithMany(u => u.PlatformAccesses)
        //        .HasForeignKey(pa => pa.UserId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    //candidateprofile and user
        //    modelBuilder.Entity<User>()
        //        .HasOne(u => u.CandidateProfile)
        //        .WithOne(cp => cp.User)
        //        .HasForeignKey<CandidateProfile>(cp => cp.UserId) // Foreign key is also the primary key
        //        .OnDelete(DeleteBehavior.Cascade);

        //    //Vacancy and user
        //    modelBuilder.Entity<Vacancy>()
        //        .HasOne(v => v.PostedByUser) // Navigation property in Vacancy
        //        .WithMany(u => u.Vacancies) // Navigation property in User
        //        .HasForeignKey(v => v.PostedBy) // Foreign Key in Vacancy
        //        .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete if needed

        //    //vacancy and vacancyanalysis
        //    modelBuilder.Entity<VacancyAnalysis>()
        //        .HasOne(va => va.Vacancy) // Navigation property in VacancyAnalysis
        //        .WithMany(v => v.VacancyAnalysis) // Navigation property in Vacancy
        //        .HasForeignKey(va => va.VacancyId) // Foreign key in VacancyAnalysis
        //        .OnDelete(DeleteBehavior.Cascade);

        //    // Vacancy to RequiredDocument relationship
        //    modelBuilder.Entity<RequiredDocument>()
        //        .HasOne(rd => rd.Vacancy) // Navigation property in RequiredDocument
        //        .WithMany(v => v.RequiredDocuments) // Navigation property in Vacancy
        //        .HasForeignKey(rd => rd.VacancyId) // Foreign key in RequiredDocument
        //        .OnDelete(DeleteBehavior.Cascade); // Cascade delete when Vacancy is deleted

        //    // User to Application relationship
        //    modelBuilder.Entity<Application>()
        //        .HasOne(a => a.User) // Application has one User
        //        .WithMany(u => u.Applications) // User has many Applications
        //        .HasForeignKey(a => a.UserId) // Foreign key
        //        .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

        //    // Vacancy to Application relationship
        //    modelBuilder.Entity<Application>()
        //        .HasOne(a => a.Vacancy) // Application has one Vacancy
        //        .WithMany(v => v.Applications) // Vacancy has many Applications
        //        .HasForeignKey(a => a.VacancyId) // Foreign key
        //        .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

        //    // Vacancy to VacancyExam relationship                  
        //    modelBuilder.Entity<VacancyExam>()
        //        .HasOne(ve => ve.Vacancy) // VacancyExam has one Vacancy
        //        .WithMany(v => v.VacancyExams) // Vacancy has many VacancyExams
        //        .HasForeignKey(ve => ve.VacancyId) // Foreign key
        //        .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

        //    // Application to VacancyExamResult relationship
        //    modelBuilder.Entity<VacancyExamResult>()
        //        .HasOne(ve => ve.Application) // VacancyExamResult has one Application
        //        .WithMany(a => a.VacancyExamResults) // Application has many VacancyExamResults
        //        .HasForeignKey(ve => ve.ApplicationId) // Foreign key for Application
        //        .OnDelete(DeleteBehavior.Cascade); // Cascade delete to ensure related ExamResults are deleted with Application

        //    // VacancyExam to VacancyExamResult relationship
        //    modelBuilder.Entity<VacancyExamResult>()
        //        .HasOne(ve => ve.VacancyExam) // VacancyExamResult has one VacancyExam
        //        .WithMany(ve => ve.VacancyExamResults) // VacancyExam has many VacancyExamResults
        //        .HasForeignKey(ve => ve.ExamId) // Foreign key for VacancyExam
        //        .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete of VacancyExam when ExamResult is deleted
            
        //    // Application to Test relationship (one-to-many)
        //    modelBuilder.Entity<Test>()
        //        .HasOne(t => t.Application)  // Test has one Application
        //        .WithMany(a => a.Tests)      // Application has many Tests
        //        .HasForeignKey(t => t.ApplicationId)  // Foreign key for Application in Test
        //        .OnDelete(DeleteBehavior.Cascade);

        //    // One-to-many relationship between RequiredDocument and CandidateDocument
        //    modelBuilder.Entity<CandidateDocument>()
        //        .HasOne(cd => cd.RequiredDocument)
        //        .WithMany(rd => rd.CandidateDocuments)  // RequiredDocument has many CandidateDocuments
        //        .HasForeignKey(cd => cd.RequiredDocumentId)
        //        .OnDelete(DeleteBehavior.Cascade);  // Cascade delete: when a RequiredDocument is deleted, all associated CandidateDocuments are deleted

        //    // One-to-many relationship between Application and CandidateDocument
        //    modelBuilder.Entity<CandidateDocument>()
        //        .HasOne(cd => cd.Application)
        //        .WithMany(a => a.CandidateDocuments)  // Application has many CandidateDocuments
        //        .HasForeignKey(cd => cd.ApplicationId)
        //        .OnDelete(DeleteBehavior.Cascade);  // Cascade delete: when an Application is deleted, all associated CandidateDocuments are deleted

        //    // One-to-many relationship between Application and TrainingProgram
        //    modelBuilder.Entity<TrainingProgram>()
        //        .HasOne(tp => tp.Application)  // TrainingProgram has one Application
        //        .WithMany(a => a.TrainingPrograms)  // Application has many TrainingPrograms
        //        .HasForeignKey(tp => tp.ApplicationId)  // Foreign key in TrainingProgram
        //        .OnDelete(DeleteBehavior.Cascade);  // Optional: Cascade delete if you want to delete associated TrainingPrograms when Application is deleted

        //    // One-to-one relationship between CandidateDocument and DocumentVerification
        //    modelBuilder.Entity<CandidateDocument>()
        //        .HasOne(cd => cd.DocumentVerification)  // CandidateDocument has one DocumentVerification
        //        .WithOne(dv => dv.CandidateDocument)  // DocumentVerification has one CandidateDocument
        //        .HasForeignKey<DocumentVerification>(dv => dv.CandidateDocumentID)  // Foreign key in DocumentVerification
        //        .OnDelete(DeleteBehavior.Cascade);  // Optional: Cascade delete if you want to delete associated DocumentVerification when CandidateDocument is deleted

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
