using CityInfo.API.Services.DatabaseServ;
using CSGO_GSI_Backend.Models.BusinessObjects.DerivBO;
using CSGSI_FrontEnd.Utility;
using CSGSI_FrontEnd.ViewModels.BasicStatsPageModels;
using CSGSI_FrontEnd.ViewModels.CounterExpansionModels;

namespace CSGSI_FrontEnd.FrontEndServices.UniqueKillServ
{
    public class FourvFourEqualizerServ
    {
        public void PopulateFourVFourServ(List<Deriv_Kill_BO> deriv_Kill_BOs, CounterExpansionModel counterExpansionModel, ServerDataBase serverDataBase)
        {
            bool equalizerFlag = false;
            if (deriv_Kill_BOs.Count >= 2)
            {
                if (deriv_Kill_BOs[0].victim_Player_Team == deriv_Kill_BOs[1].killing_Player_Team)
                {
                    equalizerFlag = true;
                    for (int killIdx = 1; killIdx < deriv_Kill_BOs.Count; killIdx++)
                    {
                        if (deriv_Kill_BOs[killIdx].victim_Player_Team == deriv_Kill_BOs[1].killing_Player_Team && Util.GetTimeDiff(deriv_Kill_BOs[1].phase, deriv_Kill_BOs[1].time, deriv_Kill_BOs[killIdx].phase, deriv_Kill_BOs[killIdx].time, deriv_Kill_BOs[1].round, serverDataBase) <= 5)
                        {
                            equalizerFlag = false;
                            foreach (var player in counterExpansionModel.teamAList)
                            {
                                if (player.name == deriv_Kill_BOs[1].victim_Player_Name)
                                {
                                    player.fourVfourEqualizerKillOpportunities.Add(deriv_Kill_BOs[1]);
                                }
                            }
                            foreach (var player in counterExpansionModel.teamBList)
                            {
                                if (player.name == deriv_Kill_BOs[1].victim_Player_Name)
                                {
                                    player.fourVfourEqualizerKillOpportunities.Add(deriv_Kill_BOs[1]);
                                }
                            }
                        }
                    }
                }
            }
            if (equalizerFlag)
            {
                foreach (var player in counterExpansionModel.teamAList)
                {
                    if (player.name == deriv_Kill_BOs[1].killing_Player_Name)
                    {
                        player.fourVfourEqualizerKills.Add(deriv_Kill_BOs[1]);
                    }
                }
                foreach (var player in counterExpansionModel.teamBList)
                {
                    if (player.name == deriv_Kill_BOs[1].killing_Player_Name)
                    {
                        player.fourVfourEqualizerKills.Add(deriv_Kill_BOs[1]);
                    }
                }
            }
        }
        public void PopulateFourVFourServ(List<Deriv_Kill_BO> deriv_Kill_BOs, TeamUniqueKillStats fourVfourEqualizer, ServerDataBase serverDataBase)
        {
            bool equalizerFlag = false;
            if (deriv_Kill_BOs.Count >= 2)
            {
                if (deriv_Kill_BOs[0].victim_Player_Team == deriv_Kill_BOs[1].killing_Player_Team)
                {
                    equalizerFlag = true;
                    for (int killIdx = 1; killIdx < deriv_Kill_BOs.Count; killIdx++)
                    {
                        if (deriv_Kill_BOs[killIdx].victim_Player_Team == deriv_Kill_BOs[1].killing_Player_Team && Util.GetTimeDiff(deriv_Kill_BOs[1].phase, deriv_Kill_BOs[1].time, deriv_Kill_BOs[killIdx].phase, deriv_Kill_BOs[killIdx].time, deriv_Kill_BOs[1].round, serverDataBase) <= 5)
                        {
                            equalizerFlag = false;
                        }
                    }
                }
            }
            if (equalizerFlag)
            {
                if (deriv_Kill_BOs[1].killing_Player_Team == "CT")
                {
                    fourVfourEqualizer.teamCTTotal++;
                }
                if (deriv_Kill_BOs[1].killing_Player_Team == "T")
                {
                    fourVfourEqualizer.TeamTTotal++;
                }

            }
        }
    }
}
