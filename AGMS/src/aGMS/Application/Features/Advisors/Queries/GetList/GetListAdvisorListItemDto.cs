using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Advisors.Queries.GetList;

public class GetListAdvisorListItemDto : IDto
{
    public Guid Id { get; set; }
    public string DepartmentName { get; set; }
    public Guid DepartmentId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}