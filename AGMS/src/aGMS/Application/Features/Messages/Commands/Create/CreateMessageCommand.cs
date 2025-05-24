using Application.Features.Messages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Messages.Commands.Create;

public class CreateMessageCommand : IRequest<CreatedMessageResponse>
{
    public string Content { get; set; }
    public DateTime SentAt { get; set; }
    public User Sender { get; set; }
    public User Receiver { get; set; }
    public Guid ReceiverId { get; set; }
    public Guid SenderId { get; set; }
    public bool IsRead { get; set; }

    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, CreatedMessageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;
        private readonly MessageBusinessRules _messageBusinessRules;

        public CreateMessageCommandHandler(IMapper mapper, IMessageRepository messageRepository,
                                         MessageBusinessRules messageBusinessRules)
        {
            _mapper = mapper;
            _messageRepository = messageRepository;
            _messageBusinessRules = messageBusinessRules;
        }

        public async Task<CreatedMessageResponse> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            Message message = _mapper.Map<Message>(request);

            await _messageRepository.AddAsync(message);

            CreatedMessageResponse response = _mapper.Map<CreatedMessageResponse>(message);
            return response;
        }
    }
}