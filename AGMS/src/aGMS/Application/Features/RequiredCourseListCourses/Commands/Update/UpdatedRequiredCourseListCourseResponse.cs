using NArchitecture.Core.Application.Responses;

namespace Application.Features.RequiredCourseListCourses.Commands.Update;

public class UpdatedRequiredCourseListCourseResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid RequiredCourseListId { get; set; }
    public Guid CourseId { get; set; }
}