using Application.Features.Messages.Commands.Create;
using Application.Features.Messages.Commands.Delete;
using Application.Features.Messages.Commands.Update;
using Application.Features.Messages.Queries.GetById;
using Application.Features.Messages.Queries.GetList;
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
            .ForMember(dest => dest.Sender, opt => opt.MapFrom(src => src.Sender))
            .ForMember(dest => dest.Receiver, opt => opt.MapFrom(src => src.Receiver));
            
        CreateMap<Message, UpdateMessageCommand>().ReverseMap();
        
        CreateMap<Message, UpdatedMessageResponse>()
            .ForMember(dest => dest.Sender, opt => opt.MapFrom(src => src.Sender))
            .ForMember(dest => dest.Receiver, opt => opt.MapFrom(src => src.Receiver));
            
        CreateMap<Message, DeleteMessageCommand>().ReverseMap();
        CreateMap<Message, DeletedMessageResponse>().ReverseMap();
        
        CreateMap<Message, GetByIdMessageResponse>()
            .ForMember(dest => dest.Sender, opt => opt.MapFrom(src => src.Sender))
            .ForMember(dest => dest.Receiver, opt => opt.MapFrom(src => src.Receiver));
            
        CreateMap<Message, GetListMessageListItemDto>()
            .ForMember(dest => dest.Sender, opt => opt.MapFrom(src => src.Sender))
            .ForMember(dest => dest.Receiver, opt => opt.MapFrom(src => src.Receiver));
            
        CreateMap<IPaginate<Message>, GetListResponse<GetListMessageListItemDto>>().ReverseMap();

        // User to DTO mappings
        CreateMap<User, SenderDto>();
        CreateMap<User, ReceiverDto>();
        CreateMap<Message, MessageDto>()
            .ForMember(dest => dest.Sender, opt => opt.MapFrom(src => src.Sender))
            .ForMember(dest => dest.Receiver, opt => opt.MapFrom(src => src.Receiver));
    }
}