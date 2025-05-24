using FluentValidation;

namespace Application.Features.FileAttachments.Commands.Create;

public class CreateFileAttachmentCommandValidator : AbstractValidator<CreateFileAttachmentCommand>
{
    public CreateFileAttachmentCommandValidator()
    {
        RuleFor(c => c.File).NotEmpty();
        RuleFor(c => c.FileId).NotEmpty();
    }
}