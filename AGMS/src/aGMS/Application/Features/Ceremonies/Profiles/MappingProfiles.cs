using Application.Features.Ceremonies.Commands.Create;
using Application.Features.Ceremonies.Commands.Delete;
using Application.Features.Ceremonies.Commands.Update;
using Application.Features.Ceremonies.Queries.GetById;
using Application.Features.Ceremonies.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Ceremonies.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Ceremony, CreateCeremonyCommand>().ReverseMap();
        CreateMap<Ceremony, CreatedCeremonyResponse>().ReverseMap();
        CreateMap<Ceremony, UpdateCeremonyCommand>().ReverseMap();
        CreateMap<Ceremony, UpdatedCeremonyResponse>().ReverseMap();
        CreateMap<Ceremony, DeleteCeremonyCommand>().ReverseMap();
        CreateMap<Ceremony, DeletedCeremonyResponse>().ReverseMap();
        CreateMap<Ceremony, GetByIdCeremonyResponse>().ReverseMap();
        CreateMap<Ceremony, GetListCeremonyListItemDto>().ReverseMap();
        CreateMap<IPaginate<Ceremony>, GetListResponse<GetListCeremonyListItemDto>>().ReverseMap();
    }
}