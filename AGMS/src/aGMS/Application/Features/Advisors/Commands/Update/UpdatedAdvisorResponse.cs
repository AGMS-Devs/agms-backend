using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Advisors.Commands.Update;

public class UpdatedAdvisorResponse : IResponse
{
    public Guid Id { get; set; }
    public Department Department { get; set; }
    public Guid DepartmentId { get; set; }
}