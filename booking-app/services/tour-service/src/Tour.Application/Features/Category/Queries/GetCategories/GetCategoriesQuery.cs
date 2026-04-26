using Shared.Common;
using MediatR;

namespace Application.Features
{
    public class GetCategoriesQuery : PaginationParams, IRequest<PagedResult<CategoryItemDTO>>
    {
        public GetCategoriesRequestDTO model {get; set;}

        public GetCategoriesQuery(GetCategoriesRequestDTO _model)
        {
            model = _model;
        }
        
    }
}