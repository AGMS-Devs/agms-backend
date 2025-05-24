using Application.Features.GraduationProcesses.Commands.Create;
using Application.Features.GraduationProcesses.Commands.Delete;
using Application.Features.GraduationProcesses.Commands.Update;
using Application.Features.GraduationProcesses.Commands.ApproveByAdvisor;
using Application.Features.GraduationProcesses.Commands.ApproveByDepartmentSecretary;
using Application.Features.GraduationProcesses.Commands.ApproveByFacultyDeansOffice;
using Application.Features.GraduationProcesses.Commands.ApproveByStudentAffairs;
using Application.Features.GraduationProcesses.Queries.GetById;
using Application.Features.GraduationProcesses.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.GraduationProcesses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<GraduationProcess, CreateGraduationProcessCommand>().ReverseMap();
        CreateMap<GraduationProcess, CreatedGraduationProcessResponse>().ReverseMap();
        CreateMap<GraduationProcess, UpdateGraduationProcessCommand>().ReverseMap();
        CreateMap<GraduationProcess, UpdatedGraduationProcessResponse>().ReverseMap();
        CreateMap<GraduationProcess, DeleteGraduationProcessCommand>().ReverseMap();
        CreateMap<GraduationProcess, DeletedGraduationProcessResponse>().ReverseMap();
        CreateMap<GraduationProcess, GetByIdGraduationProcessResponse>().ReverseMap();
        CreateMap<GraduationProcess, GetListGraduationProcessListItemDto>().ReverseMap();
        CreateMap<IPaginate<GraduationProcess>, GetListResponse<GetListGraduationProcessListItemDto>>().ReverseMap();

        // Approval mappings
        CreateMap<GraduationProcess, ApprovedByAdvisorResponse>().ReverseMap();
        CreateMap<GraduationProcess, ApprovedByDepartmentSecretaryResponse>().ReverseMap();
        CreateMap<GraduationProcess, ApprovedByFacultyDeansOfficeResponse>().ReverseMap();
        CreateMap<GraduationProcess, ApprovedByStudentAffairsResponse>().ReverseMap();
    }
}