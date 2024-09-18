using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningBook.Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Remove_DeletedBy_Column_For_All_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Accounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "Accounts",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
