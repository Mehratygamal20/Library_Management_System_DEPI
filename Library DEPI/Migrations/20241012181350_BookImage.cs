using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library_DEPI.Migrations
{
    /// <inheritdoc />
    public partial class BookImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "BookImagePath",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3e1fa652-aa9a-484f-a104-4e0b20020e28", "dea91f1d-760b-4458-ac03-89a1cecb61ac", "Admin", "admin" },
                    { "482725c5-b254-435a-ba96-ebb878ee4fe4", "92df2c23-325c-4413-a113-3976808737b1", "User", "user" },
                    { "99b19106-cf5f-48cf-a2a0-065be7ea01e9", "0c449bd1-eba0-4cb7-b857-7b664383c67f", "Super Admin", "super admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e1fa652-aa9a-484f-a104-4e0b20020e28");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "482725c5-b254-435a-ba96-ebb878ee4fe4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99b19106-cf5f-48cf-a2a0-065be7ea01e9");

            migrationBuilder.DropColumn(
                name: "BookImagePath",
                table: "Books");

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
    }
}
