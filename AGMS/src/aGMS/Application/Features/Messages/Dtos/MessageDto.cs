namespace Application.Features.Messages.Dtos;

public class MessageDto
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public DateTime SentAt { get; set; }
    public Guid AdvisorId { get; set; }
    public string StudentNumber { get; set; }
    public bool IsRead { get; set; }
    
    public AdvisorDto Advisor { get; set; }
}

public class AdvisorDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
} 