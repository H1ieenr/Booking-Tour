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
            builder.HasKey(e => e.id);
            builder.Property(e => e.base_price).HasPrecision(18, 2);
            builder.Property(e => e.vehicle_description).HasMaxLength(200);
            builder.Property(e => e.includes).HasColumnType("nvarchar(max)");
            builder.Property(e => e.excludes).HasColumnType("nvarchar(max)");
            builder.Property(e => e.terms_and_conditions).HasColumnType("nvarchar(max)");
            builder.Property(e => e.cancel_policy).HasColumnType("nvarchar(max)");

            builder.HasOne(d => d.category)
                   .WithMany(p => p.travel_tours)
                   .HasForeignKey(d => d.category_id)
                   .OnDelete(DeleteBehavior.Restrict);
        }

        public void Configure(EntityTypeBuilder<Departure> builder)
        {
            builder.ToTable("Departures");
            builder.HasKey(e => e.id);
            builder.Property(e => e.adult_price).HasPrecision(18, 2);
            builder.Property(e => e.child_price).HasPrecision(18, 2);
            builder.Property(e => e.infant_price).HasPrecision(18, 2);
            builder.Property(e => e.status).HasConversion<int>();

            builder.HasOne(d => d.travel_tour)
                   .WithMany(p => p.departures)
                   .HasForeignKey(d => d.travel_tour_id)
                   .OnDelete(DeleteBehavior.Cascade);
        }

        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");
            builder.HasKey(e => e.id);
            builder.Property(e => e.license_plate).IsRequired().HasMaxLength(20);
            builder.HasIndex(e => e.license_plate).IsUnique(); // Biển số xe không được trùng
            builder.Property(e => e.status).HasConversion<int>();
        }

        public void Configure(EntityTypeBuilder<VehicleAssignment> builder)
        {
            builder.ToTable("TourVehicleAssignments");
            builder.HasKey(e => e.id);

            // Cấu hình quan hệ
            builder.HasOne(d => d.departure)
                   .WithMany(p => p.vehicle_assignments)
                   .HasForeignKey(d => d.departure_id);

            builder.HasOne(d => d.vehicle)
                   .WithMany(p => p.assignments)
                   .HasForeignKey(d => d.vehicle_id);
            
        }

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(e => e.id);
            builder.Property(e => e.name).IsRequired().HasMaxLength(100);
        }

        // 4. Cấu hình bảng TourImage
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Images");
            builder.HasKey(e => e.id);
            builder.Property(e => e.url).IsRequired().HasMaxLength(500);

            builder.HasOne(d => d.travel_tour)
                   .WithMany(p => p.images)
                   .HasForeignKey(d => d.travel_tour_id)
                   .OnDelete(DeleteBehavior.Cascade);
        }

        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedules");
            builder.HasKey(e => e.id);
            builder.Property(e => e.content).HasColumnType("nvarchar(max)");

            builder.HasOne(d => d.travel_tour)
                   .WithMany(p => p.schedules)
                   .HasForeignKey(d => d.travel_tour_id)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}