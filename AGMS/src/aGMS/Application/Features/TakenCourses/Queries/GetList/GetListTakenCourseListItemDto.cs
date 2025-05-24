using NArchitecture.Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.TakenCourses.Queries.GetList;

public class GetListTakenCourseListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid StudentId { get; set; }
    public Grade Grade { get; set; }
    public DateTime TakenDate { get; set; }
}