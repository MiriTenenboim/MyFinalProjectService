using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpurringSportActivity.Context.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDBHome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyPoints_UsersDetails_WinnerId",
                table: "CompanyPoints");

            migrationBuilder.RenameColumn(
                name: "WinnerId",
                table: "CompanyPoints",
                newName: "WinningUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyPoints_WinnerId",
                table: "CompanyPoints",
                newName: "IX_CompanyPoints_WinningUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyPoints_UsersDetails_WinningUserId",
                table: "CompanyPoints",
                column: "WinningUserId",
                principalTable: "UsersDetails",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyPoints_UsersDetails_WinningUserId",
                table: "CompanyPoints");

            migrationBuilder.RenameColumn(
                name: "WinningUserId",
                table: "CompanyPoints",
                newName: "WinnerId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyPoints_WinningUserId",
                table: "CompanyPoints",
                newName: "IX_CompanyPoints_WinnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyPoints_UsersDetails_WinnerId",
                table: "CompanyPoints",
                column: "WinnerId",
                principalTable: "UsersDetails",
                principalColumn: "UserId");
        }
    }
}
