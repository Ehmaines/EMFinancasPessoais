using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancasPessoais.Authentication.Infra.Migrations
{
    /// <inheritdoc />
    public partial class addRequestPassToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 14, 21, 39, 6, 415, DateTimeKind.Local).AddTicks(6769),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 1, 13, 20, 55, 15, 447, DateTimeKind.Local).AddTicks(8257));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 14, 21, 39, 6, 415, DateTimeKind.Local).AddTicks(6328),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 1, 13, 20, 55, 15, 447, DateTimeKind.Local).AddTicks(7829));

            migrationBuilder.CreateTable(
                name: "RequestPasswordTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "VARCHAR(MAX)", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlreadyUsed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2025, 1, 15, 0, 39, 6, 415, DateTimeKind.Utc).AddTicks(9608)),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2025, 1, 15, 0, 39, 6, 415, DateTimeKind.Utc).AddTicks(9998))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestPasswordTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestPasswordTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestPasswordTokens_UserId",
                table: "RequestPasswordTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestPasswordTokens");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 13, 20, 55, 15, 447, DateTimeKind.Local).AddTicks(8257),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 1, 14, 21, 39, 6, 415, DateTimeKind.Local).AddTicks(6769));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 13, 20, 55, 15, 447, DateTimeKind.Local).AddTicks(7829),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 1, 14, 21, 39, 6, 415, DateTimeKind.Local).AddTicks(6328));
        }
    }
}
