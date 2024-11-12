using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagement.Api.Migrations
{
    /// <inheritdoc />
    public partial class initializedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("03a28cbe-966a-4209-a7cb-fd5269bf2820"), new DateTime(2024, 11, 11, 16, 55, 6, 468, DateTimeKind.Utc).AddTicks(7744), "Description of Task 10", "Task 10", 0, null },
                    { new Guid("10f85dde-111f-4247-b1ac-929f4ab48a8c"), new DateTime(2024, 11, 11, 16, 55, 6, 468, DateTimeKind.Utc).AddTicks(7737), "Description of Task 5", "Task 5", 1, null },
                    { new Guid("2cee431a-3491-4125-b0a5-ef01f1d98e9c"), new DateTime(2024, 11, 11, 16, 55, 6, 468, DateTimeKind.Utc).AddTicks(7756), "Description of Task 18", "Task 18", 2, null },
                    { new Guid("2d70788b-3e88-47ca-a86f-a0ec9f24cf4e"), new DateTime(2024, 11, 11, 16, 55, 6, 468, DateTimeKind.Utc).AddTicks(7740), "Description of Task 7", "Task 7", 0, null },
                    { new Guid("3bfbb605-435c-44b1-ba2e-469911f93a62"), new DateTime(2024, 11, 11, 16, 55, 6, 468, DateTimeKind.Utc).AddTicks(7763), "Description of Task 23", "Task 23", 1, null },
                    { new Guid("3e897919-05ee-4885-a1e0-2c8cfa489c2d"), new DateTime(2024, 11, 11, 16, 55, 6, 468, DateTimeKind.Utc).AddTicks(7757), "Description of Task 19", "Task 19", 0, null },
                    { new Guid("52fedbfa-b0e2-4ff8-985c-92099e04cac0"), new DateTime(2024, 11, 11, 16, 55, 6, 468, DateTimeKind.Utc).AddTicks(7727), "Description of Task 1", "Task 1", 0, null },
                    { new Guid("5372af38-357a-4407-a148-313aa7109a4d"), new DateTime(2024, 11, 11, 16, 55, 6, 468, DateTimeKind.Utc).AddTicks(7753), "Description of Task 16", "Task 16", 0, null },
                    { new Guid("680604d3-2d72-4664-96df-883e9eae4585"), new DateTime(2024, 11, 11, 16, 55, 6, 468, DateTimeKind.Utc).AddTicks(7735), "Description of Task 4", "Task 4", 0, null },
                    { new Guid("6aa5250a-b64e-4467-864f-0f80b46b7844"), new DateTime(2024, 11, 11, 16, 55, 6, 468, DateTimeKind.Utc).AddTicks(7741), "Description of Task 8", "Task 8", 1, null },
                    { new Guid("6c1cbfe3-5acd-40ad-96e6-acf27fca8c24"), new DateTime(2024, 11, 11, 16, 55, 6, 468, DateTimeKind.Utc).AddTicks(7748), "Description of Task 13", "Task 13", 0, null },
                    { new Guid("81cdddb5-1880-4f84-8e55-da4ef0a3bc5b"), new DateTime(2024, 11, 11, 16, 55, 6, 468, DateTimeKind.Utc).AddTicks(7733), "Description of Task 3", "Task 3", 2, null },
                    { new Guid("8c739263-6e73-4846-a22a-3ba74eea28f2"), new DateTime(2024, 11, 11, 16, 55, 6, 468, DateTimeKind.Utc).AddTicks(7764), "Description of Task 24", "Task 24", 2, null },
                    { new Guid("93ac9645-2566-42b0-ab6c-788509c81cbe"), new DateTime(2024, 11, 11, 16, 55, 6, 468, DateTimeKind.Utc).AddTicks(7745), "Description of Task 11", "Task 11", 1, null },
                    { new Guid("aaa0613e-eb6a-43aa-ab41-93b892ac1f3a"), new DateTime(2024, 11, 11, 16, 55, 6, 468, DateTimeKind.Utc).AddTicks(7742), "Description of Task 9", "Task 9", 2, null },
                    { new Guid("ac767dc0-0c32-4b65-a2de-a5fd1ac77262"), new DateTime(2024, 11, 11, 16, 55, 6, 468, DateTimeKind.Utc).AddTicks(7758), "Description of Task 20", "Task 20", 1, null },
                    { new Guid("b9333151-42d3-4f3f-8b0b-cabe6ae1d37f"), new DateTime(2024, 11, 11, 16, 55, 6, 468, DateTimeKind.Utc).AddTicks(7750), "Description of Task 14", "Task 14", 1, null },
                    { new Guid("ba66531f-eca3-436f-94b9-8416fabadd58"), new DateTime(2024, 11, 11, 16, 55, 6, 468, DateTimeKind.Utc).AddTicks(7747), "Description of Task 12", "Task 12", 2, null },
                    { new Guid("be98e1d3-1759-4dad-bfa7-c66d0725959f"), new DateTime(2024, 11, 11, 16, 55, 6, 468, DateTimeKind.Utc).AddTicks(7731), "Description of Task 2", "Task 2", 1, null },
                    { new Guid("c8aa03fc-fd7b-4665-9aab-68672d63a528"), new DateTime(2024, 11, 11, 16, 55, 6, 468, DateTimeKind.Utc).AddTicks(7754), "Description of Task 17", "Task 17", 1, null },
                    { new Guid("c8f8bba7-b018-46df-8ea9-c72733c7c401"), new DateTime(2024, 11, 11, 16, 55, 6, 468, DateTimeKind.Utc).AddTicks(7765), "Description of Task 25", "Task 25", 0, null },
                    { new Guid("e35016e7-670a-4cf5-831a-38d37aceb65a"), new DateTime(2024, 11, 11, 16, 55, 6, 468, DateTimeKind.Utc).AddTicks(7751), "Description of Task 15", "Task 15", 2, null },
                    { new Guid("e44df732-b8bd-4150-a3a0-6a6d8f958c03"), new DateTime(2024, 11, 11, 16, 55, 6, 468, DateTimeKind.Utc).AddTicks(7761), "Description of Task 22", "Task 22", 0, null },
                    { new Guid("f36d6407-9940-4ab2-b7cf-17ce52cc73d6"), new DateTime(2024, 11, 11, 16, 55, 6, 468, DateTimeKind.Utc).AddTicks(7760), "Description of Task 21", "Task 21", 2, null },
                    { new Guid("fff94f9d-1be6-402c-80d4-ebc76957dec5"), new DateTime(2024, 11, 11, 16, 55, 6, 468, DateTimeKind.Utc).AddTicks(7738), "Description of Task 6", "Task 6", 2, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
