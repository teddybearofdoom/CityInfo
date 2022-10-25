namespace CSGSI_FrontEnd.ViewModels.Engagment_Models
{
    public class ListofDetailEngagement
    {
        public int round { get; set; }
        public List<DetailEngagement> detailEngagements{get;set;}
        public ListofDetailEngagement()
        {
            detailEngagements = new List<DetailEngagement>();
        }
        
    }
}
