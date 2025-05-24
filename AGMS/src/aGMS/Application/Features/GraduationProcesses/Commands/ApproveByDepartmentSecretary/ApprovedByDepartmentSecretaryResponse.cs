using NArchitecture.Core.Application.Responses;

namespace Application.Features.GraduationProcesses.Commands.ApproveByDepartmentSecretary;

public class ApprovedByDepartmentSecretaryResponse : IResponse
{
    public Guid Id { get; set; }
    public bool DepartmentSecretaryApproved { get; set; }
    public DateTime DepartmentSecretaryApprovedDate { get; set; }
    public Guid StudentId { get; set; }
    public Guid GraduationListId { get; set; }
} 