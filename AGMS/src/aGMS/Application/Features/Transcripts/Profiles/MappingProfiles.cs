using Application.Features.Transcripts.Commands.Create;
using Application.Features.Transcripts.Commands.Delete;
using Application.Features.Transcripts.Commands.Update;
using Application.Features.Transcripts.Commands.UpdateTranscriptCalculations;
using Application.Features.Transcripts.Commands.UpdateAllTranscriptCalculations;
using Application.Features.Transcripts.Queries.GetById;
using Application.Features.Transcripts.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Transcripts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Transcript, CreateTranscriptCommand>().ReverseMap();
        CreateMap<Transcript, CreatedTranscriptResponse>().ReverseMap();
        CreateMap<Transcript, UpdateTranscriptCommand>().ReverseMap();
        CreateMap<Transcript, UpdatedTranscriptResponse>().ReverseMap();
        CreateMap<Transcript, UpdatedTranscriptCalculationsResponse>().ReverseMap();
        CreateMap<Transcript, DeleteTranscriptCommand>().ReverseMap();
        CreateMap<Transcript, DeletedTranscriptResponse>().ReverseMap();
        CreateMap<Transcript, GetByIdTranscriptResponse>().ReverseMap();
        CreateMap<Transcript, GetListTranscriptListItemDto>().ReverseMap();
        CreateMap<IPaginate<Transcript>, GetListResponse<GetListTranscriptListItemDto>>().ReverseMap();
    }
}