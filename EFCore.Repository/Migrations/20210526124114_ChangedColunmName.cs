using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Repository.Migrations
{
    public partial class ChangedColunmName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_category_CategoryId",
                table: "courses");

            migrationBuilder.DropIndex(
                name: "IX_courses_CategoryId",
                table: "courses");

            migrationBuilder.RenameColumn(
                name: "StudentsPerClass",
                table: "courses",
                newName: "RegisteredStudents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegisteredStudents",
                table: "courses",
                newName: "StudentsPerClass");

            migrationBuilder.CreateIndex(
                name: "IX_courses_CategoryId",
                table: "courses",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_category_CategoryId",
                table: "courses",
                column: "CategoryId",
                principalTable: "category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
