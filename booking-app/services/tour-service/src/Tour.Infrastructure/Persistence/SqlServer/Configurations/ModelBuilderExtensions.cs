
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
                new Category { Id = 1, Name = "Tour Miền Trung"},
                new Category { Id = 2, Name = "Tour Miền Bắc"}
            );

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { Id = 1, Name = "Ford Transit Luxury", LicensePlate = "29A-111.11", Capacity = 16, DriverName = "Nguyễn Văn A", DriverPhone = "0901234567", Status = VehicleStatus.Active, CurrentOdometer = 15000 },
                new Vehicle { Id = 2, Name = "Hyundai Universe", LicensePlate = "29B-222.22", Capacity = 45, DriverName = "Trần Văn B", DriverPhone = "0907654321", Status = VehicleStatus.Active, CurrentOdometer = 50000 }
            );

            modelBuilder.Entity<VehicleAssignment>().HasData(
                new VehicleAssignment 
                { 
                    Id = 1, DepartureId = 1, VehicleId = 1, 
                    FromDate = new DateTime(2026, 4, 5, 0, 0, 0, DateTimeKind.Unspecified), ToDate = new DateTime(2026, 7, 5, 0, 0, 0, DateTimeKind.Unspecified),
                    Note = "Đón tại KS Mường Thanh" 
                }
            );

            modelBuilder.Entity<TravelTour>().HasData(
                new TravelTour 
                { 
                    Id = 1, 
                    Title = "Tour Đà Nẵng - Hội An", 
                    CodeTour = "DNA001", 
                    BasePrice = 5000000, 
                    Location = "Đà Nẵng", 
                    CategoryId = 1, 
                    TotalDays = 3, 
                    TotalNights = 2,
                    VehicleDescription = "Xe du lịch đời mới 45 chỗ",
                    Includes = "Khách sạn 3 sao, Ăn sáng, Vé tham quan",
                    Excludes = "Vé máy bay, Chi phí cá nhân",
                    TermsAndConditions = "Áp dụng cho đoàn từ 10 người",
                    CancelPolicy = "Hủy trước 7 ngày không mất phí"
                },
                new TravelTour
                { 
                    Id = 2, 
                    Title = "Khám phá Fansipan Sapa", 
                    CodeTour = "SAP002", 
                    BasePrice = 4500000, 
                    Location = "Lào Cai", 
                    CategoryId = 2, 
                    TotalDays = 2, 
                    TotalNights = 1,
                    VehicleDescription = "Xe giường nằm chất lượng cao",
                    Includes = "Vé cáp treo, Khách sạn, Hướng dẫn viên",
                    Excludes = "Đồ uống trong bữa ăn",
                    TermsAndConditions = "Trẻ em cần có CMND/Khai sinh",
                    CancelPolicy = "Hủy sau 3 ngày mất 50% phí"
                }
            );

            modelBuilder.Entity<Departure>().HasData(
                new Departure 
                { 
                    Id = 1, 
                    TourId = 1, 
                    StartDate = new DateTime(2026, 4, 4, 0, 0, 0, DateTimeKind.Unspecified),
                    EndDate = new DateTime(2026, 6, 5, 0, 0, 0, DateTimeKind.Unspecified),
                    MaxParticipants = 20, 
                    CurrentParticipants = 5, 
                    Status = DepartureStatus.Available,
                    AdultPrice = 5200000,
                    ChildPrice = 3900000,
                    InfantPrice = 1000000
                },
                new Departure 
                { 
                    Id = 2, 
                    TourId = 2, 
                    StartDate = new DateTime(2026, 4, 5, 0, 0, 0, DateTimeKind.Unspecified),
                    EndDate = new DateTime(2026, 5, 5, 0, 0, 0, DateTimeKind.Unspecified),
                    MaxParticipants = 30, 
                    CurrentParticipants = 30, 
                    Status = DepartureStatus.Full,
                    AdultPrice = 4500000,
                    ChildPrice = 3300000,
                    InfantPrice = 500000
                }
            );
        }
    }
}