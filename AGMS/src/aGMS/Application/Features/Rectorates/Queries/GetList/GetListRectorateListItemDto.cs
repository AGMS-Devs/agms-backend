using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Rectorates.Queries.GetList;

public class GetListRectorateListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid StudentAffairId { get; set; }
    public StudentAffair StudentAffair { get; set; }
}