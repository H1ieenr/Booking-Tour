using FluentValidation;

namespace Application.Features
{
    public class CreateTravelTourCommandValidator : AbstractValidator<CreateTravelTourCommand>
    {
        public CreateTravelTourCommandValidator()
        {
            RuleFor(v => v.model.title)
                .MaximumLength(200).WithMessage("Tiêu đề không được quá 200 ký tự.")
                .NotEmpty().WithMessage("Tiêu đề là bắt buộc.");

            RuleFor(v => v.model.base_price)
                .GreaterThan(0).WithMessage("Giá tour phải lớn hơn 0.");

            RuleFor(v => v.model.code_tour)
                .MaximumLength(20).WithMessage("Mã tour không được quá 200 ký tự.")
                .NotEmpty().WithMessage("Mã tour là bắt buộc.");
        }
    }
}