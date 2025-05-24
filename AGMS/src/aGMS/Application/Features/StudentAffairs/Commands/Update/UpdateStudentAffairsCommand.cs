using Application.Features.StudentAffairs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentAffairs.Commands.Update;

public class UpdateStudentAffairsCommand : IRequest<UpdatedStudentAffairsResponse>
{
    public Guid Id { get; set; }
    public string OfficeName { get; set; }

    public class UpdateStudentAffairsCommandHandler : IRequestHandler<UpdateStudentAffairsCommand, UpdatedStudentAffairsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentAffairRepository _studentAffairRepository;
        private readonly StudentAffairsBusinessRules _studentAffairsBusinessRules;

        public UpdateStudentAffairsCommandHandler(IMapper mapper, IStudentAffairRepository studentAffairRepository,
                                         StudentAffairsBusinessRules studentAffairsBusinessRules)
        {
            _mapper = mapper;
            _studentAffairRepository = studentAffairRepository;
            _studentAffairsBusinessRules = studentAffairsBusinessRules;
        }

        public async Task<UpdatedStudentAffairsResponse> Handle(UpdateStudentAffairsCommand request, CancellationToken cancellationToken)
        {
            StudentAffair? studentAffair = await _studentAffairRepository.GetAsync(predicate: sa => sa.Id == request.Id, cancellationToken: cancellationToken);
            await _studentAffairsBusinessRules.StudentAffairShouldExistWhenSelected(studentAffair);
            studentAffair = _mapper.Map(request, studentAffair);

            await _studentAffairRepository.UpdateAsync(studentAffair!);

            UpdatedStudentAffairsResponse response = _mapper.Map<UpdatedStudentAffairsResponse>(studentAffair);
            return response;
        }
    }
}