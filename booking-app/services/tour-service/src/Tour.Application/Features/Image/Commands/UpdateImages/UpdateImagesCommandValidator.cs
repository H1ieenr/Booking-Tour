using Application.Common;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace Application.Features
{
    public class UpdateImagesCommandValidator : AbstractValidator<UpdateImagesCommand>
    {
        public UpdateImagesCommandValidator(IOptions<ImageSettings> imageOptions)
        {
            var settings = imageOptions.Value;

            RuleFor(v => v.model.uploads.travel_tour_id)
                .GreaterThan(0).WithMessage("ID tour du lịch phải lớn hơn 0.")
                .NotEmpty().WithMessage("ID tour du lịch là bắt buộc.");

            RuleFor(v => v.model.uploads.code_tour)
            .NotEmpty().WithMessage("Mã tour là bắt buộc.");

            RuleFor(x => x.model.uploads.files)
            .NotNull().WithMessage("Danh sách ảnh không được rỗng");

            RuleForEach(x => x.model.uploads.files).Must(file =>
            {
                if (file == null) return false;

                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
                return settings.AllowedExtensions.Contains(extension);
            }).WithMessage("Định dạng ảnh không hợp lệ");

            RuleForEach(x => x.model.uploads.files).Must(file =>
            {
                if (file == null) return false;

                var maxBytes = settings.MaxFileSize * 1024 * 1024;
                return file.Length <= maxBytes;
            }).WithMessage($"Kích thước file không được vượt quá {settings.MaxFileSize} MB");
        }

    }
}