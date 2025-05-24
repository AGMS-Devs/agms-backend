using NArchitecture.Core.Application.Responses;
using Application.Features.Courses.Queries.GetById;

namespace Application.Features.RequiredCourseLists.Commands.Create;

public class CreatedRequiredCourseListResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<GetByIdCourseResponse> Courses { get; set; }
}