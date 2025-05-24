using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Advisors.Commands.Create;

public class CreatedAdvisorResponse : IResponse
{
    public Guid Id { get; set; }
    public Department Department { get; set; }
    public Guid DepartmentId { get; set; }
}