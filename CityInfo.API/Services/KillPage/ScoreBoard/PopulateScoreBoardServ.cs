
using CityInfo.API.Models.BusinessObjects.DerivBO;
using CityInfo.API.ViewModels.BasicStatsPageModels.ScoreBoardModels;

namespace CityInfo.API.Services.KillPage.ScoreBoard
{
    public class PopulateScoreBoardServ
    {
        public KillTableModel killTableModel { get; set; }
        PopulateScoreBoardParts populateScoreBoardParts { get; set; }
        public PopulateScoreBoardServ()
        {
            killTableModel = new KillTableModel();
            populateScoreBoardParts = new PopulateScoreBoardParts();
        }
        public void PopulateScoreBoard(List<Deriv_PlayerTeam_BO> deriv_PlayerTeam_BOs)
        {
            //Iterating through the List deriv player team BO of each round
            //i iterator represents round count
            for (int i = 0; i < deriv_PlayerTeam_BOs.Count; i++)
            {
                if (i == 0)
                {
                    IntializeScoreBoard(deriv_PlayerTeam_BOs[i]);
                    PopulateScoreBoard(deriv_PlayerTeam_BOs[i]);


                }
                else
                {
                    PopulateScoreBoard(deriv_PlayerTeam_BOs[i], deriv_PlayerTeam_BOs[i - 1]);
                }
            }
            PopulatePlayersADR(deriv_PlayerTeam_BOs.Count);
        }
        public void PopulateScoreBoard(Deriv_PlayerTeam_BO deriv_PlayerTeam_BO)
        {
            populateScoreBoardParts.SetScoreBoard(killTableModel, deriv_PlayerTeam_BO);
        }
        public void IntializeScoreBoard(Deriv_PlayerTeam_BO deriv_PlayerTeam_BO)
        {
            foreach (var player in deriv_PlayerTeam_BO.CTplayers)
            {
                PlayerStats playerStats = new PlayerStats();
                playerStats.name = player.Name;
                killTableModel.team_CT.Add(playerStats);
            }
            foreach (var player in deriv_PlayerTeam_BO.Tplayers)
            {
                PlayerStats playerStats = new PlayerStats();
                playerStats.name = player.Name;
                killTableModel.team_T.Add(playerStats);
            }
        }
        public void IntializeScoreBoard(Deriv_PlayerTeam_BO deriv_PlayerTeam_BO, KillTableModel killTableModel)
        {
            foreach (var player in deriv_PlayerTeam_BO.CTplayers)
            {
                PlayerStats playerStats = new PlayerStats();
                playerStats.name = player.Name;
                killTableModel.team_CT.Add(playerStats);
            }
            foreach (var player in deriv_PlayerTeam_BO.Tplayers)
            {
                PlayerStats playerStats = new PlayerStats();
                playerStats.name = player.Name;
                killTableModel.team_T.Add(playerStats);
            }
        }
        public void PopulatePlayersADR(int totalRoundCount)
        {
            foreach (var playerstats in killTableModel.team_CT)
            {
                playerstats.adr = playerstats.adr / totalRoundCount;
            }
            foreach (var playerstats in killTableModel.team_T)
            {
                playerstats.adr = playerstats.adr / totalRoundCount;
            }
        }

        public void PopulateScoreBoard(Deriv_PlayerTeam_BO deriv_PlayerTeam_BO, Deriv_PlayerTeam_BO previousRoundderiv_PlayerTeam_BO)
        {
            populateScoreBoardParts.SetScoreBoard(killTableModel, deriv_PlayerTeam_BO, previousRoundderiv_PlayerTeam_BO);
        }
    }
}
