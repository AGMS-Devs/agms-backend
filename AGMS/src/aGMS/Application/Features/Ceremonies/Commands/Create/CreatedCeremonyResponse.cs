using Domain.Entities;
using Domain.Enums;
using NArchitecture.Core.Application.Responses;
using Application.Features.Ceremonies.Dtos;

namespace Application.Features.Ceremonies.Commands.Create;

public class CreatedCeremonyResponse : IResponse
{
    public Guid Id { get; set; }
    public DateTime CeremonyDate { get; set; }
    public string CeremonyLocation { get; set; }
    public string CeremonyDescription { get; set; }
    public CeremonyStatus CeremonyStatus { get; set; }
    public string AcademicYear { get; set; }
    public Guid StudentAffairsId { get; set; }
    public ICollection<StudentUserDto> StudentUsers { get; set; } = new HashSet<StudentUserDto>();
}