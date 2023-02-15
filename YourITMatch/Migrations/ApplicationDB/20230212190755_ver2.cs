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
            migrationBuilder.RenameColumn(
                name: "CompanyID",
                table: "CompanyAddress",
                newName: "CompanyIDID");

            migrationBuilder.CreateTable(
                name: "JobOfferModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyIDID = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Salary = table.Column<decimal>(type: "TEXT", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: false),
                    JobCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Remote = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOfferModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobOfferModel_Company_CompanyIDID",
                        column: x => x.CompanyIDID,
                        principalTable: "Company",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAddress_CompanyIDID",
                table: "CompanyAddress",
                column: "CompanyIDID");

            migrationBuilder.CreateIndex(
                name: "IX_JobOfferModel_CompanyIDID",
                table: "JobOfferModel",
                column: "CompanyIDID");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyAddress_Company_CompanyIDID",
                table: "CompanyAddress",
                column: "CompanyIDID",
                principalTable: "Company",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyAddress_Company_CompanyIDID",
                table: "CompanyAddress");

            migrationBuilder.DropTable(
                name: "JobOfferModel");

            migrationBuilder.DropIndex(
                name: "IX_CompanyAddress_CompanyIDID",
                table: "CompanyAddress");

            migrationBuilder.RenameColumn(
                name: "CompanyIDID",
                table: "CompanyAddress",
                newName: "CompanyID");
        }
    }
}
