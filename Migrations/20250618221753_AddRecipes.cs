using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_.net.Migrations
{
    /// <inheritdoc />
    public partial class AddRecipes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    idMeal = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
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
                    table.PrimaryKey("PK_Recipes", x => x.idMeal);
                    table.ForeignKey(
                        name: "FK_Recipes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserId",
                table: "Recipes",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
