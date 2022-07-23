using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class updatedRequestComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72CC07A3-65A5-47DD-82A3-06F313FC12A7",
                column: "ConcurrencyStamp",
                value: "91aa8dcd-8784-49cd-a8c1-ad8aa8eb7a45");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B61171D5-4848-4F3F-B425-EDECCB408C9B",
                column: "ConcurrencyStamp",
                value: "bce24cd5-9f32-4b58-a6e3-04bb13d94d20");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D891E0A-E166-45E7-9F15-AE1F683EA43A",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7a29fac-1b6c-481a-831c-a6d8efd2b740", "AQAAAAEAACcQAAAAEObSefmFw66rgtMSVbMJHbIfACuGM6//pl+AXs7c2G+jdB4jD6mgZaWVnGqj9EBCCA==", "31d79f58-74ec-4792-9418-d7cee5873ac9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72CC07A3-65A5-47DD-82A3-06F313FC12A7",
                column: "ConcurrencyStamp",
                value: "4d6d32e2-8eb3-45e1-a8da-6967177e7d5f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B61171D5-4848-4F3F-B425-EDECCB408C9B",
                column: "ConcurrencyStamp",
                value: "7b15b038-dca5-42e5-a812-862467bb8519");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D891E0A-E166-45E7-9F15-AE1F683EA43A",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec6a3ad3-6cfb-48ca-b0cc-0adb9e19c40b", "AQAAAAEAACcQAAAAEBjsOFnyOI/B2mE09sdJLrqE/SK1+V7n5CFsI5lG0tcOuzmpr+GVj3RLrSv73HDxMA==", "0c2e734d-e63b-4166-a6d7-230be7831c37" });
        }
    }
}
