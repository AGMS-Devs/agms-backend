using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Rectorates.Commands.Create;

public class CreatedRectorateResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StudentAffairId { get; set; }
    public StudentAffair StudentAffair { get; set; }
}