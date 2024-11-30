using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library_DEPI.Migrations
{
    /// <inheritdoc />
    public partial class TestCheckout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_AspNetUsers_MemberID",
                table: "Checkouts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47a0a036-7ee7-429f-bb54-c58db4a98274");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5628485-88a2-4515-b682-7d15a935c54f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec7cda5e-3cde-4a93-a034-1a244c65a6b1");

            migrationBuilder.RenameColumn(
                name: "MemberID",
                table: "Checkouts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Checkouts_MemberID",
                table: "Checkouts",
                newName: "IX_Checkouts_UserId");

            migrationBuilder.AddColumn<string>(
                name: "BookName",
                table: "Checkouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Checkouts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Checkouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04bf9adc-0df8-4476-ad3e-515a2447c5f3", "a7b29f77-a1df-4755-ad14-3dbe3c35a200", "Admin", "admin" },
                    { "8ef9e119-9b4b-4348-a26d-87f3a90ef3c2", "978bf9b4-68f9-476c-b573-5fbde64817dc", "User", "user" },
                    { "cec9e771-e1f6-4e7d-a19c-9e267d0c6910", "116c441c-875d-4c65-9fb4-c17c7e233739", "Super Admin", "super admin" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_AspNetUsers_UserId",
                table: "Checkouts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_AspNetUsers_UserId",
                table: "Checkouts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04bf9adc-0df8-4476-ad3e-515a2447c5f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ef9e119-9b4b-4348-a26d-87f3a90ef3c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cec9e771-e1f6-4e7d-a19c-9e267d0c6910");

            migrationBuilder.DropColumn(
                name: "BookName",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Checkouts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Checkouts",
                newName: "MemberID");

            migrationBuilder.RenameIndex(
                name: "IX_Checkouts_UserId",
                table: "Checkouts",
                newName: "IX_Checkouts_MemberID");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "47a0a036-7ee7-429f-bb54-c58db4a98274", "509a256b-0068-472c-870f-62625abe1f1d", "Admin", "admin" },
                    { "b5628485-88a2-4515-b682-7d15a935c54f", "0016627c-e712-4be9-9221-fb733617da24", "Super Admin", "super admin" },
                    { "ec7cda5e-3cde-4a93-a034-1a244c65a6b1", "668f4c9b-219d-4ff3-b7bf-63d38e62a4da", "User", "user" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_AspNetUsers_MemberID",
                table: "Checkouts",
                column: "MemberID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
