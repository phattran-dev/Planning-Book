using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningBook.Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Session_History_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SessionHistorys",
                columns: table => new
                {
                    Token = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    ExpiredDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MacAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Metadata = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionHistorys", x => new { x.Token, x.AccountId });
                    table.ForeignKey(
                        name: "FK_SessionHistorys_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SessionHistorys_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("53f39533-b6d0-4f06-9d1e-74e8772c2631"),
                column: "ConcurrencyStamp",
                value: "8e6a68ac-3e32-4f77-b443-fe8e3624473a");

            migrationBuilder.CreateIndex(
                name: "IX_SessionHistorys_AccountId",
                table: "SessionHistorys",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionHistorys_ApplicationId",
                table: "SessionHistorys",
                column: "ApplicationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessionHistorys");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("53f39533-b6d0-4f06-9d1e-74e8772c2631"),
                column: "ConcurrencyStamp",
                value: "55efcef3-4a2f-4640-9a8a-aac88e5f7ebf");
        }
    }
}
