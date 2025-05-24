using Application.Features.MailLogs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.MailLogs.Commands.Create;

public class CreateMailLogCommand : IRequest<CreatedMailLogResponse>
{
    public DateTime SentDate { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public bool IsBodyHtml { get; set; }
    public bool IsSentSuccessfully { get; set; }
    public string? ErrorMessage { get; set; }

    public class CreateMailLogCommandHandler : IRequestHandler<CreateMailLogCommand, CreatedMailLogResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMailLogRepository _mailLogRepository;
        private readonly MailLogBusinessRules _mailLogBusinessRules;

        public CreateMailLogCommandHandler(IMapper mapper, IMailLogRepository mailLogRepository,
                                         MailLogBusinessRules mailLogBusinessRules)
        {
            _mapper = mapper;
            _mailLogRepository = mailLogRepository;
            _mailLogBusinessRules = mailLogBusinessRules;
        }

        public async Task<CreatedMailLogResponse> Handle(CreateMailLogCommand request, CancellationToken cancellationToken)
        {
            MailLog mailLog = _mapper.Map<MailLog>(request);

            await _mailLogRepository.AddAsync(mailLog);

            CreatedMailLogResponse response = _mapper.Map<CreatedMailLogResponse>(mailLog);
            return response;
        }
    }
}