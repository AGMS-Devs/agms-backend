using NArchitecture.Core.Application.Responses;

namespace Application.Features.GraduationProcesses.Queries.GetById;

public class GetByIdGraduationProcessResponse : IResponse
{
    public Guid Id { get; set; }
    public bool AdvisorApproved { get; set; }
    public DateTime AdvisorApprovedDate { get; set; }
    public bool DepartmentSecretaryApproved { get; set; }
    public DateTime DepartmentSecretaryApprovedDate { get; set; }
    public bool FacultyDeansOfficeApproved { get; set; }
    public DateTime FacultyDeansOfficeApprovedDate { get; set; }
    public bool StudentAffairsApproved { get; set; }
    public DateTime StudentAffairsApprovedDate { get; set; }
    public Guid StudentId { get; set; }
    public Guid GraduationListId { get; set; }
}