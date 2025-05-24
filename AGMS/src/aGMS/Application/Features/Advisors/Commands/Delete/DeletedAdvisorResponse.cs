using NArchitecture.Core.Application.Responses;

namespace Application.Features.Advisors.Commands.Delete;

public class DeletedAdvisorResponse : IResponse
{
    public Guid Id { get; set; }
}