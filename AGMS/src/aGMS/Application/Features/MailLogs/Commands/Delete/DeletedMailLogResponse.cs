using NArchitecture.Core.Application.Responses;

namespace Application.Features.MailLogs.Commands.Delete;

public class DeletedMailLogResponse : IResponse
{
    public Guid Id { get; set; }
}