using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library_DEPI.Migrations
{
    /// <inheritdoc />
    public partial class updateBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "BookImagePath",
                table: "Books",
                newName: "BookImage");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "47a0a036-7ee7-429f-bb54-c58db4a98274", "509a256b-0068-472c-870f-62625abe1f1d", "Admin", "admin" },
                    { "b5628485-88a2-4515-b682-7d15a935c54f", "0016627c-e712-4be9-9221-fb733617da24", "Super Admin", "super admin" },
                    { "ec7cda5e-3cde-4a93-a034-1a244c65a6b1", "668f4c9b-219d-4ff3-b7bf-63d38e62a4da", "User", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "BookImage",
                table: "Books",
                newName: "BookImagePath");

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
    }
}
