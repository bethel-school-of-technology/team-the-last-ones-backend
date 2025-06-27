using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_.net.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    MealsPlanId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    TimeOfDay = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MealId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.MealsPlanId);
                    table.ForeignKey(
                        name: "FK_Meals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    strArea = table.Column<string>(type: "TEXT", nullable: false),
                    strCategory = table.Column<string>(type: "TEXT", nullable: false),
                    strIngredients1 = table.Column<string>(type: "TEXT", nullable: false),
                    strIngredients10 = table.Column<string>(type: "TEXT", nullable: false),
                    strIngredients11 = table.Column<string>(type: "TEXT", nullable: false),
                    strIngredients12 = table.Column<string>(type: "TEXT", nullable: false),
                    strIngredients13 = table.Column<string>(type: "TEXT", nullable: false),
                    strIngredients14 = table.Column<string>(type: "TEXT", nullable: false),
                    strIngredients15 = table.Column<string>(type: "TEXT", nullable: false),
                    strIngredients16 = table.Column<string>(type: "TEXT", nullable: false),
                    strIngredients17 = table.Column<string>(type: "TEXT", nullable: false),
                    strIngredients18 = table.Column<string>(type: "TEXT", nullable: false),
                    strIngredients19 = table.Column<string>(type: "TEXT", nullable: false),
                    strIngredients2 = table.Column<string>(type: "TEXT", nullable: false),
                    strIngredients20 = table.Column<string>(type: "TEXT", nullable: false),
                    strIngredients3 = table.Column<string>(type: "TEXT", nullable: false),
                    strIngredients4 = table.Column<string>(type: "TEXT", nullable: false),
                    strIngredients5 = table.Column<string>(type: "TEXT", nullable: false),
                    strIngredients6 = table.Column<string>(type: "TEXT", nullable: false),
                    strIngredients7 = table.Column<string>(type: "TEXT", nullable: false),
                    strIngredients8 = table.Column<string>(type: "TEXT", nullable: false),
                    strIngredients9 = table.Column<string>(type: "TEXT", nullable: false),
                    strInstructions = table.Column<string>(type: "TEXT", nullable: false),
                    strMeal = table.Column<string>(type: "TEXT", nullable: false),
                    strMealThumb = table.Column<string>(type: "TEXT", nullable: false),
                    strMeasure1 = table.Column<string>(type: "TEXT", nullable: false),
                    strMeasure10 = table.Column<string>(type: "TEXT", nullable: false),
                    strMeasure11 = table.Column<string>(type: "TEXT", nullable: false),
                    strMeasure12 = table.Column<string>(type: "TEXT", nullable: false),
                    strMeasure13 = table.Column<string>(type: "TEXT", nullable: false),
                    strMeasure14 = table.Column<string>(type: "TEXT", nullable: false),
                    strMeasure15 = table.Column<string>(type: "TEXT", nullable: false),
                    strMeasure16 = table.Column<string>(type: "TEXT", nullable: false),
                    strMeasure17 = table.Column<string>(type: "TEXT", nullable: false),
                    strMeasure18 = table.Column<string>(type: "TEXT", nullable: false),
                    strMeasure19 = table.Column<string>(type: "TEXT", nullable: false),
                    strMeasure2 = table.Column<string>(type: "TEXT", nullable: false),
                    strMeasure20 = table.Column<string>(type: "TEXT", nullable: false),
                    strMeasure3 = table.Column<string>(type: "TEXT", nullable: false),
                    strMeasure4 = table.Column<string>(type: "TEXT", nullable: false),
                    strMeasure5 = table.Column<string>(type: "TEXT", nullable: false),
                    strMeasure6 = table.Column<string>(type: "TEXT", nullable: false),
                    strMeasure7 = table.Column<string>(type: "TEXT", nullable: false),
                    strMeasure8 = table.Column<string>(type: "TEXT", nullable: false),
                    strMeasure9 = table.Column<string>(type: "TEXT", nullable: false),
                    strTags = table.Column<string>(type: "TEXT", nullable: false),
                    strYoutube = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeId);
                    table.ForeignKey(
                        name: "FK_Recipes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meals_UserId",
                table: "Meals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserId",
                table: "Recipes",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
