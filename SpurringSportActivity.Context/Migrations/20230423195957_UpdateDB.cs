using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpurringSportActivity.Context.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PointsDetails_CompanyPoints_CompanyId",
                table: "PointsDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PointsDetails_UserPoints_UserId",
                table: "PointsDetails");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PointsDetails",
                newName: "UserPointId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "PointsDetails",
                newName: "CompanyPointId");

            migrationBuilder.RenameIndex(
                name: "IX_PointsDetails_UserId",
                table: "PointsDetails",
                newName: "IX_PointsDetails_UserPointId");

            migrationBuilder.RenameIndex(
                name: "IX_PointsDetails_CompanyId",
                table: "PointsDetails",
                newName: "IX_PointsDetails_CompanyPointId");

            migrationBuilder.AddForeignKey(
                name: "FK_PointsDetails_CompanyPoints_CompanyPointId",
                table: "PointsDetails",
                column: "CompanyPointId",
                principalTable: "CompanyPoints",
                principalColumn: "CompanyPointId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PointsDetails_UserPoints_UserPointId",
                table: "PointsDetails",
                column: "UserPointId",
                principalTable: "UserPoints",
                principalColumn: "UserPointId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PointsDetails_CompanyPoints_CompanyPointId",
                table: "PointsDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PointsDetails_UserPoints_UserPointId",
                table: "PointsDetails");

            migrationBuilder.RenameColumn(
                name: "UserPointId",
                table: "PointsDetails",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CompanyPointId",
                table: "PointsDetails",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_PointsDetails_UserPointId",
                table: "PointsDetails",
                newName: "IX_PointsDetails_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PointsDetails_CompanyPointId",
                table: "PointsDetails",
                newName: "IX_PointsDetails_CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PointsDetails_CompanyPoints_CompanyId",
                table: "PointsDetails",
                column: "CompanyId",
                principalTable: "CompanyPoints",
                principalColumn: "CompanyPointId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PointsDetails_UserPoints_UserId",
                table: "PointsDetails",
                column: "UserId",
                principalTable: "UserPoints",
                principalColumn: "UserPointId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
