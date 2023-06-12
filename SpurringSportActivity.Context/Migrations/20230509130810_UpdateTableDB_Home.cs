using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpurringSportActivity.Context.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableDBHome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyPoints_UsersDetails_WinningUserId",
                table: "CompanyPoints");

            migrationBuilder.DropIndex(
                name: "IX_CompanyPoints_WinningUserId",
                table: "CompanyPoints");

            migrationBuilder.DropColumn(
                name: "WinningUserId",
                table: "CompanyPoints");

            migrationBuilder.AddColumn<int>(
                name: "WinningUserId",
                table: "PublicPoints",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PublicPoints_WinningUserId",
                table: "PublicPoints",
                column: "WinningUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicPoints_UsersDetails_WinningUserId",
                table: "PublicPoints",
                column: "WinningUserId",
                principalTable: "UsersDetails",
                principalColumn: "UserId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicPoints_UsersDetails_WinningUserId",
                table: "PublicPoints");

            migrationBuilder.DropIndex(
                name: "IX_PublicPoints_WinningUserId",
                table: "PublicPoints");

            migrationBuilder.DropColumn(
                name: "WinningUserId",
                table: "PublicPoints");

            migrationBuilder.AddColumn<int>(
                name: "WinningUserId",
                table: "CompanyPoints",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPoints_WinningUserId",
                table: "CompanyPoints",
                column: "WinningUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyPoints_UsersDetails_WinningUserId",
                table: "CompanyPoints",
                column: "WinningUserId",
                principalTable: "UsersDetails",
                principalColumn: "UserId");
        }
    }
}
