using Application.Features;
using FluentValidation;

namespace Application.Features
{
    public class DeleteCategoryCommandValidator: AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(v => v.model.id)
                .NotEmpty().WithMessage("Id là bắt buộc.");
        }
    }
}