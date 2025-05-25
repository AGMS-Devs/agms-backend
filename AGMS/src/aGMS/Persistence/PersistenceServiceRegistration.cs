using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Persistence.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Try DATABASE_URL first (Render standard), then fallback to PostgreSql
        var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
        var postgresConnectionString = configuration.GetConnectionString("PostgreSql");
        
        Console.WriteLine($"DATABASE_URL: {databaseUrl ?? "NULL"}");
        Console.WriteLine($"PostgreSql connection string: {postgresConnectionString ?? "NULL"}");
        
        var connectionString = (databaseUrl ?? postgresConnectionString)?.Trim();
        
        Console.WriteLine($"Final connection string: {connectionString ?? "NULL"}");
        Console.WriteLine($"Connection string length: {connectionString?.Length ?? 0}");
        
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("No valid database connection string found. Check DATABASE_URL environment variable or ConnectionStrings:PostgreSql configuration.");
        }
        
        services.AddDbContext<BaseDbContext>(options =>
            options.UseNpgsql(connectionString));
        services.AddDbMigrationApplier(buildServices => buildServices.GetRequiredService<BaseDbContext>());

        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IRectorateRepository, RectorateRepository>();
        services.AddScoped<IAdvisorRepository, AdvisorRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<IStaffRepository, StaffRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ITranscriptRepository, TranscriptRepository>();
        services.AddScoped<IFileAttachmentRepository, FileAttachmentRepository>();
        services.AddScoped<IFacultyDeansOfficeRepository, FacultyDeansOfficeRepository>();
        services.AddScoped<ITakenCourseRepository, TakenCourseRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<ICeremonyRepository, CeremonyRepository>();
        services.AddScoped<IMailLogRepository, MailLogRepository>();
        services.AddScoped<IStudentAffairRepository, StudentAffairRepository>();
        services.AddScoped<IGraduationProcessRepository, GraduationProcessRepository>();
        services.AddScoped<IGraduationListRepository, GraduationListRepository>();
        services.AddScoped<IRequiredCourseListRepository, RequiredCourseListRepository>();
        services.AddScoped<IRequiredCourseListCourseRepository, RequiredCourseListCourseRepository>();
        services.AddScoped<ITopStudentListRepository, TopStudentListRepository>();
        return services;
    }
}
