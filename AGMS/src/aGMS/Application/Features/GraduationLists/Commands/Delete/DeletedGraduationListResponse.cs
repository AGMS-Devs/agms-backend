using NArchitecture.Core.Application.Responses;

namespace Application.Features.GraduationLists.Commands.Delete;

public class DeletedGraduationListResponse : IResponse
{
    public Guid Id { get; set; }
}