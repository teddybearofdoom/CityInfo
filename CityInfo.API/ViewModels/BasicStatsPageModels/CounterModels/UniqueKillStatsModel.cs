namespace CSGSI_FrontEnd.ViewModels.BasicStatsPageModels
{
    public class UniqueKillStatsModel
    {
        public string teamCT { get; set; }
        public string teamT { get; set; }
        public TeamUniqueKillStats unTradedOpeners { get;set;}
        public TeamUniqueKillStats tradedOpeners { get;set;}
        public TeamUniqueKillStats firstResponseKill { get;set;}    
        public TeamUniqueKillStats followUpFragsUT { get; set;}
        public TeamUniqueKillStats followUpFragsTo { get; set;}
        public TeamUniqueKillStats fourVfourEqualizer { get; set;}
        public UniqueKillStatsModel()
        {
            unTradedOpeners = new TeamUniqueKillStats();
            tradedOpeners = new TeamUniqueKillStats();
            fourVfourEqualizer = new TeamUniqueKillStats();
            followUpFragsUT = new TeamUniqueKillStats();
            firstResponseKill = new TeamUniqueKillStats();
            followUpFragsTo = new TeamUniqueKillStats();
        }
    }
}
