using NArchitecture.Core.Application.Dtos;

namespace Application.Features.GraduationProcesses.Queries.GetList;

public class GetListGraduationProcessListItemDto : IDto
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