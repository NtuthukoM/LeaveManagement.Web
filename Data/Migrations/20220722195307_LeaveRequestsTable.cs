using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class LeaveRequestsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    Canceled = table.Column<bool>(type: "bit", nullable: false),
                    RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestingEmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeId",
                table: "LeaveRequests",
                column: "LeaveTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

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
    }
}
