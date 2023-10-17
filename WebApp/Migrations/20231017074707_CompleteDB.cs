using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class CompleteDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_client_company_CompanyID",
                table: "client");

            migrationBuilder.RenameColumn(
                name: "CompanyID",
                table: "company",
                newName: "company_id");

            migrationBuilder.RenameColumn(
                name: "CompanyID",
                table: "client",
                newName: "company_id");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "client",
                newName: "client_id");

            migrationBuilder.RenameIndex(
                name: "IX_client_CompanyID",
                table: "client",
                newName: "IX_client_company_id");

            migrationBuilder.AddColumn<int>(
                name: "SellerID",
                table: "client",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "client_status_id",
                table: "client",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "client",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "phonenumber",
                table: "client",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "whatsapp_id",
                table: "client",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "client_status",
                columns: table => new
                {
                    client_status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client_status", x => x.client_status_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "opportunity_status",
                columns: table => new
                {
                    opportunity_status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_opportunity_status", x => x.opportunity_status_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "order_status",
                columns: table => new
                {
                    order_status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_status", x => x.order_status_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "seller",
                columns: table => new
                {
                    seller_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phonenumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seller", x => x.seller_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "whatsapp_data",
                columns: table => new
                {
                    whatsapp_id = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    first_message_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    phonenumber_code = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    whatsapp_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_whatsapp_data", x => x.whatsapp_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "annotation",
                columns: table => new
                {
                    annotation_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    seller_id = table.Column<int>(type: "int", nullable: false),
                    client_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_annotation", x => x.annotation_id);
                    table.ForeignKey(
                        name: "FK_annotation_client_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_annotation_seller_seller_id",
                        column: x => x.seller_id,
                        principalTable: "seller",
                        principalColumn: "seller_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "event",
                columns: table => new
                {
                    event_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date_assigned = table.Column<DateOnly>(type: "date", nullable: false),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    seller_id = table.Column<int>(type: "int", nullable: false),
                    client_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event", x => x.event_id);
                    table.ForeignKey(
                        name: "FK_event_client_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_event_seller_seller_id",
                        column: x => x.seller_id,
                        principalTable: "seller",
                        principalColumn: "seller_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "opportunity",
                columns: table => new
                {
                    opportunity_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    creation_date = table.Column<DateOnly>(type: "date", nullable: false),
                    order_status_id = table.Column<int>(type: "int", nullable: false),
                    client_id = table.Column<int>(type: "int", nullable: false),
                    seller_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_opportunity", x => x.opportunity_id);
                    table.ForeignKey(
                        name: "FK_opportunity_client_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_opportunity_opportunity_status_order_status_id",
                        column: x => x.order_status_id,
                        principalTable: "opportunity_status",
                        principalColumn: "opportunity_status_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_opportunity_seller_seller_id",
                        column: x => x.seller_id,
                        principalTable: "seller",
                        principalColumn: "seller_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    creation_date = table.Column<DateOnly>(type: "date", nullable: false),
                    acception_date = table.Column<DateOnly>(type: "date", nullable: false),
                    shipping_address = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    geographical_location = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    contact_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    order_status_id = table.Column<int>(type: "int", nullable: false),
                    client_id = table.Column<int>(type: "int", nullable: false),
                    seller_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_order_client_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_order_status_order_status_id",
                        column: x => x.order_status_id,
                        principalTable: "order_status",
                        principalColumn: "order_status_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_seller_seller_id",
                        column: x => x.seller_id,
                        principalTable: "seller",
                        principalColumn: "seller_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "message",
                columns: table => new
                {
                    message_id = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    timestamp = table.Column<DateTime>(type: "timestamp", nullable: false),
                    type = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    text = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    whatsapp_id = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message", x => x.message_id);
                    table.ForeignKey(
                        name: "FK_message_whatsapp_data_whatsapp_id",
                        column: x => x.whatsapp_id,
                        principalTable: "whatsapp_data",
                        principalColumn: "whatsapp_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_client_client_status_id",
                table: "client",
                column: "client_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_client_SellerID",
                table: "client",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "IX_client_whatsapp_id",
                table: "client",
                column: "whatsapp_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_annotation_client_id",
                table: "annotation",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_annotation_seller_id",
                table: "annotation",
                column: "seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_event_client_id",
                table: "event",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_event_seller_id",
                table: "event",
                column: "seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_message_whatsapp_id",
                table: "message",
                column: "whatsapp_id");

            migrationBuilder.CreateIndex(
                name: "IX_opportunity_client_id",
                table: "opportunity",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_opportunity_order_status_id",
                table: "opportunity",
                column: "order_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_opportunity_seller_id",
                table: "opportunity",
                column: "seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_client_id",
                table: "order",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_order_status_id",
                table: "order",
                column: "order_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_seller_id",
                table: "order",
                column: "seller_id");

            migrationBuilder.AddForeignKey(
                name: "FK_client_client_status_client_status_id",
                table: "client",
                column: "client_status_id",
                principalTable: "client_status",
                principalColumn: "client_status_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_client_company_company_id",
                table: "client",
                column: "company_id",
                principalTable: "company",
                principalColumn: "company_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_client_seller_SellerID",
                table: "client",
                column: "SellerID",
                principalTable: "seller",
                principalColumn: "seller_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_client_whatsapp_data_whatsapp_id",
                table: "client",
                column: "whatsapp_id",
                principalTable: "whatsapp_data",
                principalColumn: "whatsapp_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_client_client_status_client_status_id",
                table: "client");

            migrationBuilder.DropForeignKey(
                name: "FK_client_company_company_id",
                table: "client");

            migrationBuilder.DropForeignKey(
                name: "FK_client_seller_SellerID",
                table: "client");

            migrationBuilder.DropForeignKey(
                name: "FK_client_whatsapp_data_whatsapp_id",
                table: "client");

            migrationBuilder.DropTable(
                name: "annotation");

            migrationBuilder.DropTable(
                name: "client_status");

            migrationBuilder.DropTable(
                name: "event");

            migrationBuilder.DropTable(
                name: "message");

            migrationBuilder.DropTable(
                name: "opportunity");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "whatsapp_data");

            migrationBuilder.DropTable(
                name: "opportunity_status");

            migrationBuilder.DropTable(
                name: "order_status");

            migrationBuilder.DropTable(
                name: "seller");

            migrationBuilder.DropIndex(
                name: "IX_client_client_status_id",
                table: "client");

            migrationBuilder.DropIndex(
                name: "IX_client_SellerID",
                table: "client");

            migrationBuilder.DropIndex(
                name: "IX_client_whatsapp_id",
                table: "client");

            migrationBuilder.DropColumn(
                name: "SellerID",
                table: "client");

            migrationBuilder.DropColumn(
                name: "client_status_id",
                table: "client");

            migrationBuilder.DropColumn(
                name: "email",
                table: "client");

            migrationBuilder.DropColumn(
                name: "phonenumber",
                table: "client");

            migrationBuilder.DropColumn(
                name: "whatsapp_id",
                table: "client");

            migrationBuilder.RenameColumn(
                name: "company_id",
                table: "company",
                newName: "CompanyID");

            migrationBuilder.RenameColumn(
                name: "company_id",
                table: "client",
                newName: "CompanyID");

            migrationBuilder.RenameColumn(
                name: "client_id",
                table: "client",
                newName: "ClientID");

            migrationBuilder.RenameIndex(
                name: "IX_client_company_id",
                table: "client",
                newName: "IX_client_CompanyID");

            migrationBuilder.AddForeignKey(
                name: "FK_client_company_CompanyID",
                table: "client",
                column: "CompanyID",
                principalTable: "company",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
