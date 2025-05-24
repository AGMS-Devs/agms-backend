using Domain.Enums;
using NArchitecture.Core.Application.Dtos;
using System.Text.Json.Serialization;

namespace Application.Features.Advisors.Queries.GetAdvisorStudents;

public class GetAdvisorStudentsResponse : IDto
{
    public Guid Id { get; set; }
    public string StudentNumber { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string DepartmentName { get; set; }
    public DateTime EnrollDate { get; set; }
    public StudentStatus StudentStatus { get; set; }
    public GraduationStatus GraduationStatus { get; set; }
} 