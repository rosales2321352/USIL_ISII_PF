namespace WebApp.Models
{
    public class AnnotationUpdate
    {
        public int AnnotationID { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int AnnotationTypeID { get; set; }
    }
}