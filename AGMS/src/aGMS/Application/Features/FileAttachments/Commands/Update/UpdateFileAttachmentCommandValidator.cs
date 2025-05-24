using FluentValidation;

namespace Application.Features.FileAttachments.Commands.Update;

public class UpdateFileAttachmentCommandValidator : AbstractValidator<UpdateFileAttachmentCommand>
{
    public UpdateFileAttachmentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.FileId).NotEmpty();
        
        // File opsiyonel olduğu için, sadece gönderilmişse validasyon yap
        When(c => c.File != null, () => {
            RuleFor(c => c.File).NotEmpty();
        });
    }
}