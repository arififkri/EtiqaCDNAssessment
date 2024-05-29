using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace etiqa.Dal.Migrations
{
    /// <inheritdoc />
    public partial class EncryptAdminPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AC1XHllJIPsNdFmHJUjvTMLiW9Tr0GsoJmhv97TQh9Eiw9STWVVFfiAAO46LcEVNVw==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "Admin@123");
        }
    }
}
