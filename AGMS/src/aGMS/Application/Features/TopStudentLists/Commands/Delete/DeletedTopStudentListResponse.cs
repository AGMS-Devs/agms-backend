using NArchitecture.Core.Application.Responses;

namespace Application.Features.TopStudentLists.Commands.Delete;

public class DeletedTopStudentListResponse : IResponse
{
    public Guid Id { get; set; }
}