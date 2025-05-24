using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.TopStudentLists.Commands.ApproveRectorate;

public class ApprovedRectorateResponse : IResponse
{
    public Guid Id { get; set; }
    public TopStudentListType TopStudentListType { get; set; }
    public bool RectorateApproval { get; set; }
    public Guid RectorateStaffId { get; set; }
    public bool SendRectorate { get; set; }
} 