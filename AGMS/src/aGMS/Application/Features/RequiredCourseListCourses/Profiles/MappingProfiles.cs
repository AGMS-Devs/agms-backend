using Application.Features.RequiredCourseListCourses.Commands.Create;
using Application.Features.RequiredCourseListCourses.Commands.Delete;
using Application.Features.RequiredCourseListCourses.Commands.Update;
using Application.Features.RequiredCourseListCourses.Queries.GetById;
using Application.Features.RequiredCourseListCourses.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.RequiredCourseListCourses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateRequiredCourseListCourseCommand, RequiredCourseListCourse>();
        CreateMap<RequiredCourseListCourse, CreatedRequiredCourseListCourseResponse>();

        CreateMap<UpdateRequiredCourseListCourseCommand, RequiredCourseListCourse>();
        CreateMap<RequiredCourseListCourse, UpdatedRequiredCourseListCourseResponse>();

        CreateMap<DeleteRequiredCourseListCourseCommand, RequiredCourseListCourse>();
        CreateMap<RequiredCourseListCourse, DeletedRequiredCourseListCourseResponse>();

        CreateMap<RequiredCourseListCourse, GetByIdRequiredCourseListCourseResponse>();

        CreateMap<RequiredCourseListCourse, GetListRequiredCourseListCourseListItemDto>();
        CreateMap<IPaginate<RequiredCourseListCourse>, GetListResponse<GetListRequiredCourseListCourseListItemDto>>();
    }
}