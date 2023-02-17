using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourITMatch.Migrations
{
    /// <inheritdoc />
    public partial class ver2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCompany_ApplicationUser_UserId",
                table: "UserCompany");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompany_Company_CompanyId",
                table: "UserCompany");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_UserCompany_CompanyId",
                table: "UserCompany");

            migrationBuilder.DropIndex(
                name: "IX_UserCompany_UserId",
                table: "UserCompany");

            migrationBuilder.AddColumn<int>(
                name: "CompanyModelID",
                table: "UserCompany",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCompany_CompanyModelID",
                table: "UserCompany",
                column: "CompanyModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompany_Company_CompanyModelID",
                table: "UserCompany",
                column: "CompanyModelID",
                principalTable: "Company",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCompany_Company_CompanyModelID",
                table: "UserCompany");

            migrationBuilder.DropIndex(
                name: "IX_UserCompany_CompanyModelID",
                table: "UserCompany");

            migrationBuilder.DropColumn(
                name: "CompanyModelID",
                table: "UserCompany");

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCompany_CompanyId",
                table: "UserCompany",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompany_UserId",
                table: "UserCompany",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompany_ApplicationUser_UserId",
                table: "UserCompany",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompany_Company_CompanyId",
                table: "UserCompany",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
