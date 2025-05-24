using NArchitecture.Core.Application.Responses;

namespace Application.Features.StudentAffairs.Commands.Update;

public class UpdatedStudentAffairsResponse : IResponse
{
    public Guid Id { get; set; }
    public string OfficeName { get; set; }
}