namespace WebApp.Models
{
    public class Opportunity
    {
        public int OpportunityID { get; set; }
        public DateOnly CreationDate { get; set; }
        public int OpportunityStatusID { get; set; }
        public virtual OpportunityStatus OpportunityStatus { get; set; } = null!;
        public int ClientID { get; set; }
        public virtual Client Client { get; set; } = null!;
        public int SellerID { get; set; }
        public virtual Seller Seller { get; set; } = null!;
        public ICollection<OpportunityStatusHistory> OpportunityStatusHistories { get; set; } = new List<OpportunityStatusHistory>();
    }
}