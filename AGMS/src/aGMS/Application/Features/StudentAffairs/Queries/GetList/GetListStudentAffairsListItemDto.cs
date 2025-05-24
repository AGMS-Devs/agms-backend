using NArchitecture.Core.Application.Dtos;

namespace Application.Features.StudentAffairs.Queries.GetList;

public class GetListStudentAffairsListItemDto : IDto
{
    public Guid Id { get; set; }
    public string OfficeName { get; set; }
}