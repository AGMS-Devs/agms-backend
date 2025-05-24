using NArchitecture.Core.Application.Responses;
using Domain.Enums;
namespace Application.Features.TopStudentLists.Queries.GetById;

public class GetByIdTopStudentListResponse : IResponse
{
    public Guid Id { get; set; }

    public TopStudentListType TopStudentListType { get; set; }
    public bool StudentAffairsApproval { get; set; }
    public Guid StudentAffairsStaffId { get; set; }
    public bool RectorateApproval { get; set; }
    public Guid RectorateStaffId { get; set; }
    public bool SendRectorate { get; set; }
    public int StudentCount { get; set; }
    public List<TopStudentDto> Students { get; set; } = new List<TopStudentDto>();
}

public class TopStudentDto
{
    public Guid StudentId { get; set; }
    public string StudentNumber { get; set; }
    public string StudentName { get; set; }
    public string StudentSurname { get; set; }
    public string DepartmentName { get; set; }
    public string FacultyName { get; set; }
    public decimal TranscriptGpa { get; set; }
 
}