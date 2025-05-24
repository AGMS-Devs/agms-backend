using NArchitecture.Core.Application.Responses;

namespace Application.Features.RequiredCourseLists.Commands.Delete;

public class DeletedRequiredCourseListResponse : IResponse
{
    public Guid Id { get; set; }
}