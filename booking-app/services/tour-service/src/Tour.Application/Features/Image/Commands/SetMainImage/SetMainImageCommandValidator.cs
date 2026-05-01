using Application.Common;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace Application.Features
{
    public class SetMainImageCommandValidator : AbstractValidator<SetMainImageCommand>
    {
        public SetMainImageCommandValidator()
        {
            RuleFor(v => v.model.id)
                .GreaterThan(0).WithMessage("ID ảnh phải lớn hơn 0.")
                .NotEmpty().WithMessage("ID ảnh là bắt buộc.");

            RuleFor(v => v.model.is_primary)
                .NotNull().WithMessage("Trạng thái ảnh chính là bắt buộc.");
        }
    }
}