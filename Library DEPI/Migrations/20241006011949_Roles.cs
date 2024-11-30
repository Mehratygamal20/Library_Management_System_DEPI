using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library_DEPI.Migrations
{
    /// <inheritdoc />
    public partial class Roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12709433-eac7-4edf-a38e-a9820b5e5df1", "0cc3766e-cfcc-4d52-ac2e-fbcfaa2527fd", "Admin", "admin" },
                    { "740ed103-0a17-4fa2-a2b7-fa341b66ee77", "9dcc70ea-8c47-4051-a8db-4be3d6cf67cf", "Super Admin", "super admin" },
                    { "d4ee2aed-a406-4da5-98b5-178979801563", "11ca77e3-9f00-4555-96f6-a89e80123cc6", "User", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12709433-eac7-4edf-a38e-a9820b5e5df1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "740ed103-0a17-4fa2-a2b7-fa341b66ee77");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4ee2aed-a406-4da5-98b5-178979801563");
        }
    }
}
