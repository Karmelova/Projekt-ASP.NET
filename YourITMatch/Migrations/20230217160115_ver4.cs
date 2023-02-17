using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourITMatch.Migrations
{
    /// <inheritdoc />
    public partial class ver4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCompany_Company_CompanyModelID",
                table: "UserCompany");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCompany",
                table: "UserCompany");

            migrationBuilder.DropIndex(
                name: "IX_UserCompany_CompanyModelID",
                table: "UserCompany");

            migrationBuilder.DropColumn(
                name: "CompanyModelID",
                table: "UserCompany");

            migrationBuilder.RenameTable(
                name: "UserCompany",
                newName: "UserCompanies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCompanies",
                table: "UserCompanies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCompanies_CompanyId",
                table: "UserCompanies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompanies_UserId",
                table: "UserCompanies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanies_ApplicationUser_UserId",
                table: "UserCompanies",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanies_Company_CompanyId",
                table: "UserCompanies",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanies_ApplicationUser_UserId",
                table: "UserCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanies_Company_CompanyId",
                table: "UserCompanies");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCompanies",
                table: "UserCompanies");

            migrationBuilder.DropIndex(
                name: "IX_UserCompanies_CompanyId",
                table: "UserCompanies");

            migrationBuilder.DropIndex(
                name: "IX_UserCompanies_UserId",
                table: "UserCompanies");

            migrationBuilder.RenameTable(
                name: "UserCompanies",
                newName: "UserCompany");

            migrationBuilder.AddColumn<int>(
                name: "CompanyModelID",
                table: "UserCompany",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCompany",
                table: "UserCompany",
                column: "Id");

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
    }
}
