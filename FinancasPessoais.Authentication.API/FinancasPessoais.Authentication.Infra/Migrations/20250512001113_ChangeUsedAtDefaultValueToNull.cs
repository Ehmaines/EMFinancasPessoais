using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancasPessoais.Authentication.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUsedAtDefaultValueToNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 11, 21, 11, 13, 170, DateTimeKind.Local).AddTicks(8521),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 5, 11, 19, 21, 2, 146, DateTimeKind.Local).AddTicks(5023));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 11, 21, 11, 13, 170, DateTimeKind.Local).AddTicks(8158),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 5, 11, 19, 21, 2, 146, DateTimeKind.Local).AddTicks(4587));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "RequestPasswordTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 12, 0, 11, 13, 171, DateTimeKind.Utc).AddTicks(1047),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 5, 11, 22, 21, 2, 146, DateTimeKind.Utc).AddTicks(7459));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RequestPasswordTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 12, 0, 11, 13, 171, DateTimeKind.Utc).AddTicks(683),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 5, 11, 22, 21, 2, 146, DateTimeKind.Utc).AddTicks(7002));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 11, 19, 21, 2, 146, DateTimeKind.Local).AddTicks(5023),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 5, 11, 21, 11, 13, 170, DateTimeKind.Local).AddTicks(8521));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 11, 19, 21, 2, 146, DateTimeKind.Local).AddTicks(4587),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 5, 11, 21, 11, 13, 170, DateTimeKind.Local).AddTicks(8158));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "RequestPasswordTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 11, 22, 21, 2, 146, DateTimeKind.Utc).AddTicks(7459),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 5, 12, 0, 11, 13, 171, DateTimeKind.Utc).AddTicks(1047));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RequestPasswordTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 11, 22, 21, 2, 146, DateTimeKind.Utc).AddTicks(7002),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 5, 12, 0, 11, 13, 171, DateTimeKind.Utc).AddTicks(683));
        }
    }
}
