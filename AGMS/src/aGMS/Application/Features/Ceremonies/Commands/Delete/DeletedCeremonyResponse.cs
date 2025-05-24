using NArchitecture.Core.Application.Responses;

namespace Application.Features.Ceremonies.Commands.Delete;

public class DeletedCeremonyResponse : IResponse
{
    public Guid Id { get; set; }
}