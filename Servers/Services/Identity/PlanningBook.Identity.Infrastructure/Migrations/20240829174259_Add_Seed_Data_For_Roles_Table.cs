using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlanningBook.Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Seed_Data_For_Roles_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppliedEntity",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "AppliedEntity", "ConcurrencyStamp", "Name", "NormalizedName", "RoleType" },
                values: new object[,]
                {
                    { new Guid("281c5aa9-f0bd-42bc-9c9f-060895fb4187"), 1, null, "p_EndUser", "p_enduser", 4001 },
                    { new Guid("4155f55f-b7e7-4529-865b-63f2ea7865fa"), 0, null, "a_SysAdmin", "a_sysadmin", 1 },
                    { new Guid("a5a8bd75-c04b-4ad8-b1b7-b1db912ae8ef"), 1, null, "p_Staff", "p_staff", 3000 },
                    { new Guid("f8183db5-a09e-41d8-939b-c188a6247651"), 0, null, "a_User", "a_user", 1001 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("281c5aa9-f0bd-42bc-9c9f-060895fb4187"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4155f55f-b7e7-4529-865b-63f2ea7865fa"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a5a8bd75-c04b-4ad8-b1b7-b1db912ae8ef"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f8183db5-a09e-41d8-939b-c188a6247651"));

            migrationBuilder.DropColumn(
                name: "AppliedEntity",
                table: "Roles");
        }
    }
}
