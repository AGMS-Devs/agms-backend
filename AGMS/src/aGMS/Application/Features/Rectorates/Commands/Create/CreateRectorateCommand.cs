using Application.Features.Rectorates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Rectorates.Commands.Create;

public class CreateRectorateCommand : IRequest<CreatedRectorateResponse>
{
    public Guid StudentAffairId { get; set; }
    public StudentAffair StudentAffair { get; set; }

    public class CreateRectorateCommandHandler : IRequestHandler<CreateRectorateCommand, CreatedRectorateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRectorateRepository _rectorateRepository;
        private readonly RectorateBusinessRules _rectorateBusinessRules;

        public CreateRectorateCommandHandler(IMapper mapper, IRectorateRepository rectorateRepository,
                                         RectorateBusinessRules rectorateBusinessRules)
        {
            _mapper = mapper;
            _rectorateRepository = rectorateRepository;
            _rectorateBusinessRules = rectorateBusinessRules;
        }

        public async Task<CreatedRectorateResponse> Handle(CreateRectorateCommand request, CancellationToken cancellationToken)
        {
            Rectorate rectorate = _mapper.Map<Rectorate>(request);

            await _rectorateRepository.AddAsync(rectorate);

            CreatedRectorateResponse response = _mapper.Map<CreatedRectorateResponse>(rectorate);
            return response;
        }
    }
}