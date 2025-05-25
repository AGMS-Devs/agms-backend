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
        var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL") 
                              ?? configuration.GetConnectionString("PostgreSql");
        
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
