using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpurringSportActivity.Context.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompaniesDetails",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyLogo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompaniesDetails", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "CouponDetails",
                columns: table => new
                {
                    CouponId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponDetail = table.Column<int>(type: "int", nullable: false),
                    Advertisement = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponDetails", x => x.CouponId);
                });

            migrationBuilder.CreateTable(
                name: "UsersDetails",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserBank = table.Column<int>(type: "int", nullable: false),
                    UserBankBranch = table.Column<int>(type: "int", nullable: false),
                    UserBankAccount = table.Column<int>(type: "int", nullable: false),
                    UserIDNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserCreditCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreditCardValidity = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DigitsOnTheBack = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDetails", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CompanyPoints",
                columns: table => new
                {
                    CompanyPointId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CouponId = table.Column<int>(type: "int", nullable: false),
                    PlacingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateWon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WinnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyPoints", x => x.CompanyPointId);
                    table.ForeignKey(
                        name: "FK_CompanyPoints_CompaniesDetails_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompaniesDetails",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CompanyPoints_CouponDetails_CouponId",
                        column: x => x.CouponId,
                        principalTable: "CouponDetails",
                        principalColumn: "CouponId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CompanyPoints_UsersDetails_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "UsersDetails",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "SportsActivities",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletionTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    TotalKilometers = table.Column<float>(type: "real", nullable: false),
                    TotalSteps = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportsActivities", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_SportsActivities_UsersDetails_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersDetails",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserPoints",
                columns: table => new
                {
                    UserPointId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CouponAmount = table.Column<int>(type: "int", nullable: false),
                    PlacingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateWon = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPoints", x => x.UserPointId);
                    table.ForeignKey(
                        name: "FK_UserPoints_UsersDetails_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersDetails",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PointsDetails",
                columns: table => new
                {
                    PointId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PointX = table.Column<float>(type: "real", nullable: false),
                    PointY = table.Column<float>(type: "real", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    UserOrCompany = table.Column<int>(type: "int", nullable: false),
                    IsRealized = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointsDetails", x => x.PointId);
                    table.ForeignKey(
                        name: "FK_PointsDetails_CompanyPoints_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyPoints",
                        principalColumn: "CompanyPointId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PointsDetails_UserPoints_UserId",
                        column: x => x.UserId,
                        principalTable: "UserPoints",
                        principalColumn: "UserPointId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PublicPoints",
                columns: table => new
                {
                    PublicPointId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PointId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicPoints", x => x.PublicPointId);
                    table.ForeignKey(
                        name: "FK_PublicPoints_PointsDetails_PointId",
                        column: x => x.PointId,
                        principalTable: "PointsDetails",
                        principalColumn: "PointId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPoints_CompanyId",
                table: "CompanyPoints",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPoints_CouponId",
                table: "CompanyPoints",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPoints_WinnerId",
                table: "CompanyPoints",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PointsDetails_CompanyId",
                table: "PointsDetails",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PointsDetails_UserId",
                table: "PointsDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicPoints_PointId",
                table: "PublicPoints",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_SportsActivities_UserId",
                table: "SportsActivities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPoints_UserId",
                table: "UserPoints",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PublicPoints");

            migrationBuilder.DropTable(
                name: "SportsActivities");

            migrationBuilder.DropTable(
                name: "PointsDetails");

            migrationBuilder.DropTable(
                name: "CompanyPoints");

            migrationBuilder.DropTable(
                name: "UserPoints");

            migrationBuilder.DropTable(
                name: "CompaniesDetails");

            migrationBuilder.DropTable(
                name: "CouponDetails");

            migrationBuilder.DropTable(
                name: "UsersDetails");
        }
    }
}
