using Application.Features.RequiredCourseLists.Commands.Create;
using Application.Features.RequiredCourseLists.Commands.Delete;
using Application.Features.RequiredCourseLists.Commands.Update;
using Application.Features.RequiredCourseLists.Queries.GetById;
using Application.Features.RequiredCourseLists.Queries.GetList;
using Application.Features.RequiredCourseLists.Queries.GetByStudent;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Courses.Queries.GetById;
using Application.Features.Courses.Queries.GetList;
using Application.Features.RequiredCourseLists.Queries.GetUncompletedCourses;

namespace Application.Features.RequiredCourseLists.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateRequiredCourseListCommand, RequiredCourseList>()
            .ForMember(dest => dest.Courses, opt => opt.Ignore());
        CreateMap<RequiredCourseList, CreatedRequiredCourseListResponse>()
            .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Courses));

        CreateMap<UpdateRequiredCourseListCommand, RequiredCourseList>()
            .ForMember(dest => dest.Courses, opt => opt.Ignore());
        CreateMap<RequiredCourseList, UpdatedRequiredCourseListResponse>()
            .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Courses));

        CreateMap<DeleteRequiredCourseListCommand, RequiredCourseList>();
        CreateMap<RequiredCourseList, DeletedRequiredCourseListResponse>();

        CreateMap<RequiredCourseList, GetByIdRequiredCourseListResponse>()
            .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Courses));

        CreateMap<RequiredCourseList, GetListRequiredCourseListListItemDto>()
            .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Courses));
        CreateMap<IPaginate<RequiredCourseList>, GetListResponse<GetListRequiredCourseListListItemDto>>();

        CreateMap<Course, GetByIdCourseResponse>();
        CreateMap<Course, GetListCourseListItemDto>();

        CreateMap<Course, UncompletedCourseDto>()
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.CourseCode))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CourseName))
            .ForMember(dest => dest.Credit, opt => opt.MapFrom(src => src.CourseCredit))
            .ForMember(dest => dest.IsCompulsory, opt => opt.MapFrom(src => true))
            .ForMember(dest => dest.Semester, opt => opt.MapFrom(src => src.HalfYear));

        CreateMap<Course, RequiredCourseDto>()
            .ForMember(dest => dest.CourseCode, opt => opt.MapFrom(src => src.CourseCode))
            .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.CourseName))
            .ForMember(dest => dest.CourseCredit, opt => opt.MapFrom(src => src.CourseCredit))
            .ForMember(dest => dest.HalfYear, opt => opt.MapFrom(src => src.HalfYear))
            .ForMember(dest => dest.CourseDescription, opt => opt.MapFrom(src => src.CourseDescription))
            .ForMember(dest => dest.TeoricHours, opt => opt.MapFrom(src => src.TeoricHours))
            .ForMember(dest => dest.PracticalHours, opt => opt.MapFrom(src => src.PracticalHours))
            .ForMember(dest => dest.ECTS, opt => opt.MapFrom(src => src.ECTS));
    }
}