using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.GraduationLists.Commands.Create;

public class CreatedGraduationListResponse : IResponse
{
    public Guid Id { get; set; }
    public string GraduationListNumber { get; set; }
    public Guid AdvisorId { get; set; }
    public Advisor Advisor { get; set; }
}