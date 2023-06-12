using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpurringSportActivity.Context.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicPoints_UsersDetails_WinningUserId",
                table: "PublicPoints");

            migrationBuilder.DropIndex(
                name: "IX_PublicPoints_WinningUserId",
                table: "PublicPoints");

            migrationBuilder.DropColumn(
                name: "DateWon",
                table: "UserPoints");

            migrationBuilder.DropColumn(
                name: "PlacingDate",
                table: "UserPoints");

            migrationBuilder.DropColumn(
                name: "WinningUserId",
                table: "PublicPoints");

            migrationBuilder.DropColumn(
                name: "DateWon",
                table: "CompanyPoints");

            migrationBuilder.DropColumn(
                name: "PlacingDate",
                table: "CompanyPoints");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateWon",
                table: "PointsDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PlacingDate",
                table: "PointsDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "WinningUserId",
                table: "PointsDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PointsDetails_WinningUserId",
                table: "PointsDetails",
                column: "WinningUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PointsDetails_UsersDetails_WinningUserId",
                table: "PointsDetails",
                column: "WinningUserId",
                principalTable: "UsersDetails",
                principalColumn: "UserId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PointsDetails_UsersDetails_WinningUserId",
                table: "PointsDetails");

            migrationBuilder.DropIndex(
                name: "IX_PointsDetails_WinningUserId",
                table: "PointsDetails");

            migrationBuilder.DropColumn(
                name: "DateWon",
                table: "PointsDetails");

            migrationBuilder.DropColumn(
                name: "PlacingDate",
                table: "PointsDetails");

            migrationBuilder.DropColumn(
                name: "WinningUserId",
                table: "PointsDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateWon",
                table: "UserPoints",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PlacingDate",
                table: "UserPoints",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "WinningUserId",
                table: "PublicPoints",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateWon",
                table: "CompanyPoints",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PlacingDate",
                table: "CompanyPoints",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
