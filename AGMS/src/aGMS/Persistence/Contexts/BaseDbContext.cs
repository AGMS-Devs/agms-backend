using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Rectorate> Rectorates { get; set; }
    public DbSet<Advisor> Advisors { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Staff> Staffs { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Transcript> Transcripts { get; set; }
    public DbSet<FileAttachment> FileAttachments { get; set; }
    public DbSet<FacultyDeansOffice> FacultyDeansOffices { get; set; }
    public DbSet<TakenCourse> TakenCourses { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Ceremony> Ceremonies { get; set; }
    public DbSet<MailLog> MailLogs { get; set; }
    public DbSet<StudentAffair> StudentAffairs { get; set; }
    public DbSet<GraduationProcess> GraduationProcesses { get; set; }
    public DbSet<GraduationList> GraduationLists { get; set; }
    public DbSet<RequiredCourseList> RequiredCourseLists { get; set; }
    public DbSet<RequiredCourseListCourse> RequiredCourseListCourses { get; set; }
    public DbSet<TopStudentList> TopStudentLists { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Önce temel konfigürasyonları uygula
        modelBuilder.ApplyConfiguration(new Persistence.EntityConfigurations.DepartmentConfiguration());
        modelBuilder.ApplyConfiguration(new Persistence.EntityConfigurations.FacultyDeansOfficeConfiguration());
        
        // Sonra Course konfigürasyonunu uygula
        modelBuilder.ApplyConfiguration(new Persistence.EntityConfigurations.CourseConfiguration());
        
        // Sonra RequiredCourseList konfigürasyonunu uygula
        modelBuilder.ApplyConfiguration(new Persistence.EntityConfigurations.RequiredCourseListConfiguration());
        
        // En son RequiredCourseListCourse konfigürasyonunu uygula
        modelBuilder.ApplyConfiguration(new Persistence.EntityConfigurations.RequiredCourseListCourseConfiguration());

        // Diğer konfigürasyonları uygula
        var configurations = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.Namespace == "Persistence.EntityConfigurations" 
                    && t != typeof(Persistence.EntityConfigurations.CourseConfiguration)
                    && t != typeof(Persistence.EntityConfigurations.RequiredCourseListConfiguration)
                    && t != typeof(Persistence.EntityConfigurations.RequiredCourseListCourseConfiguration)
                    && t != typeof(Persistence.EntityConfigurations.DepartmentConfiguration)
                    && t != typeof(Persistence.EntityConfigurations.FacultyDeansOfficeConfiguration))
            .ToList();

        foreach (var configuration in configurations)
        {
            if (configuration.GetInterfaces().Any(i => 
                i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
            {
                var config = Activator.CreateInstance(configuration);
                modelBuilder.ApplyConfiguration((dynamic)config);
            }
        }

        // UUID ve DateTime dönüşümlerini ayarla
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            // UUID ayarları
            var guidProperties = entityType.GetProperties().Where(p => p.ClrType == typeof(Guid));
            foreach (var property in guidProperties)
            {
                property.SetColumnType("uuid");
            }

            // DateTime ayarları
            var dateTimeProperties = entityType.GetProperties().Where(p => p.ClrType == typeof(DateTime));
            foreach (var property in dateTimeProperties)
            {
                property.SetValueConverter(
                    new ValueConverter<DateTime, DateTime>(
                        v => DateTime.SpecifyKind(v, DateTimeKind.Utc),
                        v => v
                    )
                );
            }
        }

        base.OnModelCreating(modelBuilder);
    }
}
