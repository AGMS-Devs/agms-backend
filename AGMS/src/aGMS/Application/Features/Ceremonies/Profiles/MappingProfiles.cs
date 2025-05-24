using Application.Features.Ceremonies.Commands.Create;
using Application.Features.Ceremonies.Commands.Delete;
using Application.Features.Ceremonies.Commands.Update;
using Application.Features.Ceremonies.Queries.GetById;
using Application.Features.Ceremonies.Queries.GetList;
using Application.Features.Ceremonies.Dtos;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Ceremonies.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCeremonyCommand, Ceremony>()
            .ForMember(dest => dest.StudentAffairId, opt => opt.MapFrom(src => src.StudentAffairsId))
            .ForMember(dest => dest.StudentAffair, opt => opt.Ignore())
            .ForMember(dest => dest.StudentUsers, opt => opt.Ignore());
        
        CreateMap<Ceremony, CreatedCeremonyResponse>()
            .ForMember(dest => dest.StudentAffairsId, opt => opt.MapFrom(src => src.StudentAffairId))
            .ForMember(dest => dest.StudentUsers, opt => opt.MapFrom(src => src.StudentUsers));
        
        CreateMap<UpdateCeremonyCommand, Ceremony>()
            .ForMember(dest => dest.StudentAffairId, opt => opt.MapFrom(src => src.StudentAffairsId))
            .ForMember(dest => dest.StudentAffair, opt => opt.Ignore());
        
        CreateMap<Ceremony, UpdatedCeremonyResponse>()
            .ForMember(dest => dest.StudentAffairsId, opt => opt.MapFrom(src => src.StudentAffairId))
            .ForMember(dest => dest.StudentUsers, opt => opt.MapFrom(src => src.StudentUsers));
        
        CreateMap<Ceremony, DeleteCeremonyCommand>().ReverseMap();
        CreateMap<Ceremony, DeletedCeremonyResponse>().ReverseMap();
        
        CreateMap<Ceremony, GetByIdCeremonyResponse>()
            .ForMember(dest => dest.StudentAffairsId, opt => opt.MapFrom(src => src.StudentAffairId))
            .ForMember(dest => dest.StudentUsers, opt => opt.MapFrom(src => src.StudentUsers));
        
        CreateMap<Ceremony, GetListCeremonyListItemDto>()
            .ForMember(dest => dest.StudentAffairsId, opt => opt.MapFrom(src => src.StudentAffairId))
            .ForMember(dest => dest.StudentUsers, opt => opt.MapFrom(src => src.StudentUsers));
        
        CreateMap<IPaginate<Ceremony>, GetListResponse<GetListCeremonyListItemDto>>().ReverseMap();

        // User to StudentUserDto mapping
        CreateMap<User, StudentUserDto>();
    }
}