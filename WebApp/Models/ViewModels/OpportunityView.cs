namespace WebApp;

public class OpportunityView
{
    public int OpportunityID { get; set; }
    public DateOnly CreationDate { get; set; }
    public string? ClientName { get; set; }
    public string? StatusName { get; set; }
    public int OpportunityStatusID { get; set; }
}