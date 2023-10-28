namespace WebApp;

public class AnnotationView
{
    public int ClientID { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public int AnnotationTypeID { get; set; }

}

public class AnnotationUpdate
{
    public int AnnotationID {get; set;}
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public int AnnotationTypeID { get; set; }
}