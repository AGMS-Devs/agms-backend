using Application.Features.Messages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Messages.Commands.Update;

public class UpdateMessageCommand : IRequest<UpdatedMessageResponse>
{
    public Guid Id { get; set; }
    public string Content { get; set; }
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
            Message? message = await _messageRepository.GetAsync(
                predicate: m => m.Id == request.Id, 
                include: query => query.Include(m => m.Advisor),
                cancellationToken: cancellationToken);
                
            await _messageBusinessRules.MessageShouldExistWhenSelected(message);
            
            // Sadece Content ve IsRead alanlarını güncelle
            message!.Content = request.Content;
            message.IsRead = request.IsRead;

            await _messageRepository.UpdateAsync(message);

            UpdatedMessageResponse response = _mapper.Map<UpdatedMessageResponse>(message);
            return response;
        }
    }
}