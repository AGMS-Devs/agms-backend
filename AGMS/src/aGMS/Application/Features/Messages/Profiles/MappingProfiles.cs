using Application.Features.Messages.Commands.Create;
using Application.Features.Messages.Commands.Delete;
using Application.Features.Messages.Commands.Update;
using Application.Features.Messages.Queries.GetById;
using Application.Features.Messages.Queries.GetList;
using Application.Features.Messages.Queries.GetStudentMessages;
using Application.Features.Messages.Dtos;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Messages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Message, CreateMessageCommand>().ReverseMap();
        
        CreateMap<Message, CreatedMessageResponse>()
            .ForMember(dest => dest.Advisor, opt => opt.MapFrom(src => src.Advisor));
            
        CreateMap<Message, UpdateMessageCommand>().ReverseMap();
        
        CreateMap<Message, UpdatedMessageResponse>()
            .ForMember(dest => dest.Advisor, opt => opt.MapFrom(src => src.Advisor));
            
        CreateMap<Message, DeleteMessageCommand>().ReverseMap();
        CreateMap<Message, DeletedMessageResponse>().ReverseMap();
        
        CreateMap<Message, GetByIdMessageResponse>()
            .ForMember(dest => dest.Advisor, opt => opt.MapFrom(src => src.Advisor));
            
        CreateMap<Message, GetListMessageListItemDto>()
            .ForMember(dest => dest.Advisor, opt => opt.MapFrom(src => src.Advisor));

        CreateMap<Message, GetStudentMessagesListItemDto>()
            .ForMember(dest => dest.Advisor, opt => opt.MapFrom(src => src.Advisor));
            
        CreateMap<IPaginate<Message>, GetListResponse<GetListMessageListItemDto>>().ReverseMap();
        CreateMap<IPaginate<Message>, GetListResponse<GetStudentMessagesListItemDto>>().ReverseMap();

        // Advisor to DTO mappings
        CreateMap<Advisor, AdvisorDto>();
        CreateMap<Message, MessageDto>()
            .ForMember(dest => dest.Advisor, opt => opt.MapFrom(src => src.Advisor));
    }
}