using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tour.Infrastructure.Persistence.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_public_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sequence = table.Column<int>(type: "int", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    license_plate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    driver_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    driver_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    current_odometer = table.Column<int>(type: "int", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TravelTours",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    code_tour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    base_price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    is_preferred = table.Column<bool>(type: "bit", nullable: false),
                    operator_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    total_days = table.Column<int>(type: "int", nullable: false),
                    total_nights = table.Column<int>(type: "int", nullable: false),
                    vehicle_description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    includes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    excludes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    terms_and_conditions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cancel_policy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelTours", x => x.id);
                    table.ForeignKey(
                        name: "FK_TravelTours_Categories_category_id",
                        column: x => x.category_id,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departures",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    max_participants = table.Column<int>(type: "int", nullable: false),
                    current_participants = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    adult_price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    child_price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    infant_price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    travel_tour_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departures", x => x.id);
                    table.ForeignKey(
                        name: "FK_Departures_TravelTours_travel_tour_id",
                        column: x => x.travel_tour_id,
                        principalTable: "TravelTours",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    public_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_primary = table.Column<bool>(type: "bit", nullable: false),
                    travel_tour_id = table.Column<int>(type: "int", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.id);
                    table.ForeignKey(
                        name: "FK_Images_TravelTours_travel_tour_id",
                        column: x => x.travel_tour_id,
                        principalTable: "TravelTours",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    day_number = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    meal_of_the_day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    travel_tour_id = table.Column<int>(type: "int", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.id);
                    table.ForeignKey(
                        name: "FK_Schedules_TravelTours_travel_tour_id",
                        column: x => x.travel_tour_id,
                        principalTable: "TravelTours",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleAssignments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departure_id = table.Column<int>(type: "int", nullable: false),
                    departureid = table.Column<int>(type: "int", nullable: true),
                    vehicle_id = table.Column<int>(type: "int", nullable: false),
                    vehicleid = table.Column<int>(type: "int", nullable: true),
                    from_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    to_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    assigned_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Scheduleid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleAssignments", x => x.id);
                    table.ForeignKey(
                        name: "FK_VehicleAssignments_Departures_departureid",
                        column: x => x.departureid,
                        principalTable: "Departures",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_VehicleAssignments_Schedules_Scheduleid",
                        column: x => x.Scheduleid,
                        principalTable: "Schedules",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_VehicleAssignments_Vehicles_vehicleid",
                        column: x => x.vehicleid,
                        principalTable: "Vehicles",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "id", "active", "created_by", "created_date", "image", "image_public_id", "is_deleted", "name", "sequence", "updated_by", "updated_date" },
                values: new object[,]
                {
                    { 1, false, "", null, null, null, false, "Tour Miền Trung", null, "", null },
                    { 2, false, "", null, null, null, false, "Tour Miền Bắc", null, "", null }
                });

            migrationBuilder.InsertData(
                table: "VehicleAssignments",
                columns: new[] { "id", "Scheduleid", "assigned_at", "created_by", "created_date", "departure_id", "departureid", "from_date", "is_deleted", "note", "to_date", "updated_by", "updated_date", "vehicle_id", "vehicleid" },
                values: new object[] { 1, null, new DateTime(2026, 4, 27, 4, 5, 51, 423, DateTimeKind.Utc).AddTicks(8200), "", null, 1, null, new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Đón tại KS Mường Thanh", new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, 1, null });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "id", "capacity", "created_by", "created_date", "current_odometer", "driver_name", "driver_phone", "is_deleted", "license_plate", "name", "status", "updated_by", "updated_date" },
                values: new object[,]
                {
                    { 1, 16, "", null, 15000, "Nguyễn Văn A", "0901234567", false, "29A-111.11", "Ford Transit Luxury", 1, "", null },
                    { 2, 45, "", null, 50000, "Trần Văn B", "0907654321", false, "29B-222.22", "Hyundai Universe", 1, "", null }
                });

            migrationBuilder.InsertData(
                table: "TravelTours",
                columns: new[] { "id", "active", "base_price", "cancel_policy", "category_id", "code_tour", "created_at", "created_by", "created_date", "description", "excludes", "includes", "is_deleted", "is_preferred", "location", "operator_id", "terms_and_conditions", "title", "total_days", "total_nights", "updated_by", "updated_date", "vehicle_description" },
                values: new object[,]
                {
                    { 1, false, 5000000m, "Hủy trước 7 ngày không mất phí", 1, "DNA001", new DateTime(2026, 4, 27, 4, 5, 51, 423, DateTimeKind.Utc).AddTicks(9450), "", null, "", "Vé máy bay, Chi phí cá nhân", "Khách sạn 3 sao, Ăn sáng, Vé tham quan", false, false, "Đà Nẵng", 0, "Áp dụng cho đoàn từ 10 người", "Tour Đà Nẵng - Hội An", 3, 2, "", null, "Xe du lịch đời mới 45 chỗ" },
                    { 2, false, 4500000m, "Hủy sau 3 ngày mất 50% phí", 2, "SAP002", new DateTime(2026, 4, 27, 4, 5, 51, 424, DateTimeKind.Utc).AddTicks(590), "", null, "", "Đồ uống trong bữa ăn", "Vé cáp treo, Khách sạn, Hướng dẫn viên", false, false, "Lào Cai", 0, "Trẻ em cần có CMND/Khai sinh", "Khám phá Fansipan Sapa", 2, 1, "", null, "Xe giường nằm chất lượng cao" }
                });

            migrationBuilder.InsertData(
                table: "Departures",
                columns: new[] { "id", "adult_price", "child_price", "created_by", "created_date", "current_participants", "end_date", "infant_price", "is_deleted", "max_participants", "start_date", "status", "travel_tour_id", "updated_by", "updated_date" },
                values: new object[,]
                {
                    { 1, 5200000m, 3900000m, "", null, 5, new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000000m, false, 20, new DateTime(2026, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "", null },
                    { 2, 4500000m, 3300000m, "", null, 30, new DateTime(2026, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 500000m, false, 30, new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, "", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departures_travel_tour_id",
                table: "Departures",
                column: "travel_tour_id");

            migrationBuilder.CreateIndex(
                name: "IX_Images_travel_tour_id",
                table: "Images",
                column: "travel_tour_id");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_travel_tour_id",
                table: "Schedules",
                column: "travel_tour_id");

            migrationBuilder.CreateIndex(
                name: "IX_TravelTours_category_id",
                table: "TravelTours",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleAssignments_departureid",
                table: "VehicleAssignments",
                column: "departureid");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleAssignments_Scheduleid",
                table: "VehicleAssignments",
                column: "Scheduleid");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleAssignments_vehicleid",
                table: "VehicleAssignments",
                column: "vehicleid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "VehicleAssignments");

            migrationBuilder.DropTable(
                name: "Departures");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "TravelTours");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
