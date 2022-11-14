namespace CSGSI_FrontEnd.HistoricalDatabaseModels
{
    public class Engagements
    {
        public List<HistoricalDetailedEngagement> roundEngagements { get; set; }
        public Engagements()
        {
            roundEngagements = new List<HistoricalDetailedEngagement>();
        }
    }
}
