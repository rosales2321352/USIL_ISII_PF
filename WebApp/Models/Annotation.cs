namespace WebApp.Models
{
    public class Annotation
    {
        public int AnnotationID { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        //TODO Normalizar tabla
        public string Status { get; set; } = null!;
        public int SellerID { get; set; }
        public virtual Seller Seller { get; set; } = null!;
        public int ClientID { get; set; }
        public virtual Client Client { get; set; } = null!;
    }
}