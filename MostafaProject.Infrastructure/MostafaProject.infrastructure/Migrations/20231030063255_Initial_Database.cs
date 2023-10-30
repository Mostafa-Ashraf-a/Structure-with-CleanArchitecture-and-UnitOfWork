using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MostafaProject.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Demo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: false),
                    Created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Modified_At = table.Column<DateTime>(type: "datetime", nullable: true),
                    Modified_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Demo",
                columns: new[] { "Id", "Created_At", "Created_by", "Description", "Is_Deleted", "Modified_At", "Modified_by", "Name", "Notes" },
                values: new object[] { new Guid("18c07aa4-58cb-46e3-b214-288168903bec"), DateTime.Now.ToString(), new Guid("00000000-0000-0000-0000-000000000000"), "Demo Discription", false, null, null, "Demo Name", "Demo Note" });

            migrationBuilder.CreateIndex(
                name: "IX_Demo_Created_At",
                table: "Demo",
                column: "Created_At");

            migrationBuilder.CreateIndex(
                name: "IX_Demo_Is_Deleted",
                table: "Demo",
                column: "Is_Deleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Demo");
        }
    }
}
