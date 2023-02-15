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
                name: "FK_JobOfferLocalisation_JobOfferModel_JobOfferIdId",
                table: "JobOfferLocalisation");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOfferModel_Company_CompanyIDID",
                table: "JobOfferModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobOfferModel",
                table: "JobOfferModel");

            migrationBuilder.RenameTable(
                name: "JobOfferModel",
                newName: "JobOffer");

            migrationBuilder.RenameIndex(
                name: "IX_JobOfferModel_CompanyIDID",
                table: "JobOffer",
                newName: "IX_JobOffer_CompanyIDID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobOffer",
                table: "JobOffer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffer_Company_CompanyIDID",
                table: "JobOffer",
                column: "CompanyIDID",
                principalTable: "Company",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOfferLocalisation_JobOffer_JobOfferIdId",
                table: "JobOfferLocalisation",
                column: "JobOfferIdId",
                principalTable: "JobOffer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOffer_Company_CompanyIDID",
                table: "JobOffer");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOfferLocalisation_JobOffer_JobOfferIdId",
                table: "JobOfferLocalisation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobOffer",
                table: "JobOffer");

            migrationBuilder.RenameTable(
                name: "JobOffer",
                newName: "JobOfferModel");

            migrationBuilder.RenameIndex(
                name: "IX_JobOffer_CompanyIDID",
                table: "JobOfferModel",
                newName: "IX_JobOfferModel_CompanyIDID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobOfferModel",
                table: "JobOfferModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOfferLocalisation_JobOfferModel_JobOfferIdId",
                table: "JobOfferLocalisation",
                column: "JobOfferIdId",
                principalTable: "JobOfferModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOfferModel_Company_CompanyIDID",
                table: "JobOfferModel",
                column: "CompanyIDID",
                principalTable: "Company",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
