using CityInfo.API.ViewModels.PlayerProfile;

namespace CSGSI_FrontEnd.ViewModels.PlayerProfile
{
    public class LivePlayerProfile
    {
        public string Name { get; set; }
        public string team { get; set; }
        public int kills{get;set;}
        public int deaths{get;set;}
        public int assists{get;set;}
        public float ADR{get;set;}
        public float UD{get;set;}
        public List<PlayerCounters> playerCounters{get;set;}
        public List<EngagementStatistics> engagementStatistics { get; set; }

        public LivePlayerProfile()
        {
            playerCounters = new List<PlayerCounters>();
            engagementStatistics = new List<EngagementStatistics>();
            IntializeEngagementStatistics();
        }
        public void IntializeEngagementStatistics()
        {
            for (int i = 5; i > 0; i--)
            {
                for (int j = 5; j > 0; j--)
                {
                    EngagementStatistics newEngagement = new EngagementStatistics();
                    newEngagement.engagementStatus = i.ToString() + "v" + j.ToString();
                    engagementStatistics.Add(newEngagement);
                }
            }
        }
    }
}
