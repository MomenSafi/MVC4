using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC3.Migrations
{
    /// <inheritdoc />
    public partial class addData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "IdEmployee", "Email", "Name", "Password", "UserId" },
                values: new object[] { 5, "safi.moumen90@gmail.com", "momen", "123456", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "IdEmployee",
                keyValue: 5);
        }
    }
}
