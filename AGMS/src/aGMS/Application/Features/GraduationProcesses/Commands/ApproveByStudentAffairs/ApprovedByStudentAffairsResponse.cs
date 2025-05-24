using NArchitecture.Core.Application.Responses;

namespace Application.Features.GraduationProcesses.Commands.ApproveByStudentAffairs;

public class ApprovedByStudentAffairsResponse : IResponse
{
    public Guid Id { get; set; }
    public bool StudentAffairsApproved { get; set; }
    public DateTime StudentAffairsApprovedDate { get; set; }
    public Guid StudentId { get; set; }
    public Guid GraduationListId { get; set; }
} 