using FluentValidation;
namespace Application.Features
{
    public class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
    {
        public CreateVehicleCommandValidator()
        {
            RuleFor(v => v.model.name)
                .MaximumLength(50).WithMessage("Tên xe/mẫu xe không được quá 50 ký tự.")
                .NotEmpty().WithMessage("Tên xe/mẫu xe là bắt buộc.");

            RuleFor(v => v.model.license_plate)
                .MaximumLength(50).WithMessage("Biển số xe không được quá 20 ký tự.")
                .NotEmpty().WithMessage("Biển số xe là bắt buộc.");

            RuleFor(v => v.model.driver_name)
                .MaximumLength(50).WithMessage("Tên tài xế  không được quá 50 ký tự.")
                .NotEmpty().WithMessage("Tên tài xế là bắt buộc.");

            RuleFor(v => v.model.driver_phone)
                .MaximumLength(50).WithMessage("SDT tài xế không được quá 50 ký tự.")
                .NotEmpty().WithMessage("SDT tài xế là bắt buộc.");

            RuleFor(v => v.model.capacity)
                .NotEmpty().WithMessage("Sức chứa của xe là bắt buộc.");
        }

    }
}