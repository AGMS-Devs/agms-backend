using NArchitecture.Core.Application.Responses;

namespace Application.Features.GraduationProcesses.Commands.ApproveByFacultyDeansOffice;

public class ApprovedByFacultyDeansOfficeResponse : IResponse
{
    public Guid Id { get; set; }
    public bool FacultyDeansOfficeApproved { get; set; }
    public DateTime FacultyDeansOfficeApprovedDate { get; set; }
    public Guid StudentId { get; set; }
    public Guid GraduationListId { get; set; }
} 