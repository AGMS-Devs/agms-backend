namespace Application.Features.Messages.Dtos;

public class MessageDto
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

public class SenderDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
}

public class ReceiverDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
} 