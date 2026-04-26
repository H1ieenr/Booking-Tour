using Application.Features;
using FluentValidation;

namespace Application.Features
{
    public class GetCategoryByIdHandlerValidator : AbstractValidator<GetCategoryByIdHandler>
    {
        public GetCategoryByIdHandlerValidator()
        {
        }
    }
}