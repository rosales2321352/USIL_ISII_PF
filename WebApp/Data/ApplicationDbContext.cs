using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Seller> Sellers { get; set; } = null!;
        public DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
        public DbSet<ClientStatus> ClientStatuses { get; set; } = null!;
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<Annotation> Annotations { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OpportunityStatus> OpportunityStatuses { get; set; } = null!;
        public DbSet<Opportunity> Opportunities { get; set; } = null!;
        public DbSet<WhatsappData> WhatsappDatas { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //* OpportunityStatus

            modelBuilder.Entity<OpportunityStatus>(entity =>
            {
                entity.ToTable("opportunity_status");

                entity.Property(e => e.OpportunityStatusID).HasColumnName("opportunity_status_id");
                entity.Property(e => e.Name).HasMaxLength(50).HasColumnName("name");
            });

            modelBuilder.Entity<OpportunityStatus>().HasMany(e => e.Opportunities).WithOne(e => e.OpportunityStatus).HasForeignKey(e => e.OpportunityStatusID).IsRequired();


            //* Seller
            modelBuilder.Entity<Seller>(entity =>
            {
                entity.ToTable("seller");

                entity.Property(e => e.SellerID).HasColumnName("seller_id");
                entity.Property(e => e.Name).HasMaxLength(200).HasColumnName("name");
                entity.Property(e => e.Phonenumber).HasMaxLength(20).HasColumnName("phonenumber");
            });

            modelBuilder.Entity<Seller>().HasMany(e => e.Clients).WithOne(e => e.Seller).HasForeignKey(e => e.SellerID).IsRequired();
            modelBuilder.Entity<Seller>().HasMany(e => e.Events).WithOne(e => e.Seller).HasForeignKey(e => e.SellerID).IsRequired();
            modelBuilder.Entity<Seller>().HasMany(e => e.Annotations).WithOne(e => e.Seller).HasForeignKey(e => e.SellerID).IsRequired();

            //* Company
            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.Property(e => e.CompanyID).HasColumnName("company_id");
                entity.Property(e => e.Name).HasMaxLength(200).HasColumnName("name");
                entity.Property(e => e.Address).HasMaxLength(500).HasColumnName("address");
                entity.Property(e => e.Email).HasMaxLength(100).HasColumnName("email");

            });

            modelBuilder.Entity<Company>().HasMany(e => e.Clients).WithOne(e => e.Company).HasForeignKey(e => e.CompanyID).IsRequired();

            //* ClientStatus
            modelBuilder.Entity<ClientStatus>(entity =>
            {
                entity.ToTable("client_status");

                entity.Property(e => e.ClientStatusID).HasColumnName("client_status_id");
                entity.Property(e => e.Name).HasMaxLength(50).HasColumnName("name");
            });

            modelBuilder.Entity<ClientStatus>().HasMany(e => e.Clients).WithOne(e => e.ClientStatus).HasForeignKey(e => e.ClientStatusID).IsRequired();

            //* Client
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.ClientID).HasMaxLength(200).HasColumnName("client_id");
                entity.Property(e => e.Name).HasMaxLength(200).HasColumnName("name");
                entity.Property(e => e.Phonenumber).HasMaxLength(20).HasColumnName("phonenumber");
                entity.Property(e => e.Email).HasMaxLength(100).HasColumnName("email");
                entity.Property(e => e.ClientStatusID).HasColumnName("client_status_id");
                entity.Property(e => e.CompanyID).HasColumnName("company_id");
                entity.Property(e => e.SellerID).HasColumnName("seller_id");
                entity.Property(e => e.WhatsappID).HasMaxLength(25).HasColumnName("whatsapp_id");
            });

            modelBuilder.Entity<Client>().HasOne(e => e.Company).WithMany(e => e.Clients).HasForeignKey(e => e.CompanyID).IsRequired();
            modelBuilder.Entity<Client>().HasOne(e => e.ClientStatus).WithMany(e => e.Clients).HasForeignKey(e => e.ClientStatusID).IsRequired();
            modelBuilder.Entity<Client>().HasOne(e => e.Seller).WithMany(e => e.Clients).HasForeignKey(e => e.SellerID).IsRequired();

            modelBuilder.Entity<Client>().HasMany(e => e.Events).WithOne(e => e.Client).HasForeignKey(e => e.ClientID).IsRequired();
            modelBuilder.Entity<Client>().HasMany(e => e.Annotations).WithOne(e => e.Client).HasForeignKey(e => e.ClientID).IsRequired();

            modelBuilder.Entity<Client>().HasOne(e => e.WhatsappData).WithOne(e => e.Client).HasForeignKey<Client>(e => e.WhatsappID).IsRequired();

            //* OrderStatus
            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("order_status");

                entity.Property(e => e.OrderStatusID).HasColumnName("order_status_id");
                entity.Property(e => e.Name).HasMaxLength(50).HasColumnName("name");
            });

            modelBuilder.Entity<OrderStatus>().HasMany(e => e.Orders).WithOne(e => e.OrderStatus).HasForeignKey(e => e.OrderStatusID).IsRequired();

            //* Event

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("event");

                entity.Property(e => e.EventID).HasColumnName("event_id");
                entity.Property(e => e.Title).HasMaxLength(100).HasColumnName("title");
                entity.Property(e => e.Type).HasMaxLength(15).HasColumnName("type");
                entity.Property(e => e.Description).HasMaxLength(500).HasColumnName("description");
                entity.Property(e => e.DateAssigned).HasColumnType("date").HasColumnName("date_assigned"); //! Probar
                entity.Property(e => e.ClientID).HasColumnName("client_id");
                entity.Property(e => e.SellerID).HasColumnName("seller_id");
            });

            modelBuilder.Entity<Event>().HasOne(e => e.Client).WithMany(e => e.Events).HasForeignKey(e => e.ClientID).IsRequired();
            modelBuilder.Entity<Event>().HasOne(e => e.Seller).WithMany(e => e.Events).HasForeignKey(e => e.SellerID).IsRequired();


            //* Annotation

            modelBuilder.Entity<Annotation>(entity =>
            {
                entity.ToTable("annotation");

                entity.Property(e => e.AnnotationID).HasColumnName("annotation_id");
                entity.Property(e => e.Title).HasMaxLength(100).HasColumnName("title");
                entity.Property(e => e.Description).HasMaxLength(2000).HasColumnName("description");
                entity.Property(e => e.Status).HasMaxLength(50).HasColumnName("status");
                entity.Property(e => e.ClientID).HasColumnName("client_id");
                entity.Property(e => e.SellerID).HasColumnName("seller_id");

            });

            modelBuilder.Entity<Annotation>().HasOne(e => e.Client).WithMany(e => e.Annotations).HasForeignKey(e => e.ClientID).IsRequired();
            modelBuilder.Entity<Annotation>().HasOne(e => e.Seller).WithMany(e => e.Annotations).HasForeignKey(e => e.SellerID).IsRequired();

            //* Order

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.Property(e => e.OrderID).HasColumnName("order_id");
                entity.Property(e => e.CreationDate).HasColumnType("date").HasColumnName("creation_date");
                entity.Property(e => e.AcceptionDate).HasColumnType("date").HasColumnName("acception_date");
                entity.Property(e => e.ShippingAddress).HasMaxLength(200).HasColumnName("shipping_address");
                entity.Property(e => e.GeographicLocation).HasMaxLength(200).HasColumnName("geographical_location");
                entity.Property(e => e.ContactName).HasMaxLength(100).HasColumnName("contact_name");
                entity.Property(e => e.ClientID).HasColumnName("client_id");
                entity.Property(e => e.SellerID).HasColumnName("seller_id");
                entity.Property(e => e.OrderStatusID).HasColumnName("order_status_id");
            });

            modelBuilder.Entity<Order>().HasOne(e => e.Client).WithMany(e => e.Orders).HasForeignKey(e => e.ClientID).IsRequired();
            modelBuilder.Entity<Order>().HasOne(e => e.Seller).WithMany(e => e.Orders).HasForeignKey(e => e.SellerID).IsRequired();
            modelBuilder.Entity<Order>().HasOne(e => e.OrderStatus).WithMany(e => e.Orders).HasForeignKey(e => e.OrderStatusID).IsRequired();

            //* Opportunity

            modelBuilder.Entity<Opportunity>(entity =>
            {
                entity.ToTable("opportunity");

                entity.Property(e => e.OpportunityID).HasColumnName("opportunity_id");
                entity.Property(e => e.CreationDate).HasColumnType("date").HasColumnName("creation_date");
                entity.Property(e => e.ClientID).HasColumnName("client_id");
                entity.Property(e => e.SellerID).HasColumnName("seller_id");
                entity.Property(e => e.OpportunityStatusID).HasColumnName("order_status_id");
            });

            modelBuilder.Entity<Opportunity>().HasOne(e => e.Client).WithMany(e => e.Opportunities).HasForeignKey(e => e.ClientID).IsRequired();
            modelBuilder.Entity<Opportunity>().HasOne(e => e.Seller).WithMany(e => e.Opportunities).HasForeignKey(e => e.SellerID).IsRequired();
            modelBuilder.Entity<Opportunity>().HasOne(e => e.OpportunityStatus).WithMany(e => e.Opportunities).HasForeignKey(e => e.OpportunityStatusID).IsRequired();

            //* Message

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("message");
                
                entity.Property(e => e.MessageID).HasMaxLength(25).HasColumnName("message_id");
                entity.Property(e => e.Timestamp).HasColumnType("timestamp").HasColumnName("timestamp");
                entity.Property(e => e.WhatsappID).HasMaxLength(25).HasColumnName("whatsapp_id");
                entity.Property(e => e.Type).HasMaxLength(25).HasColumnName("type");
                entity.Property(e => e.Text).HasMaxLength(2000).HasColumnName("text");
            });

            modelBuilder.Entity<Message>().HasOne(e => e.WhatsappData).WithMany(e => e.Messages).HasForeignKey(e => e.WhatsappID).IsRequired();


            //*WhatsappData

            modelBuilder.Entity<WhatsappData>(entity =>
            {
                entity.ToTable("whatsapp_data");

                entity.Property(e => e.WhatsappID).HasMaxLength(25).HasColumnName("whatsapp_id");
                entity.Property(e => e.FirstMessageDate).HasColumnType("datetime").HasColumnName("first_message_date");
                entity.Property(e => e.PhonenumberCode).HasMaxLength(15).HasColumnName("phonenumber_code");
                entity.Property(e => e.WhatsappName).HasMaxLength(50).HasColumnName("whatsapp_name");
            });

            modelBuilder.Entity<WhatsappData>().HasKey(e => e.WhatsappID);
            modelBuilder.Entity<WhatsappData>().HasOne(e => e.Client).WithOne(e => e.WhatsappData).HasForeignKey<Client>(e => e.WhatsappID).IsRequired();
            modelBuilder.Entity<WhatsappData>().HasMany(e => e.Messages).WithOne(e => e.WhatsappData).HasForeignKey(e => e.WhatsappID).IsRequired();


        }
    }
}
