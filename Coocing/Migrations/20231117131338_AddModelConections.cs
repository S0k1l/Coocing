using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coocing.Migrations
{
    /// <inheritdoc />
    public partial class AddModelConections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Recipes");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "RecUserCoursesipes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Coments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_RecUserCoursesipes_AppUserId",
                table: "RecUserCoursesipes",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Coments_AppUserId",
                table: "Coments",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coments_AspNetUsers_AppUserId",
                table: "Coments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecUserCoursesipes_AspNetUsers_AppUserId",
                table: "RecUserCoursesipes",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coments_AspNetUsers_AppUserId",
                table: "Coments");

            migrationBuilder.DropForeignKey(
                name: "FK_RecUserCoursesipes_AspNetUsers_AppUserId",
                table: "RecUserCoursesipes");

            migrationBuilder.DropIndex(
                name: "IX_RecUserCoursesipes_AppUserId",
                table: "RecUserCoursesipes");

            migrationBuilder.DropIndex(
                name: "IX_Coments_AppUserId",
                table: "Coments");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "RecUserCoursesipes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Coments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
