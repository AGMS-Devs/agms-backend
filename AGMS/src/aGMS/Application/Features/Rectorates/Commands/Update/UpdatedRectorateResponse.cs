using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Rectorates.Commands.Update;

public class UpdatedRectorateResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StudentAffairId { get; set; }
    public StudentAffair StudentAffair { get; set; }
}