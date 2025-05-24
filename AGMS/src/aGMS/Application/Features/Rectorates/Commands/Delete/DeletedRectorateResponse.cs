using NArchitecture.Core.Application.Responses;

namespace Application.Features.Rectorates.Commands.Delete;

public class DeletedRectorateResponse : IResponse
{
    public Guid Id { get; set; }
}