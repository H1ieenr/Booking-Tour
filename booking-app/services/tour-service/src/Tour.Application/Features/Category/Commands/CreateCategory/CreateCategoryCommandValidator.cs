
using FluentValidation;

namespace Application.Features
{
    public class CreateCategoryCommandValidator: AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(v => v.model.name)
                .MaximumLength(50).WithMessage("Tên danh mục không được quá 50 ký tự.")
                .NotEmpty().WithMessage("Tên danh mục là bắt buộc.");
        }
        
    }
}