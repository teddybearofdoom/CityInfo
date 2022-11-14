using CSGSI_FrontEnd.ViewModels.Engagment_Models;

namespace CSGSI_FrontEnd.HistoricalDatabaseModels
{
    public class TeamProfile
    {
        public string Name { get; set; }
        public string side { get; set; }
        public Kills kills { get; set; }
        public Engagements engagements { get; set; }
        public RadialPositioning radialPositioning { get; set; }
        public Utility utility { get; set; }
        public Counters counters { get; set; }
        public List<PlayerProfile> playerProfiles { get; set; }
        public TeamProfile()
        {
            Name = " ";
            side = " ";
            kills = new Kills();
            engagements = new Engagements();
            radialPositioning = new RadialPositioning();
            utility = new Utility();
            counters = new Counters();
            playerProfiles = new List<PlayerProfile>();
        }
    }
}
