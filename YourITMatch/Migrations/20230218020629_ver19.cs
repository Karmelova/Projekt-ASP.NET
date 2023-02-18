using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourITMatch.Migrations
{
    /// <inheritdoc />
    public partial class ver19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobCategory",
                table: "JobOffer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobCategory",
                table: "JobOffer",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
