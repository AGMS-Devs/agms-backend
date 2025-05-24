using NArchitecture.Core.Persistence.Repositories;
using System;

namespace Domain.Entities;

public class Message : Entity<Guid>
{
    public string Content { get; set; } = string.Empty;
    public DateTime SentAt { get; set; } = DateTime.UtcNow;


    public User Sender { get; set; }
    public User Receiver { get; set; }
    public Guid ReceiverId { get; set; }
    public Guid SenderId { get; set; }

    public bool IsRead { get; set; } = false;

    public Message(){}
    public Message(string content, Guid senderId, Guid receiverId)
    {
        Content = content;
        SenderId = senderId;
        ReceiverId = receiverId;
        SentAt = DateTime.UtcNow;
        IsRead = false;
    }
} 