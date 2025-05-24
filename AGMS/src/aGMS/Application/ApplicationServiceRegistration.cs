using System.Reflection;
using Application.Services.AuthenticatorService;
using Application.Services.AuthService;
using Application.Services.UsersService;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using NArchitecture.Core.Application.Pipelines.Validation;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Abstraction;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Configurations;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Serilog.File;
using NArchitecture.Core.ElasticSearch;
using NArchitecture.Core.ElasticSearch.Models;
using NArchitecture.Core.Localization.Resource.Yaml.DependencyInjection;
using NArchitecture.Core.Mailing;
using NArchitecture.Core.Mailing.MailKit;
using NArchitecture.Core.Security.DependencyInjection;
using NArchitecture.Core.Security.JWT;
using Application.Services.Students;
using Application.Services.Rectorates;
using Application.Services.Advisors;
using Application.Services.Messages;
using Application.Services.Staffs;
using Application.Services.Courses;
using Application.Services.Transcripts;
using Application.Services.FileAttachments;
using Application.Services.FacultyDeansOffices;
using Application.Services.TakenCourses;
using Application.Services.Departments;
using Application.Services.Ceremonies;
using Application.Services.MailLogs;
using Application.Services.StudentAffairs;
using Application.Services.GraduationProcesses;
using Application.Services.GraduationLists;
using Application.Services.RequiredCourseLists;
using Application.Services.RequiredCourseListCourses;
using Application.Services.TopStudentLists;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        MailSettings mailSettings,
        FileLogConfiguration fileLogConfiguration,
        ElasticSearchConfig elasticSearchConfig,
        TokenOptions tokenOptions
    )
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddSingleton<IMailService, MailKitMailService>(_ => new MailKitMailService(mailSettings));

        services.AddSingleton<ILogger, SerilogFileLogger>(_ => new SerilogFileLogger(fileLogConfiguration));
        services.AddSingleton<IElasticSearch, ElasticSearchManager>(_ => new ElasticSearchManager(elasticSearchConfig));

        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IAuthenticatorService, AuthenticatorManager>();
        services.AddScoped<IUserService, UserManager>();
        services.AddYamlResourceLocalization();

        services.AddSecurityServices<Guid, Guid, Guid>(tokenOptions);

        services.AddScoped<IStudentService, StudentManager>();
        services.AddScoped<IRectorateService, RectorateManager>();
        services.AddScoped<IAdvisorService, AdvisorManager>();
        services.AddScoped<IMessageService, MessageManager>();
        services.AddScoped<IStaffService, StaffManager>();
        services.AddScoped<ICourseService, CourseManager>();
        services.AddScoped<ITranscriptService, TranscriptManager>();
        services.AddScoped<IFileAttachmentService, FileAttachmentManager>();
        services.AddScoped<IFacultyDeansOfficeService, FacultyDeansOfficeManager>();
        services.AddScoped<ITakenCourseService, TakenCourseManager>();
        services.AddScoped<IDepartmentService, DepartmentManager>();
        services.AddScoped<ICeremonyService, CeremonyManager>();
        services.AddScoped<IMailLogService, MailLogManager>();
        services.AddScoped<IStudentAffairService, StudentAffairsManager>();
        services.AddScoped<IGraduationProcessService, GraduationProcessManager>();
        services.AddScoped<IGraduationListService, GraduationListManager>();
        services.AddScoped<IRequiredCourseListService, RequiredCourseListManager>();
        services.AddScoped<IRequiredCourseListCourseService, RequiredCourseListCourseManager>();
        services.AddScoped<ITopStudentListService, TopStudentListManager>();
        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (Type? item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}
