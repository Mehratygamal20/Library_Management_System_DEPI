using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library_DEPI.Migrations
{
    /// <inheritdoc />
    public partial class back : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07344787-89d9-49ad-aeea-c87715d502aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c930c75a-09c9-46fe-8017-d0f8bee7bfcd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9865132-3b74-4879-a2cc-8837259ab497");

            migrationBuilder.AddColumn<string>(
                name: "BookName",
                table: "Checkouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                    { "330b5270-907a-4e05-8c64-29e5220e1584", "66fa2765-94f9-478f-a153-b6f58367cbea", "User", "user" },
                    { "3da1b61f-b0cf-4452-8ac4-0028d1a30bd3", "5071510c-04f1-4e11-b0c8-46934b95273d", "Admin", "admin" },
                    { "f24bbec1-ad0f-4de1-beba-d5e229508fab", "e22f41db-52fb-4dcc-956f-2de18dbab759", "Super Admin", "super admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "330b5270-907a-4e05-8c64-29e5220e1584");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3da1b61f-b0cf-4452-8ac4-0028d1a30bd3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f24bbec1-ad0f-4de1-beba-d5e229508fab");

            migrationBuilder.DropColumn(
                name: "BookName",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Checkouts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07344787-89d9-49ad-aeea-c87715d502aa", "cdcb3561-ab1f-4800-85e8-56938bb0d400", "User", "user" },
                    { "c930c75a-09c9-46fe-8017-d0f8bee7bfcd", "e5eb59d7-d35b-4b24-ae30-542a3dbd84f5", "Admin", "admin" },
                    { "f9865132-3b74-4879-a2cc-8837259ab497", "92e8f3d4-5aa0-4572-b714-e51e7f57c20a", "Super Admin", "super admin" }
                });
        }
    }
}
