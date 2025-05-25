using Application.Features.Students.Commands.Create;
using Application.Features.Students.Commands.Delete;
using Application.Features.Students.Commands.Update;
using Application.Features.Students.Queries.GetById;
using Application.Features.Students.Queries.GetList;
using Application.Features.Students.Queries.GetStudentsByDepartment;
using Application.Features.Students.Queries.GetStudentsByFaculty;
using Application.Features.Students.Queries.GetAllStudents;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Students.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Student, CreateStudentCommand>().ReverseMap();
        CreateMap<Student, CreatedStudentResponse>().ReverseMap();
        CreateMap<Student, UpdateStudentCommand>().ReverseMap();
        CreateMap<Student, UpdatedStudentResponse>().ReverseMap();
        CreateMap<Student, DeleteStudentCommand>().ReverseMap();
        CreateMap<Student, DeletedStudentResponse>().ReverseMap();
        
        CreateMap<Student, GetByIdStudentResponse>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User != null ? src.User.Name : null))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.User != null ? src.User.Surname : null))
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department != null ? src.Department.DepartmentName : null))
            .ForMember(dest => dest.AdvisorName, opt => opt.MapFrom(src => src.AssignedAdvisor != null && src.AssignedAdvisor.User != null ? src.AssignedAdvisor.User.Name : null))
            .ForMember(dest => dest.AdvisorSurname, opt => opt.MapFrom(src => src.AssignedAdvisor != null && src.AssignedAdvisor.User != null ? src.AssignedAdvisor.User.Surname : null));
        
        CreateMap<Student, GetListStudentListItemDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User != null ? src.User.Name : null))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.User != null ? src.User.Surname : null))
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department != null ? src.Department.DepartmentName : null))
            .ForMember(dest => dest.AdvisorName, opt => opt.MapFrom(src => src.AssignedAdvisor != null && src.AssignedAdvisor.User != null ? src.AssignedAdvisor.User.Name : null))
            .ForMember(dest => dest.AdvisorSurname, opt => opt.MapFrom(src => src.AssignedAdvisor != null && src.AssignedAdvisor.User != null ? src.AssignedAdvisor.User.Surname : null));

        CreateMap<Student, GetStudentsByDepartmentListItemDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User != null ? src.User.Name : null))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.User != null ? src.User.Surname : null))
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department != null ? src.Department.DepartmentName : null))
            .ForMember(dest => dest.AdvisorName, opt => opt.MapFrom(src => src.AssignedAdvisor != null && src.AssignedAdvisor.User != null ? src.AssignedAdvisor.User.Name : null))
            .ForMember(dest => dest.AdvisorSurname, opt => opt.MapFrom(src => src.AssignedAdvisor != null && src.AssignedAdvisor.User != null ? src.AssignedAdvisor.User.Surname : null));

        CreateMap<Student, GetStudentsByFacultyListItemDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User != null ? src.User.Name : null))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.User != null ? src.User.Surname : null))
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department != null ? src.Department.DepartmentName : null))
            .ForMember(dest => dest.AdvisorName, opt => opt.MapFrom(src => src.AssignedAdvisor != null && src.AssignedAdvisor.User != null ? src.AssignedAdvisor.User.Name : null))
            .ForMember(dest => dest.AdvisorSurname, opt => opt.MapFrom(src => src.AssignedAdvisor != null && src.AssignedAdvisor.User != null ? src.AssignedAdvisor.User.Surname : null));

        CreateMap<Student, GetAllStudentsListItemDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User != null ? src.User.Name : null))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.User != null ? src.User.Surname : null))
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department != null ? src.Department.DepartmentName : null))
            .ForMember(dest => dest.AdvisorName, opt => opt.MapFrom(src => src.AssignedAdvisor != null && src.AssignedAdvisor.User != null ? src.AssignedAdvisor.User.Name : null))
            .ForMember(dest => dest.AdvisorSurname, opt => opt.MapFrom(src => src.AssignedAdvisor != null && src.AssignedAdvisor.User != null ? src.AssignedAdvisor.User.Surname : null));
        
        CreateMap<IPaginate<Student>, GetListResponse<GetListStudentListItemDto>>().ReverseMap();
        CreateMap<IPaginate<Student>, GetListResponse<GetStudentsByDepartmentListItemDto>>().ReverseMap();
        CreateMap<IPaginate<Student>, GetListResponse<GetStudentsByFacultyListItemDto>>().ReverseMap();
    }
}