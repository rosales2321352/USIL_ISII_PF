using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class FixesDB_Conversation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_opportunity_opportunity_status_order_status_id",
                table: "opportunity");

            migrationBuilder.RenameColumn(
                name: "order_status_id",
                table: "opportunity",
                newName: "opportunity_status_id");

            migrationBuilder.RenameIndex(
                name: "IX_opportunity_order_status_id",
                table: "opportunity",
                newName: "IX_opportunity_opportunity_status_id");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "acception_date",
                table: "order",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddForeignKey(
                name: "FK_opportunity_opportunity_status_opportunity_status_id",
                table: "opportunity",
                column: "opportunity_status_id",
                principalTable: "opportunity_status",
                principalColumn: "opportunity_status_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_opportunity_opportunity_status_opportunity_status_id",
                table: "opportunity");

            migrationBuilder.RenameColumn(
                name: "opportunity_status_id",
                table: "opportunity",
                newName: "order_status_id");

            migrationBuilder.RenameIndex(
                name: "IX_opportunity_opportunity_status_id",
                table: "opportunity",
                newName: "IX_opportunity_order_status_id");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "acception_date",
                table: "order",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_opportunity_opportunity_status_order_status_id",
                table: "opportunity",
                column: "order_status_id",
                principalTable: "opportunity_status",
                principalColumn: "opportunity_status_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
