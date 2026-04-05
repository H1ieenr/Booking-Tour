
namespace Domain.ValueObjects
{
    public enum DepartureStatus
    {
        Available = 1,  // Còn chỗ
        FewSeats = 2,   // Sắp hết chỗ
        Full = 3,       // Đã hết chỗ
        Cancelled = 4   // Đã hủy
    }

    public enum VehicleStatus
    {
        Active = 1,      // Sẵn sàng phục vụ
        OnTrip = 2,      // Đang đi tour
        Maintenance = 3, // Đang bảo trì
        Retired = 4      // Ngưng sử dụng
    }
}