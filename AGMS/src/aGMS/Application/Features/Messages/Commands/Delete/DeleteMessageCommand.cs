using Application.Features.Messages.Constants;
using Application.Features.Messages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Messages.Commands.Delete;

public class DeleteMessageCommand : IRequest<DeletedMessageResponse>
{
    public Guid Id { get; set; }

    public class DeleteMessageCommandHandler : IRequestHandler<DeleteMessageCommand, DeletedMessageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;
        private readonly MessageBusinessRules _messageBusinessRules;

        public DeleteMessageCommandHandler(IMapper mapper, IMessageRepository messageRepository,
                                         MessageBusinessRules messageBusinessRules)
        {
            _mapper = mapper;
            _messageRepository = messageRepository;
            _messageBusinessRules = messageBusinessRules;
        }

        public async Task<DeletedMessageResponse> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            Message? message = await _messageRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _messageBusinessRules.MessageShouldExistWhenSelected(message);

            await _messageRepository.DeleteAsync(message!);

            DeletedMessageResponse response = _mapper.Map<DeletedMessageResponse>(message);
            return response;
        }
    }
}