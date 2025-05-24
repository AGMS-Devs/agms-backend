using Application.Features.GraduationLists.Commands.Create;
using Application.Features.GraduationLists.Commands.Delete;
using Application.Features.GraduationLists.Commands.Update;
using Application.Features.GraduationLists.Queries.GetById;
using Application.Features.GraduationLists.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.GraduationLists.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<GraduationList, CreateGraduationListCommand>().ReverseMap();
        CreateMap<GraduationList, CreatedGraduationListResponse>().ReverseMap();
        CreateMap<GraduationList, UpdateGraduationListCommand>().ReverseMap();
        CreateMap<GraduationList, UpdatedGraduationListResponse>().ReverseMap();
        CreateMap<GraduationList, DeleteGraduationListCommand>().ReverseMap();
        CreateMap<GraduationList, DeletedGraduationListResponse>().ReverseMap();
        CreateMap<GraduationList, GetByIdGraduationListResponse>().ReverseMap();
        CreateMap<GraduationList, GetListGraduationListListItemDto>().ReverseMap();
        CreateMap<IPaginate<GraduationList>, GetListResponse<GetListGraduationListListItemDto>>().ReverseMap();
    }
}