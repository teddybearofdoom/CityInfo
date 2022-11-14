using CSGO_GSI_Backend.Models.BusinessObjects.DerivBO;
using CSGSI_FrontEnd.HistoricalDatabaseModels.EngagementModels;

namespace CSGSI_FrontEnd.HistoricalDatabaseModels
{
    public class HistoricalDetailedEngagement
    {
        public int teamplayers { get; set; }
        public int enemyPlayers { get; set; }
        public string successTeam { get; set; }
        public bool EngagementEqualizer { get; set; }
        public List<PlayersInfo> playersAlive { get; set; }
        public List<PlayersInfo> playersDead { get; set; }
        public Deriv_Kill_BO intiationKill { get; set; }
        public HistoricalDetailedEngagement()
        {
            successTeam = " ";
            playersAlive = new List<PlayersInfo>();
            playersDead = new List<PlayersInfo>();
            intiationKill = new Deriv_Kill_BO();
        }

    }
}
