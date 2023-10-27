namespace WebApp.Models
{
    public class OpportunityStatus
    {
        public int OpportunityStatusID { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Opportunity> Opportunities { get; } = new List<Opportunity>();
        public ICollection<OpportunityStatusHistory> OpportunityStatusHistories { get; } = new List<OpportunityStatusHistory>();
    }
}