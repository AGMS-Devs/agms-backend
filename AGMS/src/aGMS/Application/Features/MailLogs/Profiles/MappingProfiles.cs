using Application.Features.MailLogs.Commands.Create;
using Application.Features.MailLogs.Commands.Delete;
using Application.Features.MailLogs.Commands.Update;
using Application.Features.MailLogs.Queries.GetById;
using Application.Features.MailLogs.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.MailLogs.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<MailLog, CreateMailLogCommand>().ReverseMap();
        CreateMap<MailLog, CreatedMailLogResponse>().ReverseMap();
        CreateMap<MailLog, UpdateMailLogCommand>().ReverseMap();
        CreateMap<MailLog, UpdatedMailLogResponse>().ReverseMap();
        CreateMap<MailLog, DeleteMailLogCommand>().ReverseMap();
        CreateMap<MailLog, DeletedMailLogResponse>().ReverseMap();
        CreateMap<MailLog, GetByIdMailLogResponse>().ReverseMap();
        CreateMap<MailLog, GetListMailLogListItemDto>().ReverseMap();
        CreateMap<IPaginate<MailLog>, GetListResponse<GetListMailLogListItemDto>>().ReverseMap();
    }
}