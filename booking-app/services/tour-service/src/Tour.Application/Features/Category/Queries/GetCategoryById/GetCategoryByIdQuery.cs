using Shared.Common;
using MediatR;

namespace Application.Features
{
    public record GetCategoryByIdQuery(GetCategoryByIdRequestDTO model) : IRequest<OperationResult<GetCategoryByIdDTO>>;
}