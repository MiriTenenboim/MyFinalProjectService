using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpurringSportActivity.Context.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditCardValidity",
                table: "UsersDetails");

            migrationBuilder.DropColumn(
                name: "DigitsOnTheBack",
                table: "UsersDetails");

            migrationBuilder.DropColumn(
                name: "UserCreditCard",
                table: "UsersDetails");

            migrationBuilder.RenameColumn(
                name: "UserIDNumber",
                table: "UsersDetails",
                newName: "UserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "UsersDetails",
                newName: "UserIDNumber");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreditCardValidity",
                table: "UsersDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DigitsOnTheBack",
                table: "UsersDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserCreditCard",
                table: "UsersDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
