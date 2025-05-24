using NArchitecture.Core.Application.Responses;

namespace Application.Features.FacultyDeansOffices.Commands.Delete;

public class DeletedFacultyDeansOfficeResponse : IResponse
{
    public Guid Id { get; set; }
}