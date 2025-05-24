using Application.Features.Rectorates.Commands.Create;
using Application.Features.Rectorates.Commands.Delete;
using Application.Features.Rectorates.Commands.Update;
using Application.Features.Rectorates.Queries.GetById;
using Application.Features.Rectorates.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Rectorates.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Rectorate, CreateRectorateCommand>().ReverseMap();
        CreateMap<Rectorate, CreatedRectorateResponse>().ReverseMap();
        CreateMap<Rectorate, UpdateRectorateCommand>().ReverseMap();
        CreateMap<Rectorate, UpdatedRectorateResponse>().ReverseMap();
        CreateMap<Rectorate, DeleteRectorateCommand>().ReverseMap();
        CreateMap<Rectorate, DeletedRectorateResponse>().ReverseMap();
        CreateMap<Rectorate, GetByIdRectorateResponse>().ReverseMap();
        CreateMap<Rectorate, GetListRectorateListItemDto>().ReverseMap();
        CreateMap<IPaginate<Rectorate>, GetListResponse<GetListRectorateListItemDto>>().ReverseMap();
    }
}