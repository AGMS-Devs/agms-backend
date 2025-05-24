using Application.Features.MailLogs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.MailLogs.Commands.Update;

public class UpdateMailLogCommand : IRequest<UpdatedMailLogResponse>
{
    public Guid Id { get; set; }
    public DateTime SentDate { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public bool IsBodyHtml { get; set; }
    public bool IsSentSuccessfully { get; set; }
    public string? ErrorMessage { get; set; }

    public class UpdateMailLogCommandHandler : IRequestHandler<UpdateMailLogCommand, UpdatedMailLogResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMailLogRepository _mailLogRepository;
        private readonly MailLogBusinessRules _mailLogBusinessRules;

        public UpdateMailLogCommandHandler(IMapper mapper, IMailLogRepository mailLogRepository,
                                         MailLogBusinessRules mailLogBusinessRules)
        {
            _mapper = mapper;
            _mailLogRepository = mailLogRepository;
            _mailLogBusinessRules = mailLogBusinessRules;
        }

        public async Task<UpdatedMailLogResponse> Handle(UpdateMailLogCommand request, CancellationToken cancellationToken)
        {
            MailLog? mailLog = await _mailLogRepository.GetAsync(predicate: ml => ml.Id == request.Id, cancellationToken: cancellationToken);
            await _mailLogBusinessRules.MailLogShouldExistWhenSelected(mailLog);
            mailLog = _mapper.Map(request, mailLog);

            await _mailLogRepository.UpdateAsync(mailLog!);

            UpdatedMailLogResponse response = _mapper.Map<UpdatedMailLogResponse>(mailLog);
            return response;
        }
    }
}