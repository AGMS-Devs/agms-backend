using Application.Features.MailLogs.Constants;
using Application.Features.MailLogs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.MailLogs.Commands.Delete;

public class DeleteMailLogCommand : IRequest<DeletedMailLogResponse>
{
    public Guid Id { get; set; }

    public class DeleteMailLogCommandHandler : IRequestHandler<DeleteMailLogCommand, DeletedMailLogResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMailLogRepository _mailLogRepository;
        private readonly MailLogBusinessRules _mailLogBusinessRules;

        public DeleteMailLogCommandHandler(IMapper mapper, IMailLogRepository mailLogRepository,
                                         MailLogBusinessRules mailLogBusinessRules)
        {
            _mapper = mapper;
            _mailLogRepository = mailLogRepository;
            _mailLogBusinessRules = mailLogBusinessRules;
        }

        public async Task<DeletedMailLogResponse> Handle(DeleteMailLogCommand request, CancellationToken cancellationToken)
        {
            MailLog? mailLog = await _mailLogRepository.GetAsync(predicate: ml => ml.Id == request.Id, cancellationToken: cancellationToken);
            await _mailLogBusinessRules.MailLogShouldExistWhenSelected(mailLog);

            await _mailLogRepository.DeleteAsync(mailLog!);

            DeletedMailLogResponse response = _mapper.Map<DeletedMailLogResponse>(mailLog);
            return response;
        }
    }
}