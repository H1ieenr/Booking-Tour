using Shared.Common;
using MediatR;

namespace Application.Features
{
    public class GetCategoriesQuery : PaginationParams, IRequest<OperationResult<PagedResult<CategoryItemDTO>>>
    {
        public GetCategoriesRequestDTO model { get; set; }

        public GetCategoriesQuery(GetCategoriesRequestDTO _model)
        {
            PageNumber = _model.PageNumber;
            PageSize = _model.PageSize;
            SortBy = _model.SortBy;
            SortDir = _model.SortDir;
            model = _model;
        }

    }
}