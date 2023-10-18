﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp.Data;

#nullable disable

namespace WebApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebApp.Data.Message", b =>
                {
                    b.Property<string>("MessageID")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("message_id");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("text");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp")
                        .HasColumnName("timestamp");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("type");

                    b.Property<string>("WhatsappID")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("whatsapp_id");

                    b.HasKey("MessageID");

                    b.HasIndex("WhatsappID");

                    b.ToTable("message", (string)null);
                });

            modelBuilder.Entity("WebApp.Data.WhatsappData", b =>
                {
                    b.Property<string>("WhatsappID")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("whatsapp_id");

                    b.Property<DateTime>("FirstMessageDate")
                        .HasColumnType("datetime")
                        .HasColumnName("first_message_date");

                    b.Property<string>("PhonenumberCode")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("phonenumber_code");

                    b.Property<string>("WhatsappName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("whatsapp_name");

                    b.HasKey("WhatsappID");

                    b.ToTable("whatsapp_data", (string)null);
                });

            modelBuilder.Entity("WebApp.Models.Annotation", b =>
                {
                    b.Property<int>("AnnotationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("annotation_id");

                    b.Property<int>("ClientID")
                        .HasColumnType("int")
                        .HasColumnName("client_id");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("description");

                    b.Property<int>("SellerID")
                        .HasColumnType("int")
                        .HasColumnName("seller_id");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("title");

                    b.HasKey("AnnotationID");

                    b.HasIndex("ClientID");

                    b.HasIndex("SellerID");

                    b.ToTable("annotation", (string)null);
                });

            modelBuilder.Entity("WebApp.Models.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("int")
                        .HasColumnName("client_id");

                    b.Property<int>("ClientStatusID")
                        .HasColumnType("int")
                        .HasColumnName("client_status_id");

                    b.Property<int>("CompanyID")
                        .HasColumnType("int")
                        .HasColumnName("company_id");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("name");

                    b.Property<string>("Phonenumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phonenumber");

                    b.Property<int>("SellerID")
                        .HasColumnType("int")
                        .HasColumnName("seller_id");

                    b.Property<string>("WhatsappID")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("whatsapp_id");

                    b.HasKey("ClientID");

                    b.HasIndex("ClientStatusID");

                    b.HasIndex("CompanyID");

                    b.HasIndex("SellerID");

                    b.HasIndex("WhatsappID")
                        .IsUnique();

                    b.ToTable("client", (string)null);
                });

            modelBuilder.Entity("WebApp.Models.ClientStatus", b =>
                {
                    b.Property<int>("ClientStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("client_status_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("ClientStatusID");

                    b.ToTable("client_status", (string)null);
                });

            modelBuilder.Entity("WebApp.Models.Company", b =>
                {
                    b.Property<int>("CompanyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("company_id");

                    b.Property<string>("Address")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("address");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("name");

                    b.HasKey("CompanyID");

                    b.ToTable("company", (string)null);
                });

            modelBuilder.Entity("WebApp.Models.Event", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("event_id");

                    b.Property<int>("ClientID")
                        .HasColumnType("int")
                        .HasColumnName("client_id");

                    b.Property<DateOnly>("DateAssigned")
                        .HasColumnType("date")
                        .HasColumnName("date_assigned");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("description");

                    b.Property<int>("SellerID")
                        .HasColumnType("int")
                        .HasColumnName("seller_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("title");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("type");

                    b.HasKey("EventID");

                    b.HasIndex("ClientID");

                    b.HasIndex("SellerID");

                    b.ToTable("event", (string)null);
                });

            modelBuilder.Entity("WebApp.Models.Opportunity", b =>
                {
                    b.Property<int>("OpportunityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("opportunity_id");

                    b.Property<int>("ClientID")
                        .HasColumnType("int")
                        .HasColumnName("client_id");

                    b.Property<DateOnly>("CreationDate")
                        .HasColumnType("date")
                        .HasColumnName("creation_date");

                    b.Property<int>("OpportunityStatusID")
                        .HasColumnType("int")
                        .HasColumnName("order_status_id");

                    b.Property<int>("SellerID")
                        .HasColumnType("int")
                        .HasColumnName("seller_id");

                    b.HasKey("OpportunityID");

                    b.HasIndex("ClientID");

                    b.HasIndex("OpportunityStatusID");

                    b.HasIndex("SellerID");

                    b.ToTable("opportunity", (string)null);
                });

            modelBuilder.Entity("WebApp.Models.OpportunityStatus", b =>
                {
                    b.Property<int>("OpportunityStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("opportunity_status_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("OpportunityStatusID");

                    b.ToTable("opportunity_status", (string)null);
                });

            modelBuilder.Entity("WebApp.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<DateOnly>("AcceptionDate")
                        .HasColumnType("date")
                        .HasColumnName("acception_date");

                    b.Property<int>("ClientID")
                        .HasColumnType("int")
                        .HasColumnName("client_id");

                    b.Property<string>("ContactName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("contact_name");

                    b.Property<DateOnly>("CreationDate")
                        .HasColumnType("date")
                        .HasColumnName("creation_date");

                    b.Property<string>("GeographicLocation")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("geographical_location");

                    b.Property<int>("OrderStatusID")
                        .HasColumnType("int")
                        .HasColumnName("order_status_id");

                    b.Property<int>("SellerID")
                        .HasColumnType("int")
                        .HasColumnName("seller_id");

                    b.Property<string>("ShippingAddress")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("shipping_address");

                    b.HasKey("OrderID");

                    b.HasIndex("ClientID");

                    b.HasIndex("OrderStatusID");

                    b.HasIndex("SellerID");

                    b.ToTable("order", (string)null);
                });

            modelBuilder.Entity("WebApp.Models.OrderStatus", b =>
                {
                    b.Property<int>("OrderStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("order_status_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("OrderStatusID");

                    b.ToTable("order_status", (string)null);
                });

            modelBuilder.Entity("WebApp.Models.Seller", b =>
                {
                    b.Property<int>("SellerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("seller_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("name");

                    b.Property<string>("Phonenumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phonenumber");

                    b.HasKey("SellerID");

                    b.ToTable("seller", (string)null);
                });

            modelBuilder.Entity("WebApp.Data.Message", b =>
                {
                    b.HasOne("WebApp.Data.WhatsappData", "WhatsappData")
                        .WithMany("Messages")
                        .HasForeignKey("WhatsappID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WhatsappData");
                });

            modelBuilder.Entity("WebApp.Models.Annotation", b =>
                {
                    b.HasOne("WebApp.Models.Client", "Client")
                        .WithMany("Annotations")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Models.Seller", "Seller")
                        .WithMany("Annotations")
                        .HasForeignKey("SellerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("WebApp.Models.Client", b =>
                {
                    b.HasOne("WebApp.Models.ClientStatus", "ClientStatus")
                        .WithMany("Clients")
                        .HasForeignKey("ClientStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Models.Company", "Company")
                        .WithMany("Clients")
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Models.Seller", "Seller")
                        .WithMany("Clients")
                        .HasForeignKey("SellerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Data.WhatsappData", "WhatsappData")
                        .WithOne("Client")
                        .HasForeignKey("WebApp.Models.Client", "WhatsappID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientStatus");

                    b.Navigation("Company");

                    b.Navigation("Seller");

                    b.Navigation("WhatsappData");
                });

            modelBuilder.Entity("WebApp.Models.Event", b =>
                {
                    b.HasOne("WebApp.Models.Client", "Client")
                        .WithMany("Events")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Models.Seller", "Seller")
                        .WithMany("Events")
                        .HasForeignKey("SellerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("WebApp.Models.Opportunity", b =>
                {
                    b.HasOne("WebApp.Models.Client", "Client")
                        .WithMany("Opportunities")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Models.OpportunityStatus", "OpportunityStatus")
                        .WithMany("Opportunities")
                        .HasForeignKey("OpportunityStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Models.Seller", "Seller")
                        .WithMany("Opportunities")
                        .HasForeignKey("SellerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("OpportunityStatus");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("WebApp.Models.Order", b =>
                {
                    b.HasOne("WebApp.Models.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Models.OrderStatus", "OrderStatus")
                        .WithMany("Orders")
                        .HasForeignKey("OrderStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Models.Seller", "Seller")
                        .WithMany("Orders")
                        .HasForeignKey("SellerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("OrderStatus");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("WebApp.Data.WhatsappData", b =>
                {
                    b.Navigation("Client")
                        .IsRequired();

                    b.Navigation("Messages");
                });

            modelBuilder.Entity("WebApp.Models.Client", b =>
                {
                    b.Navigation("Annotations");

                    b.Navigation("Events");

                    b.Navigation("Opportunities");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("WebApp.Models.ClientStatus", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("WebApp.Models.Company", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("WebApp.Models.OpportunityStatus", b =>
                {
                    b.Navigation("Opportunities");
                });

            modelBuilder.Entity("WebApp.Models.OrderStatus", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("WebApp.Models.Seller", b =>
                {
                    b.Navigation("Annotations");

                    b.Navigation("Clients");

                    b.Navigation("Events");

                    b.Navigation("Opportunities");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
