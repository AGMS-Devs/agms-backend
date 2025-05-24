using NArchitecture.Core.Application.Dtos;

namespace Application.Features.RequiredCourseListCourses.Queries.GetList;

public class GetListRequiredCourseListCourseListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid RequiredCourseListId { get; set; }
    public Guid CourseId { get; set; }
}