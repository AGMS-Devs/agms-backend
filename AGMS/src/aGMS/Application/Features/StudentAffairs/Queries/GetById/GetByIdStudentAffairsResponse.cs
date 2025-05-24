using NArchitecture.Core.Application.Responses;

namespace Application.Features.StudentAffairs.Queries.GetById;

public class GetByIdStudentAffairsResponse : IResponse
{
    public Guid Id { get; set; }
    public string OfficeName { get; set; }
}