using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using Application.Features.Messages.Dtos;

namespace Application.Features.Messages.Queries.GetById;

public class GetByIdMessageResponse : IResponse
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public DateTime SentAt { get; set; }
    public Guid AdvisorId { get; set; }
    public string StudentNumber { get; set; }
    public bool IsRead { get; set; }
    public AdvisorDto Advisor { get; set; }
}