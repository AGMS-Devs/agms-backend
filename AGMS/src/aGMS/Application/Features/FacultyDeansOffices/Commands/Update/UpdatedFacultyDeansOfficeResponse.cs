using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.FacultyDeansOffices.Commands.Update;

public class UpdatedFacultyDeansOfficeResponse : IResponse
{
    public Guid Id { get; set; }
    public string FacultyName { get; set; }
    public Guid StudentAffairId { get; set; }
    public StudentAffair StudentAffair { get; set; }
}