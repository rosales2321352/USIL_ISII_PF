using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Person> People { get; set; }
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Seller> Sellers { get; set; } = null!;
        public DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
        public DbSet<AnnotationType> AnnotationTypes { get; set; } = null!;
        public DbSet<EventType> EventTypes { get; set; } = null!;
        public DbSet<ClientStatus> ClientStatuses { get; set; } = null!;
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<Annotation> Annotations { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderStatusHistory> OrderStatusHistories { get; set; } = null!;
        public DbSet<OpportunityStatus> OpportunityStatuses { get; set; } = null!;
        public DbSet<Opportunity> Opportunities { get; set; } = null!;
        public DbSet<OpportunityStatusHistory> OpportunityStatusHistories { get; set; } = null!;
        public DbSet<WhatsappData> WhatsappDatas { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;
        public DbSet<Conversation> Conversations { get; set; } = null!;
        public DbSet<TextMessage> TextMessages { get; set; } = null!;
        public DbSet<MessageType> MessageTypes { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //* TextMessage

            modelBuilder.Entity<TextMessage>(entity =>{
                entity.ToTable("text_message");

                entity.Property(e => e.Text).HasMaxLength(2000).HasColumnName("text");
            });

            modelBuilder.Entity<TextMessage>().HasBaseType<Message>();

            //* MessageType

            modelBuilder.Entity<MessageType>(entity =>
            {
                entity.ToTable("message_type");

                entity.Property(e => e.MessageTypeId).HasColumnName("message_type_id");
                entity.Property(e => e.Name).HasMaxLength(50).HasColumnName("name");
            });

            modelBuilder.Entity<MessageType>().HasMany(e => e.Messages).WithOne(e => e.MessageType).HasForeignKey(e => e.MessageTypeId).IsRequired();

            //* Person

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.PersonId).HasColumnName("person_id");
                entity.Property(e => e.Name).HasMaxLength(200).HasColumnName("name");
                entity.Property(e => e.PhoneNumber).HasMaxLength(20).HasColumnName("phonenumber");
                entity.Property(e => e.Email).HasMaxLength(100).HasColumnName("email");
                entity.Property(e => e.WhatsappID).HasMaxLength(100).HasColumnName("whatsapp_id");
            });

            modelBuilder.Entity<Person>().HasOne(e => e.WhatsappData).WithOne(e => e.Person).HasForeignKey<Person>(e => e.WhatsappID).IsRequired();

            //* OpportunityStatus

            modelBuilder.Entity<OpportunityStatus>(entity =>
            {
                entity.ToTable("opportunity_status");

                entity.Property(e => e.OpportunityStatusID).HasColumnName("opportunity_status_id");
                entity.Property(e => e.Name).HasMaxLength(50).HasColumnName("name");
            });

            modelBuilder.Entity<OpportunityStatus>().HasMany(e => e.Opportunities).WithOne(e => e.OpportunityStatus).HasForeignKey(e => e.OpportunityStatusID).IsRequired();
            modelBuilder.Entity<OpportunityStatus>().HasMany(e => e.OpportunityStatusHistories).WithOne(e => e.OpportunityStatus).HasForeignKey(e => e.OpportunityStatusID).IsRequired();

            //* AnnotationType

            modelBuilder.Entity<AnnotationType>(entity =>
            {
                entity.ToTable("annotation_type");

                entity.Property(e => e.AnnotationTypeID).HasColumnName("annotation_type_id");
                entity.Property(e => e.Name).HasMaxLength(50).HasColumnName("name");
            });

            modelBuilder.Entity<AnnotationType>().HasMany(e => e.Annotations).WithOne(e => e.AnnotationType).HasForeignKey(e => e.AnnotationTypeID).IsRequired();

            //* EventType

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.ToTable("event_type");

                entity.Property(e => e.EventTypeID).HasColumnName("event_type_id");
                entity.Property(e => e.Name).HasMaxLength(50).HasColumnName("name");
            });

            modelBuilder.Entity<EventType>().HasMany(e => e.Events).WithOne(e => e.EventType).HasForeignKey(e => e.EventTypeID).IsRequired();

            //* Seller

            modelBuilder.Entity<Seller>().HasBaseType<Person>();

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.ToTable("seller");

                entity.Property(e => e.SellerID).HasColumnName("seller_id");
                entity.Property(e => e.Username).HasMaxLength(200).HasColumnName("username");
                entity.Property(e => e.Password).HasMaxLength(200).HasColumnName("password");
            });

            modelBuilder.Entity<Seller>().HasMany(e => e.Clients).WithOne(e => e.Seller).HasForeignKey(e => e.SellerID).IsRequired();
            modelBuilder.Entity<Seller>().HasMany(e => e.Events).WithOne(e => e.Seller).HasForeignKey(e => e.SellerID).IsRequired();
            modelBuilder.Entity<Seller>().HasMany(e => e.Annotations).WithOne(e => e.Seller).HasForeignKey(e => e.SellerID).IsRequired();

            modelBuilder.Entity<Seller>().HasMany(e => e.Orders).WithOne(e => e.Seller).HasForeignKey(e => e.SellerID).IsRequired();
            modelBuilder.Entity<Seller>().HasMany(e => e.Opportunities).WithOne(e => e.Seller).HasForeignKey(e => e.SellerID).IsRequired();


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

            modelBuilder.Entity<Client>().HasBaseType<Person>();

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.ClientID).HasColumnName("client_id");
                entity.Property(e => e.ClientStatusID).HasColumnName("client_status_id");
                entity.Property(e => e.CompanyID).HasColumnName("company_id");
                entity.Property(e => e.SellerID).HasColumnName("seller_id");
            });

            modelBuilder.Entity<Client>().HasOne(e => e.Company).WithMany(e => e.Clients).HasForeignKey(e => e.CompanyID).IsRequired();
            modelBuilder.Entity<Client>().HasOne(e => e.ClientStatus).WithMany(e => e.Clients).HasForeignKey(e => e.ClientStatusID).IsRequired();
            modelBuilder.Entity<Client>().HasOne(e => e.Seller).WithMany(e => e.Clients).HasForeignKey(e => e.SellerID).IsRequired();

            modelBuilder.Entity<Client>().HasMany(e => e.Events).WithOne(e => e.Client).HasForeignKey(e => e.ClientID).IsRequired();
            modelBuilder.Entity<Client>().HasMany(e => e.Annotations).WithOne(e => e.Client).HasForeignKey(e => e.ClientID).IsRequired();
            modelBuilder.Entity<Client>().HasMany(e => e.Orders).WithOne(e => e.Client).HasForeignKey(e => e.ClientID).IsRequired();
            modelBuilder.Entity<Client>().HasMany(e => e.Opportunities).WithOne(e => e.Client).HasForeignKey(e => e.ClientID).IsRequired();




            //* OrderStatus
            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("order_status");

                entity.Property(e => e.OrderStatusID).HasColumnName("order_status_id");
                entity.Property(e => e.Name).HasMaxLength(50).HasColumnName("name");
            });

            modelBuilder.Entity<OrderStatus>().HasMany(e => e.Orders).WithOne(e => e.OrderStatus).HasForeignKey(e => e.OrderStatusID).IsRequired();
            modelBuilder.Entity<OrderStatus>().HasMany(e => e.OrderStatusHistories).WithOne(e => e.OrderStatus).HasForeignKey(e => e.OrderStatusID).IsRequired();

            //* Event   

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("event");

                entity.Property(e => e.EventID).HasColumnName("event_id");
                entity.Property(e => e.Title).HasMaxLength(100).HasColumnName("title");
                entity.Property(e => e.EventTypeID).HasColumnName("event_type_id");
                entity.Property(e => e.Description).HasMaxLength(500).HasColumnName("description");
                entity.Property(e => e.DateAssigned).HasColumnType("date").HasColumnName("date_assigned"); //! Probar
                entity.Property(e => e.ClientID).HasColumnName("client_id");
                entity.Property(e => e.SellerID).HasColumnName("seller_id");
            });

            modelBuilder.Entity<Event>().HasOne(e => e.Client).WithMany(e => e.Events).HasForeignKey(e => e.ClientID).IsRequired();
            modelBuilder.Entity<Event>().HasOne(e => e.Seller).WithMany(e => e.Events).HasForeignKey(e => e.SellerID).IsRequired();
            modelBuilder.Entity<Event>().HasOne(e => e.EventType).WithMany(e => e.Events).HasForeignKey(e => e.EventTypeID).IsRequired();

            //* Annotation

            modelBuilder.Entity<Annotation>(entity =>
            {
                entity.ToTable("annotation");

                entity.Property(e => e.AnnotationID).HasColumnName("annotation_id");
                entity.Property(e => e.Title).HasMaxLength(100).HasColumnName("title");
                entity.Property(e => e.Description).HasMaxLength(2000).HasColumnName("description");
                entity.Property(e => e.AnnotationTypeID).HasColumnName("annotation_type_id");
                entity.Property(e => e.ClientID).HasColumnName("client_id");
                entity.Property(e => e.SellerID).HasColumnName("seller_id");

            });

            modelBuilder.Entity<Annotation>().HasOne(e => e.Client).WithMany(e => e.Annotations).HasForeignKey(e => e.ClientID).IsRequired();
            modelBuilder.Entity<Annotation>().HasOne(e => e.Seller).WithMany(e => e.Annotations).HasForeignKey(e => e.SellerID).IsRequired();
            modelBuilder.Entity<Annotation>().HasOne(e => e.AnnotationType).WithMany(e => e.Annotations).HasForeignKey(e => e.AnnotationTypeID).IsRequired();


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

            modelBuilder.Entity<Order>().HasMany(e => e.OrderStatusHistories).WithOne(e => e.Order).HasForeignKey(e => e.OrderID).IsRequired();

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

            modelBuilder.Entity<Opportunity>().HasMany(e => e.OpportunityStatusHistories).WithOne(e => e.Opportunity).HasForeignKey(e => e.OpportunityID).IsRequired();

            //* OpportunityStatusHistory

            modelBuilder.Entity<OpportunityStatusHistory>(entity =>
            {
                entity.ToTable("opportunity_status_history");

                entity.Property(e => e.OpportunityStatusHistoryID).HasColumnName("opportunity_status_history_id");
                entity.Property(e => e.OpportunityID).HasColumnName("opportunity_id");
                entity.Property(e => e.OpportunityStatusID).HasColumnName("opportunity_status_id");
                entity.Property(e => e.UpdateDate).HasColumnType("date").HasColumnName("update_date");
                entity.Property(e => e.Comment).HasMaxLength(200).HasColumnName("comment");
            });

            modelBuilder.Entity<OpportunityStatusHistory>().HasOne(e => e.Opportunity).WithMany(e => e.OpportunityStatusHistories).HasForeignKey(e => e.OpportunityID).IsRequired();
            modelBuilder.Entity<OpportunityStatusHistory>().HasOne(e => e.OpportunityStatus).WithMany(e => e.OpportunityStatusHistories).HasForeignKey(e => e.OpportunityStatusID).IsRequired();

            //* OrderStatusHistory

            modelBuilder.Entity<OrderStatusHistory>(entity =>
            {
                entity.ToTable("order_status_history");

                entity.Property(e => e.OrderStatusHistoryID).HasColumnName("order_status_history_id");
                entity.Property(e => e.OrderID).HasColumnName("order_id");
                entity.Property(e => e.OrderStatusID).HasColumnName("order_status_id");
                entity.Property(e => e.UpdateDate).HasColumnType("date").HasColumnName("update_date");
                entity.Property(e => e.Comment).HasMaxLength(200).HasColumnName("comment");
            });

            modelBuilder.Entity<OrderStatusHistory>().HasOne(e => e.Order).WithMany(e => e.OrderStatusHistories).HasForeignKey(e => e.OrderID).IsRequired();
            modelBuilder.Entity<OrderStatusHistory>().HasOne(e => e.OrderStatus).WithMany(e => e.OrderStatusHistories).HasForeignKey(e => e.OrderStatusID).IsRequired();

            //* Message

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("message");

                entity.Property(e => e.MessageID).HasMaxLength(25).HasColumnName("message_id");
                entity.Property(e => e.ConversationID).HasColumnName("conversation_id");
                entity.Property(e => e.Timestamp).HasColumnType("timestamp").HasColumnName("timestamp");
                entity.Property(e => e.WhatsappID).HasMaxLength(25).HasColumnName("whatsapp_id");
                entity.Property(e => e.MessageTypeId).HasMaxLength(2000).HasColumnName("message_type_id");
            });

            modelBuilder.Entity<Message>().HasOne(e => e.Conversation).WithMany(e => e.Messages).HasForeignKey(e => e.ConversationID).IsRequired();
            modelBuilder.Entity<Message>().HasOne(e => e.MessageType).WithMany(e => e.Messages).HasForeignKey(e => e.MessageTypeId).IsRequired();

            //*WhatsappData

            modelBuilder.Entity<WhatsappData>(entity =>
            {
                entity.ToTable("whatsapp_data");

                entity.Property(e => e.WhatsappID).HasMaxLength(25).HasColumnName("whatsapp_id");
                entity.Property(e => e.PhonenumberCode).HasMaxLength(15).HasColumnName("phonenumber_code");
                entity.Property(e => e.WhatsappName).HasMaxLength(50).HasColumnName("whatsapp_name");
            });

            modelBuilder.Entity<WhatsappData>().HasKey(e => e.WhatsappID);
            modelBuilder.Entity<WhatsappData>().HasOne(e => e.Person).WithOne(e => e.WhatsappData).HasForeignKey<Person>(e => e.WhatsappID).IsRequired();

        }
    }
}
