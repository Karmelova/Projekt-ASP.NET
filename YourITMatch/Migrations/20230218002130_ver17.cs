using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourITMatch.Migrations
{
    /// <inheritdoc />
    public partial class ver17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOffer_Company_CompanyModelID",
                table: "JobOffer");

            migrationBuilder.DropTable(
                name: "CompanyAddress");

            migrationBuilder.DropTable(
                name: "JobOfferLocalisation");

            migrationBuilder.DropIndex(
                name: "IX_JobOffer_CompanyModelID",
                table: "JobOffer");

            migrationBuilder.DropColumn(
                name: "CompanyModelID",
                table: "JobOffer");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_CompanyId",
                table: "JobOffer",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffer_Company_CompanyId",
                table: "JobOffer",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOffer_Company_CompanyId",
                table: "JobOffer");

            migrationBuilder.DropIndex(
                name: "IX_JobOffer_CompanyId",
                table: "JobOffer");

            migrationBuilder.AddColumn<int>(
                name: "CompanyModelID",
                table: "JobOffer",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CompanyAddress",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyIDID = table.Column<int>(type: "INTEGER", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    PostCode = table.Column<string>(type: "TEXT", nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: false),
                    Voivodeship = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAddress", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CompanyAddress_Company_CompanyIDID",
                        column: x => x.CompanyIDID,
                        principalTable: "Company",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobOfferLocalisation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobOfferIdId = table.Column<int>(type: "INTEGER", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    PostCode = table.Column<string>(type: "TEXT", nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: false),
                    Voivodeship = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOfferLocalisation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_JobOfferLocalisation_JobOffer_JobOfferIdId",
                        column: x => x.JobOfferIdId,
                        principalTable: "JobOffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_CompanyModelID",
                table: "JobOffer",
                column: "CompanyModelID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAddress_CompanyIDID",
                table: "CompanyAddress",
                column: "CompanyIDID");

            migrationBuilder.CreateIndex(
                name: "IX_JobOfferLocalisation_JobOfferIdId",
                table: "JobOfferLocalisation",
                column: "JobOfferIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffer_Company_CompanyModelID",
                table: "JobOffer",
                column: "CompanyModelID",
                principalTable: "Company",
                principalColumn: "ID");
        }
    }
}
