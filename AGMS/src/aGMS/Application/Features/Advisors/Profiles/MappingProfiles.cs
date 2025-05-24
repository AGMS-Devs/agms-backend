using Application.Features.Advisors.Commands.Create;
using Application.Features.Advisors.Commands.Delete;
using Application.Features.Advisors.Commands.Update;
using Application.Features.Advisors.Queries.GetById;
using Application.Features.Advisors.Queries.GetList;
using Application.Features.Advisors.Queries.GetAdvisorStudents;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Advisors.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Advisor, CreateAdvisorCommand>().ReverseMap();
        CreateMap<Advisor, CreatedAdvisorResponse>().ReverseMap();
        CreateMap<Advisor, UpdateAdvisorCommand>().ReverseMap();
        CreateMap<Advisor, UpdatedAdvisorResponse>().ReverseMap();
        CreateMap<Advisor, DeleteAdvisorCommand>().ReverseMap();
        CreateMap<Advisor, DeletedAdvisorResponse>().ReverseMap();
        
        CreateMap<Advisor, GetByIdAdvisorResponse>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User != null ? src.User.Name : null))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.User != null ? src.User.Surname : null))
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department != null ? src.Department.DepartmentName : null));
        
        CreateMap<Advisor, GetListAdvisorListItemDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User != null ? src.User.Name : null))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.User != null ? src.User.Surname : null))
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department != null ? src.Department.DepartmentName : null));

        CreateMap<Student, GetAdvisorStudentsResponse>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User != null ? src.User.Name : null))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.User != null ? src.User.Surname : null))
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department != null ? src.Department.DepartmentName : null));
        
        CreateMap<IPaginate<Student>, GetListResponse<GetAdvisorStudentsResponse>>().ReverseMap();
        CreateMap<IPaginate<Advisor>, GetListResponse<GetListAdvisorListItemDto>>().ReverseMap();
    }
}