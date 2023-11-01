using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFood.DL.Migrations
{
    public partial class update_food_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FoodDesc",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "FoodDiscount",
                table: "Foods",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "FoodStar",
                table: "Foods",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "FoodStatus",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FoodType",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FoodVote",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodDesc",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FoodDiscount",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FoodStar",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FoodStatus",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FoodType",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FoodVote",
                table: "Foods");
        }
    }
}
