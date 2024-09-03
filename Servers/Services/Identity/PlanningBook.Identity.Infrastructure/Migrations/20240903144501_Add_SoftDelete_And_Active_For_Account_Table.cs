using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningBook.Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_SoftDelete_And_Active_For_Account_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                table: "Accounts",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "Accounts",
                newName: "DeletedBy");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Accounts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Accounts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Accounts",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "Accounts",
                newName: "CreatedById");
        }
    }
}
