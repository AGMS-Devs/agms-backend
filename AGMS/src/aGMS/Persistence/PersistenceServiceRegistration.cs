using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Persistence.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using System;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = GetConnectionString(configuration);
        
        Console.WriteLine($"Using connection string: {MaskConnectionString(connectionString)}");
        
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
    
    private static string GetConnectionString(IConfiguration configuration)
    {
        // 1. DATABASE_URL environment variable (Render standard)
        var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
        if (!string.IsNullOrWhiteSpace(databaseUrl))
        {
            Console.WriteLine("Found DATABASE_URL environment variable");
            return ParseDatabaseUrl(databaseUrl.Trim());
        }
        
        // 2. Render PostgreSQL environment variables
        var pgHost = Environment.GetEnvironmentVariable("PGHOST");
        var pgPort = Environment.GetEnvironmentVariable("PGPORT");
        var pgDatabase = Environment.GetEnvironmentVariable("PGDATABASE");
        var pgUser = Environment.GetEnvironmentVariable("PGUSER");
        var pgPassword = Environment.GetEnvironmentVariable("PGPASSWORD");
        
        if (!string.IsNullOrWhiteSpace(pgHost) && !string.IsNullOrWhiteSpace(pgDatabase))
        {
            Console.WriteLine("Found Render PostgreSQL environment variables");
            return $"Host={pgHost};Port={pgPort ?? "5432"};Database={pgDatabase};Username={pgUser};Password={pgPassword};SSL Mode=Require;Trust Server Certificate=true;";
        }
        
        // 3. Configuration'dan PostgreSql connection string
        var postgresConnectionString = configuration.GetConnectionString("PostgreSql");
        if (!string.IsNullOrWhiteSpace(postgresConnectionString))
        {
            Console.WriteLine("Using PostgreSql connection string from configuration");
            return postgresConnectionString.Trim();
        }
        
        // 4. Heroku style DATABASE_URL
        var herokuDatabaseUrl = Environment.GetEnvironmentVariable("HEROKU_POSTGRESQL_DATABASE_URL");
        if (!string.IsNullOrWhiteSpace(herokuDatabaseUrl))
        {
            Console.WriteLine("Found Heroku DATABASE_URL");
            return ParseDatabaseUrl(herokuDatabaseUrl.Trim());
        }
        
        Console.WriteLine("No connection string found");
        return null;
    }
    
    private static string ParseDatabaseUrl(string databaseUrl)
    {
        try
        {
            // postgres://username:password@host:port/database
            if (!databaseUrl.StartsWith("postgres://") && !databaseUrl.StartsWith("postgresql://"))
            {
                // Eğer normal connection string formatındaysa direkt döndür
                if (databaseUrl.Contains("Host=") || databaseUrl.Contains("host="))
                {
                    return databaseUrl;
                }
                throw new ArgumentException("Database URL must start with postgres:// or postgresql://");
            }
            
            var uri = new Uri(databaseUrl);
            var host = uri.Host;
            var port = uri.Port == -1 ? 5432 : uri.Port;
            var database = uri.LocalPath.TrimStart('/');
            var username = uri.UserInfo.Split(':')[0];
            var password = uri.UserInfo.Split(':')[1];
            
            return $"Host={host};Port={port};Database={database};Username={username};Password={password};SSL Mode=Require;Trust Server Certificate=true;";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error parsing DATABASE_URL: {ex.Message}");
            Console.WriteLine($"Raw DATABASE_URL: {databaseUrl}");
            throw new ArgumentException($"Invalid DATABASE_URL format: {ex.Message}", ex);
        }
    }
    
    private static string MaskConnectionString(string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
            return "NULL";
            
        // Password'u mask'le
        return System.Text.RegularExpressions.Regex.Replace(
            connectionString, 
            @"Password=([^;]+)", 
            "Password=***", 
            System.Text.RegularExpressions.RegexOptions.IgnoreCase
        );
    }
}
