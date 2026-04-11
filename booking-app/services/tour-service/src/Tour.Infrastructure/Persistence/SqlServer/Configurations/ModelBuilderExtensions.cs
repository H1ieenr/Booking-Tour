
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.ValueObjects;

namespace Infrastructure.Persistence
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { id = 1, name = "Tour Miền Trung"},
                new Category { id = 2, name = "Tour Miền Bắc"}
            );

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { id = 1, name = "Ford Transit Luxury", license_plate = "29A-111.11", capacity = 16, driver_name = "Nguyễn Văn A", driver_phone = "0901234567", status = VehicleStatus.Active, current_odometer = 15000 },
                new Vehicle { id = 2, name = "Hyundai Universe", license_plate = "29B-222.22", capacity = 45, driver_name = "Trần Văn B", driver_phone = "0907654321", status = VehicleStatus.Active, current_odometer = 50000 }
            );

            modelBuilder.Entity<VehicleAssignment>().HasData(
                new VehicleAssignment 
                { 
                    id = 1, departure_id = 1, vehicle_id = 1, 
                    from_date = new DateTime(2026, 4, 5, 0, 0, 0, DateTimeKind.Unspecified), to_date = new DateTime(2026, 7, 5, 0, 0, 0, DateTimeKind.Unspecified),
                    note = "Đón tại KS Mường Thanh" 
                }
            );

            modelBuilder.Entity<TravelTour>().HasData(
                new TravelTour 
                { 
                    id = 1, 
                    title = "Tour Đà Nẵng - Hội An", 
                    code_tour = "DNA001", 
                    base_price = 5000000, 
                    location = "Đà Nẵng", 
                    category_id = 1, 
                    total_days = 3, 
                    total_nights = 2,
                    vehicle_description = "Xe du lịch đời mới 45 chỗ",
                    includes = "Khách sạn 3 sao, Ăn sáng, Vé tham quan",
                    excludes = "Vé máy bay, Chi phí cá nhân",
                    terms_and_conditions = "Áp dụng cho đoàn từ 10 người",
                    cancel_policy = "Hủy trước 7 ngày không mất phí"
                },
                new TravelTour
                { 
                    id = 2, 
                    title = "Khám phá Fansipan Sapa", 
                    code_tour = "SAP002", 
                    base_price = 4500000, 
                    location = "Lào Cai", 
                    category_id = 2, 
                    total_days = 2, 
                    total_nights = 1,
                    vehicle_description = "Xe giường nằm chất lượng cao",
                    includes = "Vé cáp treo, Khách sạn, Hướng dẫn viên",
                    excludes = "Đồ uống trong bữa ăn",
                    terms_and_conditions = "Trẻ em cần có CMND/Khai sinh",
                    cancel_policy = "Hủy sau 3 ngày mất 50% phí"
                }
            );

            modelBuilder.Entity<Departure>().HasData(
                new Departure 
                { 
                    id = 1, 
                    travel_tour_id = 1, 
                    start_date = new DateTime(2026, 4, 4, 0, 0, 0, DateTimeKind.Unspecified),
                    end_date = new DateTime(2026, 6, 5, 0, 0, 0, DateTimeKind.Unspecified),
                    max_participants = 20, 
                    current_participants = 5, 
                    status = DepartureStatus.Available,
                    adult_price = 5200000,
                    child_price = 3900000,
                    infant_price = 1000000
                },
                new Departure 
                { 
                    id = 2, 
                    travel_tour_id = 2, 
                    start_date = new DateTime(2026, 4, 5, 0, 0, 0, DateTimeKind.Unspecified),
                    end_date = new DateTime(2026, 5, 5, 0, 0, 0, DateTimeKind.Unspecified),
                    max_participants = 30, 
                    current_participants = 30, 
                    status = DepartureStatus.Full,
                    adult_price = 4500000,
                    child_price = 3300000,
                    infant_price = 500000
                }
            );
        }
    }
}