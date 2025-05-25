using NArchitecture.Core.Persistence.Repositories;
using System;

namespace Domain.Entities;

public class Message : Entity<Guid>
{
    public string Content { get; set; } = string.Empty;
    public DateTime SentAt { get; set; } = DateTime.UtcNow;


    public Guid AdvisorId { get; set; }
    public Advisor Advisor { get; set; }
    public string StudentNumber { get; set; }


    public bool IsRead { get; set; } = false;

    public Message(){}
    public Message(string content, Guid advisorId, string studentNumber)
    {
        Content = content;
        AdvisorId = advisorId;
        StudentNumber = studentNumber;
        SentAt = DateTime.UtcNow;
        IsRead = false;
    }
} 