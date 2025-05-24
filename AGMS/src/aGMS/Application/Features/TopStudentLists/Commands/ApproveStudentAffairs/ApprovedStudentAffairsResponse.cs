using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.TopStudentLists.Commands.ApproveStudentAffairs;

public class ApprovedStudentAffairsResponse : IResponse
{
    public Guid Id { get; set; }
    public TopStudentListType TopStudentListType { get; set; }
    public bool StudentAffairsApproval { get; set; }
    public Guid StudentAffairsStaffId { get; set; }
    public bool SendRectorate { get; set; }
} 