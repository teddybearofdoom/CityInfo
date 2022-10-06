namespace CSGSI_FrontEnd.ViewModels.Engagment_Models
{
    public class EngagementModels
    {
        public List<Engagement> Engagements { get; set; }
        public EngagementModels()
        {
            Engagements = new List<Engagement>();
        }
        public void setEngagementsModel(Engagement engagement)
        {
            Engagements.Add(engagement);
        }
    }
}
