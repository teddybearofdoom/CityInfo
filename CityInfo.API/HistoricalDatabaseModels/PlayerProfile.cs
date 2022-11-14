namespace CSGSI_FrontEnd.HistoricalDatabaseModels
{
    public class PlayerProfile
    {
        public int round { get; set; }
        public string Name { get; set; }
        public string side { get; set; }
        public Kills kills { get; set; }
        public Engagements engagements { get; set; }
        public RadialPositioning radialPositioning { get; set; }
        public Utility utility { get; set; }
        public PlayerProfile()
        {
            Name = " ";
            side = " ";
            kills = new Kills();
            engagements = new Engagements();
            radialPositioning = new RadialPositioning();
            utility = new Utility();
        }
    }
}
