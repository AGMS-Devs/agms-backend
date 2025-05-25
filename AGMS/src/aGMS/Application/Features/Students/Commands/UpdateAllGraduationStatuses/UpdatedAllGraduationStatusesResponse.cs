using NArchitecture.Core.Application.Responses;

namespace Application.Features.Students.Commands.UpdateAllGraduationStatuses;

public class UpdatedAllGraduationStatusesResponse : IResponse
{
    public int TotalProcessed { get; set; }
    public int SuccessfullyUpdated { get; set; }
    public int Failed { get; set; }
    public List<Guid> UpdatedStudentIds { get; set; } = new List<Guid>();
    public DateTime UpdatedDate { get; set; }
    public string Message => $"Toplam {TotalProcessed} mezuniyet durumu işlendi. {SuccessfullyUpdated} başarılı, {Failed} başarısız.";
} 