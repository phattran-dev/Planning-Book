using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningBook.Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Change_Column_With_DateTime_Type_To_DateTimeOffset_Type : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "Accounts",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Accounts",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("53f39533-b6d0-4f06-9d1e-74e8772c2631"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "ae9b83b8-ecd3-4c7d-a03e-84d733243db7", null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Accounts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Accounts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("53f39533-b6d0-4f06-9d1e-74e8772c2631"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "UpdatedDate" },
                values: new object[] { "8e6a68ac-3e32-4f77-b443-fe8e3624473a", null, null });
        }
    }
}
