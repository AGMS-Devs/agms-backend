using FluentValidation;

namespace Application.Features.Transcripts.Commands.Delete;

public class DeleteTranscriptCommandValidator : AbstractValidator<DeleteTranscriptCommand>
{
    public DeleteTranscriptCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}