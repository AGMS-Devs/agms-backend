using NArchitecture.Core.Application.Responses;

namespace Application.Features.RequiredCourseListCourses.Queries.GetById;

public class GetByIdRequiredCourseListCourseResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid RequiredCourseListId { get; set; }
    public Guid CourseId { get; set; }
}