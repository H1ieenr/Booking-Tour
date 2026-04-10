using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tour.Infrastructure.Persistence.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class FixedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CurrentOdometer = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelTours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeTour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsPreferred = table.Column<bool>(type: "bit", nullable: false),
                    OperatorId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalDays = table.Column<int>(type: "int", nullable: false),
                    TotalNights = table.Column<int>(type: "int", nullable: false),
                    VehicleDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Includes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Excludes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TermsAndConditions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CancelPolicy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelTours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelTours_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxParticipants = table.Column<int>(type: "int", nullable: false),
                    CurrentParticipants = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AdultPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ChildPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    InfantPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TourId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departures_TravelTours_TourId",
                        column: x => x.TourId,
                        principalTable: "TravelTours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_TravelTours_TourId",
                        column: x => x.TourId,
                        principalTable: "TravelTours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayNumber = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MealOfTheDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_TravelTours_TourId",
                        column: x => x.TourId,
                        principalTable: "TravelTours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleAssignment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScheduleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleAssignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleAssignment_Departures_DepartureId",
                        column: x => x.DepartureId,
                        principalTable: "Departures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleAssignment_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleAssignment_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "", "", false, "Tour Miền Trung", "", null },
                    { 2, "", "", false, "Tour Miền Bắc", "", null }
                });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "Capacity", "CreatedBy", "CreatedDate", "CurrentOdometer", "DriverName", "DriverPhone", "IsDeleted", "LicensePlate", "Name", "Status", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 16, "", "", 15000, "Nguyễn Văn A", "0901234567", false, "29A-111.11", "Ford Transit Luxury", 1, "", null },
                    { 2, 45, "", "", 50000, "Trần Văn B", "0907654321", false, "29B-222.22", "Hyundai Universe", 1, "", null }
                });

            migrationBuilder.InsertData(
                table: "TravelTours",
                columns: new[] { "Id", "BasePrice", "CancelPolicy", "CategoryId", "CodeTour", "CreatedAt", "CreatedBy", "CreatedDate", "Description", "Excludes", "Includes", "IsDeleted", "IsPreferred", "Location", "OperatorId", "TermsAndConditions", "Title", "TotalDays", "TotalNights", "UpdatedBy", "UpdatedDate", "VehicleDescription" },
                values: new object[,]
                {
                    { 1, 5000000m, "Hủy trước 7 ngày không mất phí", 1, "DNA001", new DateTime(2026, 4, 10, 14, 57, 31, 46, DateTimeKind.Utc).AddTicks(5070), "", "", "", "Vé máy bay, Chi phí cá nhân", "Khách sạn 3 sao, Ăn sáng, Vé tham quan", false, false, "Đà Nẵng", 0, "Áp dụng cho đoàn từ 10 người", "Tour Đà Nẵng - Hội An", 3, 2, "", null, "Xe du lịch đời mới 45 chỗ" },
                    { 2, 4500000m, "Hủy sau 3 ngày mất 50% phí", 2, "SAP002", new DateTime(2026, 4, 10, 14, 57, 31, 46, DateTimeKind.Utc).AddTicks(6210), "", "", "", "Đồ uống trong bữa ăn", "Vé cáp treo, Khách sạn, Hướng dẫn viên", false, false, "Lào Cai", 0, "Trẻ em cần có CMND/Khai sinh", "Khám phá Fansipan Sapa", 2, 1, "", null, "Xe giường nằm chất lượng cao" }
                });

            migrationBuilder.InsertData(
                table: "Departures",
                columns: new[] { "Id", "AdultPrice", "ChildPrice", "CreatedBy", "CreatedDate", "CurrentParticipants", "EndDate", "InfantPrice", "IsDeleted", "MaxParticipants", "StartDate", "Status", "TourId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 5200000m, 3900000m, "", "", 5, new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000000m, false, 20, new DateTime(2026, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "", null },
                    { 2, 4500000m, 3300000m, "", "", 30, new DateTime(2026, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 500000m, false, 30, new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, "", null }
                });

            migrationBuilder.InsertData(
                table: "VehicleAssignment",
                columns: new[] { "Id", "AssignedAt", "CreatedBy", "CreatedDate", "DepartureId", "FromDate", "IsDeleted", "Note", "ScheduleId", "ToDate", "UpdatedBy", "UpdatedDate", "VehicleId" },
                values: new object[] { 1, new DateTime(2026, 4, 10, 14, 57, 31, 46, DateTimeKind.Utc).AddTicks(3930), "", "", 1, new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Đón tại KS Mường Thanh", null, new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Departures_TourId",
                table: "Departures",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_TourId",
                table: "Images",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_TourId",
                table: "Schedules",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelTours_CategoryId",
                table: "TravelTours",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleAssignment_DepartureId",
                table: "VehicleAssignment",
                column: "DepartureId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleAssignment_ScheduleId",
                table: "VehicleAssignment",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleAssignment_VehicleId",
                table: "VehicleAssignment",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "VehicleAssignment");

            migrationBuilder.DropTable(
                name: "Departures");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "TravelTours");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
