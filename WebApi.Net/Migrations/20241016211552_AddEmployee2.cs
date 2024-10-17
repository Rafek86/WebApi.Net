using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Net.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployee2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Department_DepartmentId",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_DepartmentId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Department");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Department",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Department_DepartmentId",
                table: "Department",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Department_DepartmentId",
                table: "Department",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");
        }
    }
}
