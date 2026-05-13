using Shared.Common;
using MediatR;

namespace Application.Features
{
    public class GetVehiclesQuery: PaginationParams, IRequest<OperationResult<PagedResult<VehicleItemDTO>>>
    {
        public GetVehiclesRequestDTO model { get; set; }

        public GetVehiclesQuery(GetVehiclesRequestDTO _model)
        {
            PageNumber = _model.PageNumber;
            PageSize = _model.PageSize;
            SortBy = _model.SortBy;
            SortDir = _model.SortDir;
            model = _model;
        }
    }
}