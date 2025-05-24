using Application.Features.FacultyDeansOffices.Commands.Create;
using Application.Features.FacultyDeansOffices.Commands.Delete;
using Application.Features.FacultyDeansOffices.Commands.Update;
using Application.Features.FacultyDeansOffices.Queries.GetById;
using Application.Features.FacultyDeansOffices.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.FacultyDeansOffices.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<FacultyDeansOffice, CreateFacultyDeansOfficeCommand>().ReverseMap();
        CreateMap<FacultyDeansOffice, CreatedFacultyDeansOfficeResponse>().ReverseMap();
        CreateMap<FacultyDeansOffice, UpdateFacultyDeansOfficeCommand>().ReverseMap();
        CreateMap<FacultyDeansOffice, UpdatedFacultyDeansOfficeResponse>().ReverseMap();
        CreateMap<FacultyDeansOffice, DeleteFacultyDeansOfficeCommand>().ReverseMap();
        CreateMap<FacultyDeansOffice, DeletedFacultyDeansOfficeResponse>().ReverseMap();
        
        CreateMap<FacultyDeansOffice, GetByIdFacultyDeansOfficeResponse>()
            .ForMember(dest => dest.Departments, opt => opt.MapFrom(src => src.Departments));
        
        CreateMap<FacultyDeansOffice, GetListFacultyDeansOfficeListItemDto>()
            .ForMember(dest => dest.Departments, opt => opt.MapFrom(src => src.Departments));
            
        CreateMap<Department, FacultyDepartmentDto>();
        
        CreateMap<IPaginate<FacultyDeansOffice>, GetListResponse<GetListFacultyDeansOfficeListItemDto>>().ReverseMap();
    }
}