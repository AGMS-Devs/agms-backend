using NArchitecture.Core.Application.Responses;

namespace Application.Features.RequiredCourseListCourses.Commands.Delete;

public class DeletedRequiredCourseListCourseResponse : IResponse
{
    public Guid Id { get; set; }
}