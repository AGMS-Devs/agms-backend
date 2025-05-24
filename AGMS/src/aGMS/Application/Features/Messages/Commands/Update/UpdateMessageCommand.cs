using Application.Features.Messages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Messages.Commands.Update;

public class UpdateMessageCommand : IRequest<UpdatedMessageResponse>
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public DateTime SentAt { get; set; }
    public User Sender { get; set; }
    public User Receiver { get; set; }
    public Guid ReceiverId { get; set; }
    public Guid SenderId { get; set; }
    public bool IsRead { get; set; }

    public class UpdateMessageCommandHandler : IRequestHandler<UpdateMessageCommand, UpdatedMessageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;
        private readonly MessageBusinessRules _messageBusinessRules;

        public UpdateMessageCommandHandler(IMapper mapper, IMessageRepository messageRepository,
                                         MessageBusinessRules messageBusinessRules)
        {
            _mapper = mapper;
            _messageRepository = messageRepository;
            _messageBusinessRules = messageBusinessRules;
        }

        public async Task<UpdatedMessageResponse> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
        {
            Message? message = await _messageRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _messageBusinessRules.MessageShouldExistWhenSelected(message);
            message = _mapper.Map(request, message);

            await _messageRepository.UpdateAsync(message!);

            UpdatedMessageResponse response = _mapper.Map<UpdatedMessageResponse>(message);
            return response;
        }
    }
}