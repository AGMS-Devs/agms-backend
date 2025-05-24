using NArchitecture.Core.Application.Dtos;
using Domain.Entities;

namespace Application.Features.GraduationLists.Queries.GetList;

public class GetListGraduationListListItemDto : IDto
{
    public Guid Id { get; set; }
    public string GraduationListNumber { get; set; }
    public Guid AdvisorId { get; set; }
    public Advisor Advisor { get; set; }
}