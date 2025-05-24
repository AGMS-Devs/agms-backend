using NArchitecture.Core.Application.Responses;

namespace Application.Features.StudentAffairs.Commands.Create;

public class CreatedStudentAffairsResponse : IResponse
{
    public Guid Id { get; set; }
    public string OfficeName { get; set; }
}