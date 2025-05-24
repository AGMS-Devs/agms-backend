using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Messages.Queries.GetById;

public class GetByIdMessageResponse : IResponse
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