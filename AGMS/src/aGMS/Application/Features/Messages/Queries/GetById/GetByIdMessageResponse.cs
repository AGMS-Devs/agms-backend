using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using Application.Features.Messages.Dtos;

namespace Application.Features.Messages.Queries.GetById;

public class GetByIdMessageResponse : IResponse
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