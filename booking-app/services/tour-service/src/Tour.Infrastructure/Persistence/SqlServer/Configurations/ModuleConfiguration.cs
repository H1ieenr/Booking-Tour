using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Persistence
{
    public class ModuleConfiguration : 
        IEntityTypeConfiguration<TravelTour>,
        IEntityTypeConfiguration<Departure>,
        IEntityTypeConfiguration<Category>,
        IEntityTypeConfiguration<Image>,
        IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<TravelTour> builder)
        {
            builder.ToTable("TravelTours");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.BasePrice).HasPrecision(18, 2);
            builder.Property(e => e.VehicleDescription).HasMaxLength(200);
            builder.Property(e => e.Includes).HasColumnType("nvarchar(max)");
            builder.Property(e => e.Excludes).HasColumnType("nvarchar(max)");
            builder.Property(e => e.TermsAndConditions).HasColumnType("nvarchar(max)");
            builder.Property(e => e.CancelPolicy).HasColumnType("nvarchar(max)");

            builder.HasOne(d => d.Category)
                   .WithMany(p => p.Tours)
                   .HasForeignKey(d => d.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }

        public void Configure(EntityTypeBuilder<Departure> builder)
        {
            builder.ToTable("Departures");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.AdultPrice).HasPrecision(18, 2);
            builder.Property(e => e.ChildPrice).HasPrecision(18, 2);
            builder.Property(e => e.InfantPrice).HasPrecision(18, 2);
            builder.Property(e => e.Status).HasConversion<int>();

            builder.HasOne(d => d.Tour)
                   .WithMany(p => p.Departures)
                   .HasForeignKey(d => d.TourId)
                   .OnDelete(DeleteBehavior.Cascade);
        }

        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.LicensePlate).IsRequired().HasMaxLength(20);
            builder.HasIndex(e => e.LicensePlate).IsUnique(); // Biển số xe không được trùng
            builder.Property(e => e.Status).HasConversion<int>();
        }

        public void Configure(EntityTypeBuilder<VehicleAssignment> builder)
        {
            builder.ToTable("TourVehicleAssignments");
            builder.HasKey(e => e.Id);

            // Cấu hình quan hệ
            builder.HasOne(d => d.Departure)
                   .WithMany(p => p.VehicleAssignments)
                   .HasForeignKey(d => d.DepartureId);

            builder.HasOne(d => d.Vehicle)
                   .WithMany(p => p.Assignments)
                   .HasForeignKey(d => d.VehicleId);
            
        }

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        }

        // 4. Cấu hình bảng TourImage
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Images");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Url).IsRequired().HasMaxLength(500);

            builder.HasOne(d => d.Tour)
                   .WithMany(p => p.Images)
                   .HasForeignKey(d => d.TourId)
                   .OnDelete(DeleteBehavior.Cascade);
        }

        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedules");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Content).HasColumnType("nvarchar(max)");

            builder.HasOne(d => d.Tour)
                   .WithMany(p => p.Schedules)
                   .HasForeignKey(d => d.TourId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}