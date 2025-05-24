using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Rectorates.Queries.GetById;

public class GetByIdRectorateResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StudentAffairId { get; set; }
    public StudentAffair StudentAffair { get; set; }
}