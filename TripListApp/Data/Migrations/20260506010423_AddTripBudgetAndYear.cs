using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripListApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTripBudgetAndYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TripBudget",
                table: "PackingList",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TripYear",
                table: "PackingList",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TripBudget",
                table: "PackingList");

            migrationBuilder.DropColumn(
                name: "TripYear",
                table: "PackingList");
        }
    }
}
