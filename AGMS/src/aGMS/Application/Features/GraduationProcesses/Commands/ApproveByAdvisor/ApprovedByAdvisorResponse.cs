using NArchitecture.Core.Application.Responses;

namespace Application.Features.GraduationProcesses.Commands.ApproveByAdvisor;

public class ApprovedByAdvisorResponse : IResponse
{
    public Guid Id { get; set; }
    public bool AdvisorApproved { get; set; }
    public DateTime AdvisorApprovedDate { get; set; }
    public Guid StudentId { get; set; }
    public Guid GraduationListId { get; set; }
} 