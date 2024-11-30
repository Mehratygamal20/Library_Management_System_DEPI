using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library_DEPI.Migrations
{
    /// <inheritdoc />
    public partial class TestBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2be7d95b-84d0-42c2-b2ee-30ba32a4fcc8", "935be83d-682d-4c27-850f-08cbc4a45d3b", "Super Admin", "super admin" },
                    { "5a80e388-00e0-41f6-84e6-4e6843991a55", "2aae9555-cf87-415f-b443-5c2598ca73d0", "Admin", "admin" },
                    { "b71ebe56-4369-4f8e-ba09-d81a9ea3a92c", "1a1e50d2-4309-47ed-b1ba-e51d6efb437c", "User", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2be7d95b-84d0-42c2-b2ee-30ba32a4fcc8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a80e388-00e0-41f6-84e6-4e6843991a55");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b71ebe56-4369-4f8e-ba09-d81a9ea3a92c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04bf9adc-0df8-4476-ad3e-515a2447c5f3", "a7b29f77-a1df-4755-ad14-3dbe3c35a200", "Admin", "admin" },
                    { "8ef9e119-9b4b-4348-a26d-87f3a90ef3c2", "978bf9b4-68f9-476c-b573-5fbde64817dc", "User", "user" },
                    { "cec9e771-e1f6-4e7d-a19c-9e267d0c6910", "116c441c-875d-4c65-9fb4-c17c7e233739", "Super Admin", "super admin" }
                });
        }
    }
}
