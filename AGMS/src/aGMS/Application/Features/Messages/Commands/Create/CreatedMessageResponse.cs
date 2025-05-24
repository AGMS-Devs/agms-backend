using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Messages.Commands.Create;

public class CreatedMessageResponse : IResponse
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public DateTime SentAt { get; set; }
    public User Sender { get; set; }
    public User Receiver { get; set; }
    public Guid ReceiverId { get; set; }
    public Guid SenderId { get; set; }
    public bool IsRead { get; set; }
}