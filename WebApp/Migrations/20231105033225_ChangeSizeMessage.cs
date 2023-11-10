using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSizeMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "annotation_type",
                columns: table => new
                {
                    annotation_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_available = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_annotation_type", x => x.annotation_type_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "client_status",
                columns: table => new
                {
                    client_status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_available = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client_status", x => x.client_status_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    company_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RUC = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_available = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValue: true),
                    address = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.company_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "event_type",
                columns: table => new
                {
                    event_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_available = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_type", x => x.event_type_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "message_type",
                columns: table => new
                {
                    message_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message_type", x => x.message_type_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "opportunity_status",
                columns: table => new
                {
                    opportunity_status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_available = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValue: true)
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
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAvailable = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_status", x => x.order_status_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "whatsapp_data",
                columns: table => new
                {
                    whatsapp_id = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                name: "person",
                columns: table => new
                {
                    person_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phonenumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    whatsapp_id = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.person_id);
                    table.ForeignKey(
                        name: "FK_person_whatsapp_data_whatsapp_id",
                        column: x => x.whatsapp_id,
                        principalTable: "whatsapp_data",
                        principalColumn: "whatsapp_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "seller",
                columns: table => new
                {
                    person_id = table.Column<int>(type: "int", nullable: false),
                    username = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seller", x => x.person_id);
                    table.ForeignKey(
                        name: "FK_seller_person_person_id",
                        column: x => x.person_id,
                        principalTable: "person",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    person_id = table.Column<int>(type: "int", nullable: false),
                    seller_id = table.Column<int>(type: "int", nullable: false),
                    client_status_id = table.Column<int>(type: "int", nullable: false),
                    company_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.person_id);
                    table.ForeignKey(
                        name: "FK_client_client_status_client_status_id",
                        column: x => x.client_status_id,
                        principalTable: "client_status",
                        principalColumn: "client_status_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_client_company_company_id",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "company_id");
                    table.ForeignKey(
                        name: "FK_client_person_person_id",
                        column: x => x.person_id,
                        principalTable: "person",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_client_seller_seller_id",
                        column: x => x.seller_id,
                        principalTable: "seller",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Cascade);
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
                    annotation_type_id = table.Column<int>(type: "int", nullable: false),
                    seller_id = table.Column<int>(type: "int", nullable: false),
                    client_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_annotation", x => x.annotation_id);
                    table.ForeignKey(
                        name: "FK_annotation_annotation_type_annotation_type_id",
                        column: x => x.annotation_type_id,
                        principalTable: "annotation_type",
                        principalColumn: "annotation_type_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_annotation_client_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_annotation_seller_seller_id",
                        column: x => x.seller_id,
                        principalTable: "seller",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "conversation",
                columns: table => new
                {
                    conversation_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    seller_id = table.Column<int>(type: "int", nullable: false),
                    client_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conversation", x => x.conversation_id);
                    table.ForeignKey(
                        name: "FK_conversation_client_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_conversation_seller_seller_id",
                        column: x => x.seller_id,
                        principalTable: "seller",
                        principalColumn: "person_id",
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
                    event_type_id = table.Column<int>(type: "int", nullable: false),
                    date_assigned = table.Column<DateOnly>(type: "date", nullable: false),
                    begin_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    end_time = table.Column<TimeSpan>(type: "time", nullable: false),
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
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_event_event_type_event_type_id",
                        column: x => x.event_type_id,
                        principalTable: "event_type",
                        principalColumn: "event_type_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_event_seller_seller_id",
                        column: x => x.seller_id,
                        principalTable: "seller",
                        principalColumn: "person_id",
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
                    opportunity_status_id = table.Column<int>(type: "int", nullable: false),
                    is_available = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValue: true),
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
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_opportunity_opportunity_status_opportunity_status_id",
                        column: x => x.opportunity_status_id,
                        principalTable: "opportunity_status",
                        principalColumn: "opportunity_status_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_opportunity_seller_seller_id",
                        column: x => x.seller_id,
                        principalTable: "seller",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    creation_date = table.Column<DateOnly>(type: "date", nullable: false),
                    shipping_address = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    geographical_location = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    contact_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    total_amount = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    is_available = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValue: true),
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
                        principalColumn: "person_id",
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
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "message",
                columns: table => new
                {
                    message_id = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    conversation_id = table.Column<int>(type: "int", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp", nullable: false),
                    whatsapp_id = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    message_type_id = table.Column<int>(type: "int", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message", x => x.message_id);
                    table.ForeignKey(
                        name: "FK_message_conversation_conversation_id",
                        column: x => x.conversation_id,
                        principalTable: "conversation",
                        principalColumn: "conversation_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_message_message_type_message_type_id",
                        column: x => x.message_type_id,
                        principalTable: "message_type",
                        principalColumn: "message_type_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "opportunity_status_history",
                columns: table => new
                {
                    opportunity_status_history_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    update_date = table.Column<DateOnly>(type: "date", nullable: false),
                    comment = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    opportunity_id = table.Column<int>(type: "int", nullable: false),
                    opportunity_status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_opportunity_status_history", x => x.opportunity_status_history_id);
                    table.ForeignKey(
                        name: "FK_opportunity_status_history_opportunity_opportunity_id",
                        column: x => x.opportunity_id,
                        principalTable: "opportunity",
                        principalColumn: "opportunity_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_opportunity_status_history_opportunity_status_opportunity_st~",
                        column: x => x.opportunity_status_id,
                        principalTable: "opportunity_status",
                        principalColumn: "opportunity_status_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "order_status_history",
                columns: table => new
                {
                    order_status_history_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    update_date = table.Column<DateOnly>(type: "date", nullable: false),
                    comment = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    order_status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_status_history", x => x.order_status_history_id);
                    table.ForeignKey(
                        name: "FK_order_status_history_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_status_history_order_status_order_status_id",
                        column: x => x.order_status_id,
                        principalTable: "order_status",
                        principalColumn: "order_status_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "text_message",
                columns: table => new
                {
                    message_id = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    text = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_text_message", x => x.message_id);
                    table.ForeignKey(
                        name: "FK_text_message_message_message_id",
                        column: x => x.message_id,
                        principalTable: "message",
                        principalColumn: "message_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_annotation_annotation_type_id",
                table: "annotation",
                column: "annotation_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_annotation_client_id",
                table: "annotation",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_annotation_seller_id",
                table: "annotation",
                column: "seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_client_client_status_id",
                table: "client",
                column: "client_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_client_company_id",
                table: "client",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_client_seller_id",
                table: "client",
                column: "seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_conversation_client_id",
                table: "conversation",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_conversation_seller_id",
                table: "conversation",
                column: "seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_event_client_id",
                table: "event",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_event_event_type_id",
                table: "event",
                column: "event_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_event_seller_id",
                table: "event",
                column: "seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_message_conversation_id",
                table: "message",
                column: "conversation_id");

            migrationBuilder.CreateIndex(
                name: "IX_message_message_type_id",
                table: "message",
                column: "message_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_opportunity_client_id",
                table: "opportunity",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_opportunity_opportunity_status_id",
                table: "opportunity",
                column: "opportunity_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_opportunity_seller_id",
                table: "opportunity",
                column: "seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_opportunity_status_history_opportunity_id",
                table: "opportunity_status_history",
                column: "opportunity_id");

            migrationBuilder.CreateIndex(
                name: "IX_opportunity_status_history_opportunity_status_id",
                table: "opportunity_status_history",
                column: "opportunity_status_id");

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

            migrationBuilder.CreateIndex(
                name: "IX_order_status_history_order_id",
                table: "order_status_history",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_status_history_order_status_id",
                table: "order_status_history",
                column: "order_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_whatsapp_id",
                table: "person",
                column: "whatsapp_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "annotation");

            migrationBuilder.DropTable(
                name: "event");

            migrationBuilder.DropTable(
                name: "opportunity_status_history");

            migrationBuilder.DropTable(
                name: "order_status_history");

            migrationBuilder.DropTable(
                name: "text_message");

            migrationBuilder.DropTable(
                name: "annotation_type");

            migrationBuilder.DropTable(
                name: "event_type");

            migrationBuilder.DropTable(
                name: "opportunity");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "message");

            migrationBuilder.DropTable(
                name: "opportunity_status");

            migrationBuilder.DropTable(
                name: "order_status");

            migrationBuilder.DropTable(
                name: "conversation");

            migrationBuilder.DropTable(
                name: "message_type");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "client_status");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "seller");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "whatsapp_data");
        }
    }
}
