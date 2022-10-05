using CityInfo.API.Services.DatabaseServ;
using CSGO_GSI_Backend.Models.BusinessObjects.DerivBO;
using CSGSI_FrontEnd.Utility;
using CSGSI_FrontEnd.ViewModels.BasicStatsPageModels;
using CSGSI_FrontEnd.ViewModels.CounterExpansionModels;

namespace CSGSI_FrontEnd.FrontEndServices.UniqueKillServ
{
    public class OpenerKillServ
    {
        public void populateOpenerKillServ(List<Deriv_Kill_BO> deriv_Kill_BOs, TeamUniqueKillStats tradedOpeners, TeamUniqueKillStats untradedOpeners, CounterExpansionModel counterExpansionModel,ServerDataBase serverDataBase)
        {
            if (deriv_Kill_BOs.Count >= 1)
            {
                bool tradedFlag = false;
                for (int killIdx = 0; killIdx < deriv_Kill_BOs.Count; killIdx++)
                {
                    if (deriv_Kill_BOs[killIdx].victim_Player_Team == deriv_Kill_BOs[0].killing_Player_Team && Util.GetTimeDiff(deriv_Kill_BOs[0].phase, deriv_Kill_BOs[0].time, deriv_Kill_BOs[killIdx].phase, deriv_Kill_BOs[killIdx].time, deriv_Kill_BOs[0].round, serverDataBase) <= 5)
                    {
                        tradedFlag = true;

                    }
                }
                if (tradedFlag)
                {
                    if (deriv_Kill_BOs[0].killing_Player_Team == "CT")
                    {
                        tradedOpeners.teamCTTotal++;
                    }
                    if (deriv_Kill_BOs[0].killing_Player_Team == "T")
                    {
                        tradedOpeners.TeamTTotal++;
                    }
                    foreach (var player in counterExpansionModel.teamAList)
                    {
                        if (player.name == deriv_Kill_BOs[0].killing_Player_Name)
                        {
                            player.tradedOpenersKills.Add(deriv_Kill_BOs[0]);
                        }
                    }
                    foreach (var player in counterExpansionModel.teamBList)
                    {
                        if (player.name == deriv_Kill_BOs[0].killing_Player_Name)
                        {
                            player.tradedOpenersKills.Add(deriv_Kill_BOs[0]);
                        }
                    }
                }
                else
                {
                    if (deriv_Kill_BOs[0].killing_Player_Team == "CT")
                    {
                        untradedOpeners.teamCTTotal++;
                    }
                    if (deriv_Kill_BOs[0].killing_Player_Team == "T")
                    {
                        untradedOpeners.TeamTTotal++;
                    }
                    foreach (var player in counterExpansionModel.teamAList)
                    {
                        if (player.name == deriv_Kill_BOs[0].killing_Player_Name)
                        {
                            player.untradedOpenersKills.Add(deriv_Kill_BOs[0]);
                        }
                    }
                    foreach (var player in counterExpansionModel.teamBList)
                    {
                        if (player.name == deriv_Kill_BOs[0].killing_Player_Name)
                        {
                            player.untradedOpenersKills.Add(deriv_Kill_BOs[0]);
                        }
                    }
                }
            }
        }
        public void populateOpenerKillServ(List<Deriv_Kill_BO> deriv_Kill_BOs, TeamUniqueKillStats tradedOpeners, TeamUniqueKillStats untradedOpeners, ServerDataBase serverDataBase)
        {
            if (deriv_Kill_BOs.Count >= 1)
            {
                bool tradedFlag = false;
                for (int killIdx = 0; killIdx < deriv_Kill_BOs.Count; killIdx++)
                {
                    if (deriv_Kill_BOs[killIdx].victim_Player_Team == deriv_Kill_BOs[0].killing_Player_Team && Util.GetTimeDiff(deriv_Kill_BOs[0].phase, deriv_Kill_BOs[0].time, deriv_Kill_BOs[killIdx].phase, deriv_Kill_BOs[killIdx].time, deriv_Kill_BOs[0].round, serverDataBase) <= 5)
                    {
                        tradedFlag = true;

                    }
                }
                if (tradedFlag)
                {
                    if (deriv_Kill_BOs[0].killing_Player_Team == "CT")
                    {
                        tradedOpeners.teamCTTotal++;
                    }
                    if (deriv_Kill_BOs[0].killing_Player_Team == "T")
                    {
                        tradedOpeners.TeamTTotal++;
                    }
                }
                else
                {
                    if (deriv_Kill_BOs[0].killing_Player_Team == "CT")
                    {
                        untradedOpeners.teamCTTotal++;
                    }
                    if (deriv_Kill_BOs[0].killing_Player_Team == "T")
                    {
                        untradedOpeners.TeamTTotal++;
                    }
                }
            }
        }
    }
}
