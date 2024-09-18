using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningBook.Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_RevokedToken_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "AccountTokens",
                newName: "Token");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AccountTokens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRevoked",
                table: "AccountTokens",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AccountTokens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpirationDate",
                table: "AccountTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "AccountTokens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RevokedTokens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevokedTokens", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RevokedTokens");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AccountTokens");

            migrationBuilder.DropColumn(
                name: "IsRevoked",
                table: "AccountTokens");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AccountTokens");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpirationDate",
                table: "AccountTokens");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "AccountTokens");

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "AccountTokens",
                newName: "Value");
        }
    }
}
