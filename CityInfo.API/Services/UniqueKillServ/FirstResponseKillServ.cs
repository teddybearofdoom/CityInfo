using CSGO_GSI_Backend.Models.BusinessObjects.DerivBO;
using CSGSI_FrontEnd.ViewModels.BasicStatsPageModels;
using CSGSI_FrontEnd.ViewModels.CounterExpansionModels;

namespace CityInfo.API.Services.UniqueKillServ
{
    public class FirstResponseKillServ
    {
        public void PopulateFirstResponseKillServ(List<Deriv_Kill_BO> deriv_Kill_BOs, TeamUniqueKillStats firstResponseKill)
        {
            if (deriv_Kill_BOs.Count >= 2)
            {
                if (deriv_Kill_BOs[1].killing_Player_Team == deriv_Kill_BOs[0].victim_Player_Team)
                {
                    if (deriv_Kill_BOs[1].killing_Player_Team == "CT")
                    {
                        firstResponseKill.teamCTTotal++;
                    }
                    if (deriv_Kill_BOs[1].killing_Player_Team == "T")
                    {
                        firstResponseKill.TeamTTotal++;
                    }
                }
            }
        }
        public void PopulateFirstResponseKillServ(List<Deriv_Kill_BO> deriv_Kill_BOs, CounterExpansionModel counterExpansionModel)
        {
            if (deriv_Kill_BOs.Count >= 2)
            {
                if (deriv_Kill_BOs[1].killing_Player_Team == deriv_Kill_BOs[0].victim_Player_Team)
                {
                    foreach (var player in counterExpansionModel.teamAList)
                    {
                        if (player.name == deriv_Kill_BOs[1].killing_Player_Name)
                        {
                            player.firstResponseKills.Add(deriv_Kill_BOs[1]);
                        }
                    }
                    foreach (var player in counterExpansionModel.teamBList)
                    {
                        if (player.name == deriv_Kill_BOs[1].killing_Player_Name)
                        {
                            player.firstResponseKills.Add(deriv_Kill_BOs[1]);
                        }
                    }
                }
                else if (deriv_Kill_BOs[1].killing_Player_Team == deriv_Kill_BOs[0].killing_Player_Team)
                {
                    foreach (var player in counterExpansionModel.teamAList)
                    {
                        if (player.name == deriv_Kill_BOs[1].victim_Player_Name)
                        {
                            player.firstResponseKillOpportunities.Add(deriv_Kill_BOs[1]);
                        }
                    }
                    foreach (var player in counterExpansionModel.teamBList)
                    {
                        if (player.name == deriv_Kill_BOs[1].victim_Player_Name)
                        {
                            player.firstResponseKillOpportunities.Add(deriv_Kill_BOs[1]);
                        }
                    }
                }
            }
        }
    }
}
