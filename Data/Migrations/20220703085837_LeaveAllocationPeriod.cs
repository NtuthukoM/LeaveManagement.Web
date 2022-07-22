using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class LeaveAllocationPeriod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72CC07A3-65A5-47DD-82A3-06F313FC12A7",
                column: "ConcurrencyStamp",
                value: "6cc0e258-fbf2-4eab-a8a6-0c7cf8f90986");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B61171D5-4848-4F3F-B425-EDECCB408C9B",
                column: "ConcurrencyStamp",
                value: "3b0638cd-7aa5-426d-b868-2cb043a01b58");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D891E0A-E166-45E7-9F15-AE1F683EA43A",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "863ff9b0-8f80-4cc8-b742-83d9f6ed565f", "AQAAAAEAACcQAAAAEEtDiPOEU5pzrvSCWbxnqyhJ2Y8wRqxQSjjfaHJsKV4yWvRjwaxbpnZ1MlLqTc4K1g==", "c1cfea61-a842-4251-b539-c9c5211a8ac6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocation");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72CC07A3-65A5-47DD-82A3-06F313FC12A7",
                column: "ConcurrencyStamp",
                value: "7761b94b-f23e-4f75-9edc-88b36457d8cf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B61171D5-4848-4F3F-B425-EDECCB408C9B",
                column: "ConcurrencyStamp",
                value: "22985a7a-2613-419d-8e2b-f8dd6d62509d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D891E0A-E166-45E7-9F15-AE1F683EA43A",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41b4d5af-0abe-449b-a3f4-1e75757adf3f", "AQAAAAEAACcQAAAAEF6N/pgX7b8KITDC/2AIKOLpTK21mfdseEA9RWT+JBDQBqlrcBYhjBdBbYslJyq/3A==", "9362a1d0-f3c5-459d-a572-4eb7ba028e3c" });
        }
    }
}
