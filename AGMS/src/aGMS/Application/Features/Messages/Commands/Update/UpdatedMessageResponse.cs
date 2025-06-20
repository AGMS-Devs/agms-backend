using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using Application.Features.Messages.Dtos;

namespace Application.Features.Messages.Commands.Update;

public class UpdatedMessageResponse : IResponse
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public DateTime SentAt { get; set; }
    public Guid AdvisorId { get; set; }
    public string StudentNumber { get; set; }
    public bool IsRead { get; set; }
    public AdvisorDto Advisor { get; set; }
}