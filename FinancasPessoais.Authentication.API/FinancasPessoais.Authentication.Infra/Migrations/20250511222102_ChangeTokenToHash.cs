using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancasPessoais.Authentication.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTokenToHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlreadyUsed",
                table: "RequestPasswordTokens");

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "RequestPasswordTokens",
                newName: "TinyUrl");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 11, 19, 21, 2, 146, DateTimeKind.Local).AddTicks(5023),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 1, 14, 21, 39, 6, 415, DateTimeKind.Local).AddTicks(6769));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 11, 19, 21, 2, 146, DateTimeKind.Local).AddTicks(4587),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 1, 14, 21, 39, 6, 415, DateTimeKind.Local).AddTicks(6328));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "RequestPasswordTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 11, 22, 21, 2, 146, DateTimeKind.Utc).AddTicks(7459),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 1, 15, 0, 39, 6, 415, DateTimeKind.Utc).AddTicks(9998));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RequestPasswordTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 11, 22, 21, 2, 146, DateTimeKind.Utc).AddTicks(7002),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 1, 15, 0, 39, 6, 415, DateTimeKind.Utc).AddTicks(9608));

            migrationBuilder.AddColumn<string>(
                name: "Hash",
                table: "RequestPasswordTokens",
                type: "VARCHAR(MAX)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UsedAt",
                table: "RequestPasswordTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hash",
                table: "RequestPasswordTokens");

            migrationBuilder.DropColumn(
                name: "UsedAt",
                table: "RequestPasswordTokens");

            migrationBuilder.RenameColumn(
                name: "TinyUrl",
                table: "RequestPasswordTokens",
                newName: "Token");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 14, 21, 39, 6, 415, DateTimeKind.Local).AddTicks(6769),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 5, 11, 19, 21, 2, 146, DateTimeKind.Local).AddTicks(5023));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 14, 21, 39, 6, 415, DateTimeKind.Local).AddTicks(6328),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 5, 11, 19, 21, 2, 146, DateTimeKind.Local).AddTicks(4587));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "RequestPasswordTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 15, 0, 39, 6, 415, DateTimeKind.Utc).AddTicks(9998),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 5, 11, 22, 21, 2, 146, DateTimeKind.Utc).AddTicks(7459));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RequestPasswordTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 15, 0, 39, 6, 415, DateTimeKind.Utc).AddTicks(9608),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 5, 11, 22, 21, 2, 146, DateTimeKind.Utc).AddTicks(7002));

            migrationBuilder.AddColumn<bool>(
                name: "AlreadyUsed",
                table: "RequestPasswordTokens",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
