using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_.net.Migrations
{
    /// <inheritdoc />
    public partial class AddMealsPlanFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MealName",
                table: "Meals",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Thumb",
                table: "Meals",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MealName",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Thumb",
                table: "Meals");
        }
    }
}
