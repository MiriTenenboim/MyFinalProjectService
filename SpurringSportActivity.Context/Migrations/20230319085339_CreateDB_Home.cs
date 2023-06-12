using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpurringSportActivity.Context.Migrations
{
    /// <inheritdoc />
    public partial class CreateDBHome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyPoints_CompaniesDetails_CompanyId",
                table: "CompanyPoints");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyPoints_CouponDetails_CouponId",
                table: "CompanyPoints");

            migrationBuilder.DropForeignKey(
                name: "FK_PointsDetails_CompanyPoints_CompanyId",
                table: "PointsDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PointsDetails_UserPoints_UserId",
                table: "PointsDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicPoints_PointsDetails_PointId",
                table: "PublicPoints");

            migrationBuilder.DropForeignKey(
                name: "FK_SportsActivities_UsersDetails_UserId",
                table: "SportsActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPoints_UsersDetails_UserId",
                table: "UserPoints");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyPoints_CompaniesDetails_CompanyId",
                table: "CompanyPoints",
                column: "CompanyId",
                principalTable: "CompaniesDetails",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyPoints_CouponDetails_CouponId",
                table: "CompanyPoints",
                column: "CouponId",
                principalTable: "CouponDetails",
                principalColumn: "CouponId",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_PublicPoints_PointsDetails_PointId",
                table: "PublicPoints",
                column: "PointId",
                principalTable: "PointsDetails",
                principalColumn: "PointId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SportsActivities_UsersDetails_UserId",
                table: "SportsActivities",
                column: "UserId",
                principalTable: "UsersDetails",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPoints_UsersDetails_UserId",
                table: "UserPoints",
                column: "UserId",
                principalTable: "UsersDetails",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyPoints_CompaniesDetails_CompanyId",
                table: "CompanyPoints");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyPoints_CouponDetails_CouponId",
                table: "CompanyPoints");

            migrationBuilder.DropForeignKey(
                name: "FK_PointsDetails_CompanyPoints_CompanyId",
                table: "PointsDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PointsDetails_UserPoints_UserId",
                table: "PointsDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicPoints_PointsDetails_PointId",
                table: "PublicPoints");

            migrationBuilder.DropForeignKey(
                name: "FK_SportsActivities_UsersDetails_UserId",
                table: "SportsActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPoints_UsersDetails_UserId",
                table: "UserPoints");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyPoints_CompaniesDetails_CompanyId",
                table: "CompanyPoints",
                column: "CompanyId",
                principalTable: "CompaniesDetails",
                principalColumn: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyPoints_CouponDetails_CouponId",
                table: "CompanyPoints",
                column: "CouponId",
                principalTable: "CouponDetails",
                principalColumn: "CouponId");

            migrationBuilder.AddForeignKey(
                name: "FK_PointsDetails_CompanyPoints_CompanyId",
                table: "PointsDetails",
                column: "CompanyId",
                principalTable: "CompanyPoints",
                principalColumn: "CompanyPointId");

            migrationBuilder.AddForeignKey(
                name: "FK_PointsDetails_UserPoints_UserId",
                table: "PointsDetails",
                column: "UserId",
                principalTable: "UserPoints",
                principalColumn: "UserPointId");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicPoints_PointsDetails_PointId",
                table: "PublicPoints",
                column: "PointId",
                principalTable: "PointsDetails",
                principalColumn: "PointId");

            migrationBuilder.AddForeignKey(
                name: "FK_SportsActivities_UsersDetails_UserId",
                table: "SportsActivities",
                column: "UserId",
                principalTable: "UsersDetails",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPoints_UsersDetails_UserId",
                table: "UserPoints",
                column: "UserId",
                principalTable: "UsersDetails",
                principalColumn: "UserId");
        }
    }
}
