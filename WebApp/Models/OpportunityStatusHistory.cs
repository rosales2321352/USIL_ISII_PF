namespace WebApp.Models
{
    public class OpportunityStatusHistory
    {
        public int OpportunityStatusHistoryID { get; set; }
        public DateOnly UpdateDate { get; set; }
        public string? Comment { get; set; }
        public int OpportunityID { get; set; }
        public Opportunity Opportunity { get; set; } = null!;
        public int OpportunityStatusID { get; set; }
        public OpportunityStatus OpportunityStatus { get; } = null!;
    }
}