using FluentValidation;

namespace Application.Features
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(v => v.model.id)
                .NotEmpty().WithMessage("Id là bắt buộc.");
            RuleFor(v => v.model.name)
                .MaximumLength(50).WithMessage("Tên danh mục không được quá 50 ký tự.")
                .NotEmpty().WithMessage("Tên danh mục là bắt buộc.");
        }
    }
}