using NArchitecture.Core.Application.Responses;

namespace Application.Features.StudentAffairs.Commands.Delete;

public class DeletedStudentAffairsResponse : IResponse
{
    public Guid Id { get; set; }
}