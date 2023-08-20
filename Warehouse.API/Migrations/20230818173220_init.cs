using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Warehouse.API.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Containers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Containers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dimensions = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplier_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dimensions = table.Column<int>(type: "int", nullable: false),
                    SpecialInstructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContainerId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packages_Containers_ContainerId",
                        column: x => x.ContainerId,
                        principalTable: "Containers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Packages_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Packages_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SupplierContainer",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    ContainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierContainer", x => new { x.ContainerId, x.SupplierId });
                    table.ForeignKey(
                        name: "FK_SupplierContainer_Containers_ContainerId",
                        column: x => x.ContainerId,
                        principalTable: "Containers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierContainer_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchedulingProcess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpectedInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualInDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualOutDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulingProcess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchedulingProcess_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchedulingProcess_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Containers",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "40 ft HC" },
                    { 2, "20 ft FR" },
                    { 3, "40 ft HC" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Dimensions" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "khadija" },
                    { 2, "sara" },
                    { 3, "laith" },
                    { 4, "Yousif Supplier" },
                    { 5, "Amro Supplier" },
                    { 6, "Ahmad Supplier" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                column: "Id",
                values: new object[]
                {
                    1,
                    2,
                    3
                });

            migrationBuilder.InsertData(
                table: "Supplier",
                column: "Id",
                values: new object[]
                {
                    4,
                    5,
                    6
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "ContainerId", "CustomerId", "Dimensions", "LocationId", "SpecialInstructions", "Type" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, null, "dangerous", "box" },
                    { 2, 2, 1, 2, null, "perishable", "box" },
                    { 3, 1, 1, 3, null, "dangerous", "cylinder" },
                    { 4, 1, 2, 4, null, "perishable", "cylinder" },
                    { 5, 2, 2, 1, null, "dangerous", "cylinder" },
                    { 6, 3, 2, 5, null, "perishable", "box" },
                    { 7, 3, 3, 5, null, "dangerous", "box" }
                });

            migrationBuilder.InsertData(
                table: "SupplierContainer",
                columns: new[] { "ContainerId", "SupplierId" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 4 },
                    { 2, 6 },
                    { 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "SchedulingProcess",
                columns: new[] { "Id", "ActualInDate", "ActualOutDate", "ExpectedInDate", "ExpectedOutDate", "LocationId", "PackageId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 18, 20, 32, 20, 315, DateTimeKind.Local).AddTicks(8032), null, new DateTime(2023, 8, 18, 20, 32, 20, 315, DateTimeKind.Local).AddTicks(7995), new DateTime(2023, 8, 21, 20, 32, 20, 315, DateTimeKind.Local).AddTicks(8028), 1, 1 },
                    { 2, null, null, new DateTime(2023, 8, 21, 20, 32, 20, 315, DateTimeKind.Local).AddTicks(8037), new DateTime(2023, 8, 23, 20, 32, 20, 315, DateTimeKind.Local).AddTicks(8039), 4, 4 },
                    { 3, new DateTime(2023, 8, 16, 20, 32, 20, 315, DateTimeKind.Local).AddTicks(8044), null, new DateTime(2023, 8, 15, 20, 32, 20, 315, DateTimeKind.Local).AddTicks(8041), new DateTime(2023, 8, 20, 20, 32, 20, 315, DateTimeKind.Local).AddTicks(8043), 2, 2 },
                    { 4, null, null, new DateTime(2023, 8, 12, 20, 32, 20, 315, DateTimeKind.Local).AddTicks(8051), new DateTime(2023, 8, 17, 20, 32, 20, 315, DateTimeKind.Local).AddTicks(8053), 3, 3 },
                    { 5, new DateTime(2023, 8, 14, 20, 32, 20, 315, DateTimeKind.Local).AddTicks(8059), new DateTime(2023, 8, 17, 20, 32, 20, 315, DateTimeKind.Local).AddTicks(8060), new DateTime(2023, 8, 14, 20, 32, 20, 315, DateTimeKind.Local).AddTicks(8055), new DateTime(2023, 8, 17, 20, 32, 20, 315, DateTimeKind.Local).AddTicks(8057), 1, 5 },
                    { 6, new DateTime(2023, 8, 13, 20, 32, 20, 315, DateTimeKind.Local).AddTicks(8067), new DateTime(2023, 8, 15, 20, 32, 20, 315, DateTimeKind.Local).AddTicks(8069), new DateTime(2023, 8, 12, 20, 32, 20, 315, DateTimeKind.Local).AddTicks(8063), new DateTime(2023, 8, 15, 20, 32, 20, 315, DateTimeKind.Local).AddTicks(8065), 5, 6 },
                    { 7, new DateTime(2023, 8, 16, 20, 32, 20, 315, DateTimeKind.Local).AddTicks(8075), new DateTime(2023, 8, 17, 20, 32, 20, 315, DateTimeKind.Local).AddTicks(8077), new DateTime(2023, 8, 15, 20, 32, 20, 315, DateTimeKind.Local).AddTicks(8071), new DateTime(2023, 8, 17, 20, 32, 20, 315, DateTimeKind.Local).AddTicks(8072), 5, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Packages_ContainerId",
                table: "Packages",
                column: "ContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_CustomerId",
                table: "Packages",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_LocationId",
                table: "Packages",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulingProcess_LocationId",
                table: "SchedulingProcess",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulingProcess_PackageId",
                table: "SchedulingProcess",
                column: "PackageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupplierContainer_SupplierId",
                table: "SupplierContainer",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchedulingProcess");

            migrationBuilder.DropTable(
                name: "SupplierContainer");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Containers");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
