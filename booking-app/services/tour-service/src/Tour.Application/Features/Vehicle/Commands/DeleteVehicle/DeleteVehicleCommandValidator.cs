using Application.Features;
using FluentValidation;


namespace Application.Features
{
    public class DeleteVehicleCommandValidator : AbstractValidator<DeleteVehicleCommand>
    {
        public DeleteVehicleCommandValidator()
        {
            RuleFor(v => v.model.id)
                .NotEmpty().WithMessage("Id là bắt buộc.");
        }

    }
}