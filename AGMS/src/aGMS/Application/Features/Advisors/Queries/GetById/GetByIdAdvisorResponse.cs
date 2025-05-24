using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Advisors.Queries.GetById;

public class GetByIdAdvisorResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Guid DepartmentId { get; set; }
    public string DepartmentName { get; set; }

}