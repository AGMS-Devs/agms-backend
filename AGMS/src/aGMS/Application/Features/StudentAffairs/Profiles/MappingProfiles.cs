using Application.Features.StudentAffairs.Commands.Create;
using Application.Features.StudentAffairs.Commands.Delete;
using Application.Features.StudentAffairs.Commands.Update;
using Application.Features.StudentAffairs.Queries.GetById;
using Application.Features.StudentAffairs.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.StudentAffairs.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<StudentAffair, CreateStudentAffairsCommand>().ReverseMap();
        CreateMap<StudentAffair, CreatedStudentAffairsResponse>().ReverseMap();
        CreateMap<StudentAffair, UpdateStudentAffairsCommand>().ReverseMap();
        CreateMap<StudentAffair, UpdatedStudentAffairsResponse>().ReverseMap();
        CreateMap<StudentAffair, DeleteStudentAffairsCommand>().ReverseMap();
        CreateMap<StudentAffair, DeletedStudentAffairsResponse>().ReverseMap();
        CreateMap<StudentAffair, GetByIdStudentAffairsResponse>().ReverseMap();
        CreateMap<StudentAffair, GetListStudentAffairsListItemDto>().ReverseMap();
        CreateMap<IPaginate<StudentAffair>, GetListResponse<GetListStudentAffairsListItemDto>>().ReverseMap();
    }
}