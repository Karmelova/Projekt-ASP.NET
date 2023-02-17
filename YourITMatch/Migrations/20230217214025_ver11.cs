using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourITMatch.Migrations
{
    /// <inheritdoc />
    public partial class ver11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOffer_Company_CompanyIDID",
                table: "JobOffer");

            migrationBuilder.DropIndex(
                name: "IX_JobOffer_CompanyIDID",
                table: "JobOffer");

            migrationBuilder.RenameColumn(
                name: "CompanyIDID",
                table: "JobOffer",
                newName: "CompanyId");

            migrationBuilder.AddColumn<int>(
                name: "CompanyModelID",
                table: "JobOffer",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_CompanyModelID",
                table: "JobOffer",
                column: "CompanyModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffer_Company_CompanyModelID",
                table: "JobOffer",
                column: "CompanyModelID",
                principalTable: "Company",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOffer_Company_CompanyModelID",
                table: "JobOffer");

            migrationBuilder.DropIndex(
                name: "IX_JobOffer_CompanyModelID",
                table: "JobOffer");

            migrationBuilder.DropColumn(
                name: "CompanyModelID",
                table: "JobOffer");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "JobOffer",
                newName: "CompanyIDID");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_CompanyIDID",
                table: "JobOffer",
                column: "CompanyIDID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffer_Company_CompanyIDID",
                table: "JobOffer",
                column: "CompanyIDID",
                principalTable: "Company",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
