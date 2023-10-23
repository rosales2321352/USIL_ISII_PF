namespace WebApp.Models
{
    public class AnnotationType
    {
        public int AnnotationTypeID { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Annotation> Annotations { get; } = new List<Annotation>();
    }
}