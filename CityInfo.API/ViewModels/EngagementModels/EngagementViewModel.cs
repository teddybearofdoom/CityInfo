namespace CSGSI_FrontEnd.ViewModels.Engagment_Models
{
    public class EngagementViewModel
    {
        List<Engagement> engagements { get; set; }
        public EngagementViewModel(List<Engagement> engagements)
        {
            this.engagements = engagements;
        }
    }
}
