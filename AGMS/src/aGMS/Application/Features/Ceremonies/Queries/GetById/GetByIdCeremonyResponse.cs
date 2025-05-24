using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using Domain.Enums;
namespace Application.Features.Ceremonies.Queries.GetById;

public class GetByIdCeremonyResponse : IResponse
{
    public Guid Id { get; set; }
    public DateTime CeremonyDate { get; set; }
    public string CeremonyLocation { get; set; }
    public string CeremonyDescription { get; set; }
    public CeremonyStatus CeremonyStatus { get; set; }
    public string AcademicYear { get; set; }
    public Guid StudentAffairsId { get; set; }
    public StudentAffair StudentAffair { get; set; }
}