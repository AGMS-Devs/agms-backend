using NArchitecture.Core.Application.Responses;
using Domain.Entities;
namespace Application.Features.Messages.Commands.Update;

public class UpdatedMessageResponse : IResponse
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