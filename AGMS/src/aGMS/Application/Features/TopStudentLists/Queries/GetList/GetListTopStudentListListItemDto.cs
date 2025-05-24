using NArchitecture.Core.Application.Dtos;
using Domain.Enums;
using Application.Features.TopStudentLists.Queries.GetById;
namespace Application.Features.TopStudentLists.Queries.GetList;

public class GetListTopStudentListListItemDto : IDto
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