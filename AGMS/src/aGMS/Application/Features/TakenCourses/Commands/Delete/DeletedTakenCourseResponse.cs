using NArchitecture.Core.Application.Responses;

namespace Application.Features.TakenCourses.Commands.Delete;

public class DeletedTakenCourseResponse : IResponse
{
    public Guid Id { get; set; }
}