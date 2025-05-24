using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.TakenCourses.Commands.Update;

public class UpdatedTakenCourseResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid StudentId { get; set; }
    public Grade Grade { get; set; }
    public DateTime TakenDate { get; set; }
}