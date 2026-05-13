using Domain.ValueObjects;
using Shared.Common;

namespace Application.Features
{
    public class VehicleItemDTO
    {
        public int id { get; set; }
        public string name { get; set; } = "";
        public string license_plate { get; set; } = "";
        public int capacity { get; set; }
        public string driver_name { get; set; } = "";
        public string driver_phone { get; set; } = "";
        public VehicleStatus status { get; set; }
        public int current_odometer { get; set; }
        public DateTime? created_date { get; set; }
    }
    #region GetVehiclesLookup
    public class GetVehiclesLookupRequestDTO
    {
        public string? search_text { get; set; } = "";
        public List<string>? list_status { get; set; }
    };
    public class GetVehiclesLookupDTO
    {
        public int id { get; set; }
        public string name { get; set; } = "";
        public string license_plate { get; set; } = "";
        public int capacity { get; set; }
        public string driver_name { get; set; } = "";
        public string driver_phone { get; set; } = "";
    }
    #endregion
    #region GetVehicles
    public class GetVehiclesRequestDTO : PaginationParams
    {
        public string? search_text { get; set; } = "";
        public List<string>? list_status { get; set; }
    };
    #endregion
    #region CreateVehicle
    public class CreateVehicleRequestDTO : BaseRequestDTO
    {
        public string name { get; set; } = "";
        public string license_plate { get; set; } = "";
        public int capacity { get; set; }
        public string driver_name { get; set; } = "";
        public string driver_phone { get; set; } = "";
        public VehicleStatus status { get; set; }
        public int current_odometer { get; set; }
    };
    #endregion
    #region UpdateVehicle
    public class UpdateVehicleRequestDTO : CreateVehicleRequestDTO
    {
        public int id { get; set; }
    }
    #endregion
    #region DeleteVehicle
    public class DeleteVehicleRequestDTO : BaseRequestDTO
    {
        public int id { get; set; }
    }
    #endregion
    #region GetVehicleById
    public class GetVehicleByIdRequestDTO
    {
        public int id { get; set; }
    }
    public class GetVehicleByIdDTO : VehicleItemDTO
    {

    }
    #endregion
}