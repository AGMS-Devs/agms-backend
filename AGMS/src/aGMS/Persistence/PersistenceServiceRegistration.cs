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
        
        string connectionString;
        
        if (!string.IsNullOrWhiteSpace(databaseUrl))
        {
            // Convert DATABASE_URL to standard connection string if needed
            connectionString = ConvertDatabaseUrlToConnectionString(databaseUrl);
        }
        else if (!string.IsNullOrWhiteSpace(postgresConnectionString))
        {
            connectionString = postgresConnectionString;
        }
        else
        {
            throw new InvalidOperationException("No valid database connection string found. Check DATABASE_URL environment variable or ConnectionStrings:PostgreSql configuration.");
        }
        
        Console.WriteLine($"Final connection string: {connectionString ?? "NULL"}");
        Console.WriteLine($"Connection string length: {connectionString?.Length ?? 0}");
        
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
    
    private static string ConvertDatabaseUrlToConnectionString(string databaseUrl)
    {
        try
        {
            // If it's already in standard format, return as is
            if (databaseUrl.Contains("Host="))
            {
                return databaseUrl;
            }
            
            // Parse postgres://username:password@host:port/database format
            var uri = new Uri(databaseUrl);
            var host = uri.Host;
            var port = uri.Port > 0 ? uri.Port : 5432;
            var database = uri.PathAndQuery.TrimStart('/');
            var userInfo = uri.UserInfo.Split(':');
            var username = userInfo[0];
            var password = userInfo.Length > 1 ? userInfo[1] : "";
            
            return $"Host={host};Port={port};Database={database};Username={username};Password={password};";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error converting DATABASE_URL: {ex.Message}");
            return databaseUrl; // Return original if conversion fails
        }
    }
}
