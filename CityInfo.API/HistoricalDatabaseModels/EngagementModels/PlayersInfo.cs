using CSGO_GSI_Backend.Models.BusinessObjects.DerivBO;

namespace CSGSI_FrontEnd.HistoricalDatabaseModels.EngagementModels
{
    public class PlayersInfo
    {
        public string name { get; set; }
        public List<Deriv_Kill_BO> Kills { get; set; }
        public List<string> utility { get; set; }
        public float Zone { get; set; }
        public PlayersInfo()
        {
            Kills = new List<Deriv_Kill_BO>();
            utility = new List<string>();
        }
    }
}
