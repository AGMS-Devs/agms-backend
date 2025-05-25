using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using Application.Features.Messages.Dtos;

namespace Application.Features.Messages.Commands.Update;

public class UpdatedMessageResponse : IResponse
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public DateTime SentAt { get; set; }
    public Guid SenderId { get; set; }
    public Guid ReceiverId { get; set; }
    public bool IsRead { get; set; }
    public SenderDto Sender { get; set; }
    public ReceiverDto Receiver { get; set; }
}