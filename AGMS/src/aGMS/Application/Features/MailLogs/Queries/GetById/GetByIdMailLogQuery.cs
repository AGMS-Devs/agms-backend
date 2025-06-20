using Application.Features.MailLogs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.MailLogs.Queries.GetById;

public class GetByIdMailLogQuery : IRequest<GetByIdMailLogResponse>
{
    public Guid Id { get; set; }

    public class GetByIdMailLogQueryHandler : IRequestHandler<GetByIdMailLogQuery, GetByIdMailLogResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMailLogRepository _mailLogRepository;
        private readonly MailLogBusinessRules _mailLogBusinessRules;

        public GetByIdMailLogQueryHandler(IMapper mapper, IMailLogRepository mailLogRepository, MailLogBusinessRules mailLogBusinessRules)
        {
            _mapper = mapper;
            _mailLogRepository = mailLogRepository;
            _mailLogBusinessRules = mailLogBusinessRules;
        }

        public async Task<GetByIdMailLogResponse> Handle(GetByIdMailLogQuery request, CancellationToken cancellationToken)
        {
            MailLog? mailLog = await _mailLogRepository.GetAsync(predicate: ml => ml.Id == request.Id, cancellationToken: cancellationToken);
            await _mailLogBusinessRules.MailLogShouldExistWhenSelected(mailLog);

            GetByIdMailLogResponse response = _mapper.Map<GetByIdMailLogResponse>(mailLog);
            return response;
        }
    }
}