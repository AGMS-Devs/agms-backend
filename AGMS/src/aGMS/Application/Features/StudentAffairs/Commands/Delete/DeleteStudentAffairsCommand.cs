using Application.Features.StudentAffairs.Constants;
using Application.Features.StudentAffairs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentAffairs.Commands.Delete;

public class DeleteStudentAffairsCommand : IRequest<DeletedStudentAffairsResponse>
{
    public Guid Id { get; set; }

    public class DeleteStudentAffairsCommandHandler : IRequestHandler<DeleteStudentAffairsCommand, DeletedStudentAffairsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentAffairRepository _studentAffairRepository;
        private readonly StudentAffairsBusinessRules _studentAffairsBusinessRules;

        public DeleteStudentAffairsCommandHandler(IMapper mapper, IStudentAffairRepository studentAffairRepository,
                                         StudentAffairsBusinessRules studentAffairsBusinessRules)
        {
            _mapper = mapper;
            _studentAffairRepository = studentAffairRepository;
            _studentAffairsBusinessRules = studentAffairsBusinessRules;
        }

        public async Task<DeletedStudentAffairsResponse> Handle(DeleteStudentAffairsCommand request, CancellationToken cancellationToken)
        {
            StudentAffair? studentAffair = await _studentAffairRepository.GetAsync(predicate: sa => sa.Id == request.Id, cancellationToken: cancellationToken);
            await _studentAffairsBusinessRules.StudentAffairShouldExistWhenSelected(studentAffair);

            await _studentAffairRepository.DeleteAsync(studentAffair!);

            DeletedStudentAffairsResponse response = _mapper.Map<DeletedStudentAffairsResponse>(studentAffair);
            return response;
        }
    }
}