using NArchitecture.Core.Application.Responses;

namespace Application.Features.GraduationProcesses.Commands.Delete;

public class DeletedGraduationProcessResponse : IResponse
{
    public Guid Id { get; set; }
}