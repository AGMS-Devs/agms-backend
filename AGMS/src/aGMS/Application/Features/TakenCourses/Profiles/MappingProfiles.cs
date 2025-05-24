using Application.Features.TakenCourses.Commands.Create;
using Application.Features.TakenCourses.Commands.Delete;
using Application.Features.TakenCourses.Commands.Update;
using Application.Features.TakenCourses.Queries.GetById;
using Application.Features.TakenCourses.Queries.GetList;
using Application.Features.TakenCourses.Queries.GetByStudent;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.TakenCourses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<TakenCourse, CreateTakenCourseCommand>().ReverseMap();
        CreateMap<TakenCourse, CreatedTakenCourseResponse>().ReverseMap();
        CreateMap<TakenCourse, UpdateTakenCourseCommand>().ReverseMap();
        CreateMap<TakenCourse, UpdatedTakenCourseResponse>().ReverseMap();
        CreateMap<TakenCourse, DeleteTakenCourseCommand>().ReverseMap();
        CreateMap<TakenCourse, DeletedTakenCourseResponse>().ReverseMap();
        CreateMap<TakenCourse, GetByIdTakenCourseResponse>().ReverseMap();
        CreateMap<TakenCourse, GetListTakenCourseListItemDto>().ReverseMap();
        CreateMap<IPaginate<TakenCourse>, GetListResponse<GetListTakenCourseListItemDto>>().ReverseMap();

        CreateMap<TakenCourse, TakenCourseDto>()
            .ForMember(dest => dest.CourseCode, opt => opt.MapFrom(src => src.Course.CourseCode))
            .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.CourseName))
            .ForMember(dest => dest.CourseCredit, opt => opt.MapFrom(src => src.Course.CourseCredit))
            .ForMember(dest => dest.HalfYear, opt => opt.MapFrom(src => src.Course.HalfYear));
    }
}