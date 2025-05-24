using NArchitecture.Core.Application.Dtos;
using Application.Features.Courses.Queries.GetList;

namespace Application.Features.RequiredCourseLists.Queries.GetList;

public class GetListRequiredCourseListListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<GetListCourseListItemDto> Courses { get; set; }
}