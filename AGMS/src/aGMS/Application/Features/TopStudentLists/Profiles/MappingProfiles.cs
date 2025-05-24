using Application.Features.TopStudentLists.Commands.Create;
using Application.Features.TopStudentLists.Commands.Delete;
using Application.Features.TopStudentLists.Commands.Update;
using Application.Features.TopStudentLists.Commands.ApproveStudentAffairs;
using Application.Features.TopStudentLists.Commands.SendToRectorate;
using Application.Features.TopStudentLists.Commands.ApproveRectorate;
using Application.Features.TopStudentLists.Queries.GetById;
using Application.Features.TopStudentLists.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.TopStudentLists.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Create command için manuel mapping yapıldığı için CreateMap'e gerek yok
        // CreateMap<CreateTopStudentListCommand, TopStudentList>();
        
        CreateMap<TopStudentList, CreatedTopStudentListResponse>()
            .ForMember(dest => dest.StudentCount, opt => opt.Ignore()); // StudentCount manuel olarak set ediliyor

        CreateMap<UpdateTopStudentListCommand, TopStudentList>();
        CreateMap<TopStudentList, UpdatedTopStudentListResponse>();

        CreateMap<DeleteTopStudentListCommand, TopStudentList>();
        CreateMap<TopStudentList, DeletedTopStudentListResponse>();

        // Approval mappings
        CreateMap<TopStudentList, ApprovedStudentAffairsResponse>();
        CreateMap<TopStudentList, SentToRectorateResponse>();
        CreateMap<TopStudentList, ApprovedRectorateResponse>();

        CreateMap<TopStudentList, GetByIdTopStudentListResponse>()
            .ForMember(dest => dest.Students, opt => opt.Ignore()) // Students manuel olarak doldurulacak
            .ForMember(dest => dest.StudentCount, opt => opt.Ignore()); // StudentCount manuel olarak set ediliyor

        CreateMap<TopStudentList, GetListTopStudentListListItemDto>()
            .ForMember(dest => dest.Students, opt => opt.Ignore()) // Students manuel olarak doldurulacak
            .ForMember(dest => dest.StudentCount, opt => opt.Ignore()); // StudentCount manuel olarak set ediliyor
            
        CreateMap<IPaginate<TopStudentList>, GetListResponse<GetListTopStudentListListItemDto>>();
    }
}