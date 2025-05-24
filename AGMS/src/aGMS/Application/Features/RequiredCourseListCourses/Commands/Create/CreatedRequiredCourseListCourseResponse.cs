using NArchitecture.Core.Application.Responses;

namespace Application.Features.RequiredCourseListCourses.Commands.Create;

public class CreatedRequiredCourseListCourseResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid RequiredCourseListId { get; set; }
    public Guid CourseId { get; set; }
}