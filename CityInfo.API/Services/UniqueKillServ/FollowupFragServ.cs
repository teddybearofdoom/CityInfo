using CityInfo.API.Services.DatabaseServ;
using CSGO_GSI_Backend.Models.BusinessObjects.DerivBO;
using CSGSI_FrontEnd.Utility;
using CSGSI_FrontEnd.ViewModels.BasicStatsPageModels;
using CSGSI_FrontEnd.ViewModels.CounterExpansionModels;

namespace CSGSI_FrontEnd.FrontEndServices.UniqueKillServ
{
    public class FollowupFragServ
    {
        public void PopulateFollowUpFrag(List<Deriv_Kill_BO> deriv_Kill_BOs, TeamUniqueKillStats followUpFragsUT, TeamUniqueKillStats followUpFragsTo, CounterExpansionModel counterExpansionModel, ServerDataBase serverDataBase)
        {
            if (deriv_Kill_BOs.Count >= 2)
            {
                if (deriv_Kill_BOs[0].killing_Player_Team == deriv_Kill_BOs[1].killing_Player_Team)
                {
                    //FuF To
                    if (deriv_Kill_BOs[1].killing_Player_Team == "CT")
                    {
                        followUpFragsTo.teamCTTotal++;
                    }
                    if (deriv_Kill_BOs[1].killing_Player_Team == "T")
                    {
                        followUpFragsTo.TeamTTotal++;
                    }
                    foreach (var player in counterExpansionModel.teamAList)
                    {
                        if (player.name == deriv_Kill_BOs[1].killing_Player_Name)
                        {
                            player.followUpFragsToKills.Add(deriv_Kill_BOs[1]);
                        }
                    }
                    foreach (var player in counterExpansionModel.teamBList)
                    {
                        if (player.name == deriv_Kill_BOs[1].killing_Player_Name)
                        {
                            player.followUpFragsToKills.Add(deriv_Kill_BOs[1]);
                        }
                    }
                    //FuF UT
                    bool fufUT = true;
                    for (int killIdx = 1; killIdx < deriv_Kill_BOs.Count; killIdx++)
                    {
                        if (deriv_Kill_BOs[1].killing_Player_Team == deriv_Kill_BOs[killIdx].victim_Player_Team && Util.GetTimeDiff(deriv_Kill_BOs[1].phase, deriv_Kill_BOs[1].time, deriv_Kill_BOs[killIdx].phase, deriv_Kill_BOs[killIdx].time, deriv_Kill_BOs[1].round, serverDataBase) <= 5)
                        {
                            fufUT = false;
                        }
                    }
                    if (fufUT)
                    {
                        if (deriv_Kill_BOs[1].killing_Player_Team == "CT")
                        {
                            followUpFragsUT.teamCTTotal++;
                        }
                        if (deriv_Kill_BOs[1].killing_Player_Team == "T")
                        {
                            followUpFragsUT.TeamTTotal++;
                        }
                        foreach (var player in counterExpansionModel.teamAList)
                        {
                            if (player.name == deriv_Kill_BOs[1].killing_Player_Name)
                            {
                                player.followUpFragsUTKills.Add(deriv_Kill_BOs[1]);
                            }
                        }
                        foreach (var player in counterExpansionModel.teamBList)
                        {
                            if (player.name == deriv_Kill_BOs[1].killing_Player_Name)
                            {
                                player.followUpFragsUTKills.Add(deriv_Kill_BOs[1]);
                            }
                        }
                    }
                    else
                    {
                        foreach (var player in counterExpansionModel.teamAList)
                        {
                            if (player.name == deriv_Kill_BOs[1].victim_Player_Name)
                            {
                                player.followUpFragsUTKillOpportunities.Add(deriv_Kill_BOs[1]);
                            }
                        }
                        foreach (var player in counterExpansionModel.teamBList)
                        {
                            if (player.name == deriv_Kill_BOs[1].victim_Player_Name)
                            {
                                player.followUpFragsUTKillOpportunities.Add(deriv_Kill_BOs[1]);
                            }
                        }
                    }
                }
                else
                {
                    foreach (var player in counterExpansionModel.teamAList)
                    {
                        if (player.name == deriv_Kill_BOs[1].victim_Player_Name)
                        {
                            player.followUpFragsToKillOpportunities.Add(deriv_Kill_BOs[1]);
                        }
                    }
                    foreach (var player in counterExpansionModel.teamBList)
                    {
                        if (player.name == deriv_Kill_BOs[1].victim_Player_Name)
                        {
                            player.followUpFragsToKillOpportunities.Add(deriv_Kill_BOs[1]);
                        }
                    }
                }
            }

        }

        public void PopulateFollowUpFrag(List<Deriv_Kill_BO> deriv_Kill_BOs, TeamUniqueKillStats followUpFragsUT, TeamUniqueKillStats followUpFragsTo, ServerDataBase serverDataBase)
        {
            if (deriv_Kill_BOs.Count >= 2)
            {
                if (deriv_Kill_BOs[0].killing_Player_Team == deriv_Kill_BOs[1].killing_Player_Team)
                {
                    //FuF To
                    if (deriv_Kill_BOs[1].killing_Player_Team == "CT")
                    {
                        followUpFragsTo.teamCTTotal++;
                    }
                    if (deriv_Kill_BOs[1].killing_Player_Team == "T")
                    {
                        followUpFragsTo.TeamTTotal++;
                    }
                    //FuF UT
                    bool fufUT = true;
                    for (int killIdx = 1; killIdx < deriv_Kill_BOs.Count; killIdx++)
                    {
                        if (deriv_Kill_BOs[1].killing_Player_Team == deriv_Kill_BOs[killIdx].victim_Player_Team && Util.GetTimeDiff(deriv_Kill_BOs[1].phase, deriv_Kill_BOs[1].time, deriv_Kill_BOs[killIdx].phase, deriv_Kill_BOs[killIdx].time, deriv_Kill_BOs[1].round, serverDataBase) <= 5)
                        {
                            fufUT = false;
                        }
                    }
                    if (fufUT)
                    {
                        if (deriv_Kill_BOs[1].killing_Player_Team == "CT")
                        {
                            followUpFragsUT.teamCTTotal++;
                        }
                        if (deriv_Kill_BOs[1].killing_Player_Team == "T")
                        {
                            followUpFragsUT.TeamTTotal++;
                        }
                    }
                }
            }

        }
    }
}
