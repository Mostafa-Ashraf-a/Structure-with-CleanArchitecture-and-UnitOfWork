using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MostafaProject.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auther",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: false),
                    Created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Modified_At = table.Column<DateTime>(type: "datetime", nullable: true),
                    Modified_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auther", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Code = table.Column<int>(type: "int", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: false),
                    Created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Modified_At = table.Column<DateTime>(type: "datetime", nullable: true),
                    Modified_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AutherId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: false),
                    Created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Modified_At = table.Column<DateTime>(type: "datetime", nullable: true),
                    Modified_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Auther_AutherId",
                        column: x => x.AutherId,
                        principalTable: "Auther",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BookCategory",
                columns: table => new
                {
                    BooksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategory", x => new { x.BooksId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_BookCategory_Book_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategory_Category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Auther",
                columns: new[] { "Id", "Created_At", "Created_by", "Is_Deleted", "Modified_At", "Modified_by", "Name" },
                values: new object[] { new Guid("7c15205b-bbad-446f-bc79-77a46eb3aa72"), new DateTime(2023, 11, 27, 20, 6, 32, 669, DateTimeKind.Local).AddTicks(1763), new Guid("00000000-0000-0000-0000-000000000000"), false, null, null, "Mostafa" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AutherId", "Barcode", "Created_At", "Created_by", "Description", "Is_Deleted", "Modified_At", "Modified_by", "Name", "Notes" },
                values: new object[] { new Guid("d4c8b301-f168-467f-b2cd-c9968f13ae88"), new Guid("7c15205b-bbad-446f-bc79-77a46eb3aa72"), "68745952314", new DateTime(2023, 11, 27, 20, 6, 32, 669, DateTimeKind.Local).AddTicks(2227), new Guid("00000000-0000-0000-0000-000000000000"), "Demo Discription", false, null, null, "Mostafa's Book", "" });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AutherId",
                table: "Book",
                column: "AutherId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Created_At",
                table: "Book",
                column: "Created_At");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Is_Deleted",
                table: "Book",
                column: "Is_Deleted");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategory_CategoriesId",
                table: "BookCategory",
                column: "CategoriesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCategory");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Auther");
        }
    }
}
