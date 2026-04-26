using Shared.Common;
using MediatR;

namespace Application.Features
{
    public record GetCategoriesLookupQuery(GetCategoriesLookupRequestDTO model) : IRequest<OperationResult<List<GetCategoriesLookupDTO>>>;
}