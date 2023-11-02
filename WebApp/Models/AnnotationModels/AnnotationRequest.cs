namespace WebApp.Models
{
    public class AnnotationRequest
    {
        public int ClientID { get; set; }
        public int SellerID { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int AnnotationTypeID { get; set; }
    }
}