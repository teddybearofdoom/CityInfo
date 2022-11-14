using CityInfo.API.Filters;
using CityInfo.API.Services.DatabaseServ;
using CSGSI_FrontEnd.FrontEndServices.EngagmentServ;
using CSGSI_FrontEnd.ViewModels.PlayerProfile;

namespace CityInfo.API.Services.Engagement
{
    public class CalcEngagementForLivePlayerProfile
    {
        public void CumulativeStatistics(LiveTeamProfile liveTeamProfile, ServerDataBase dataBase, int round)
        {
            CalcEngagmentServ calcEngagmentServ = new CalcEngagmentServ();
            CheckEngagementWinnerServ checkEngagementWinnerServ = new CheckEngagementWinnerServ();
            IndexFilters indexFilters = new IndexFilters();

            var currentRoundDerivObj = dataBase.GetPlayerTeamDerivObj(round + 1);

            var CTteamName = currentRoundDerivObj.CTplayers[0].Clan;
            var TteamName = currentRoundDerivObj.Tplayers[0].Clan;

            var currentRoundEngagementList = calcEngagmentServ.CalcEngagement(dataBase, round);

            var roundCondFilter = indexFilters.GetRoundCondFilter(round);
            var firstdocument = dataBase.GetRoundCondDerivObj(roundCondFilter);

            int index = 0;
            foreach (var engagement in currentRoundEngagementList)
            {
                int startCTPlayers = 0;
                int startTPlayers = 0;
                if (BreakEngagmentServ.returnCTPlayers(currentRoundEngagementList[index]) != null && BreakEngagmentServ.returnTPlayers(currentRoundEngagementList[index]) != null)
                {
                    startCTPlayers = Int32.Parse(BreakEngagmentServ.returnCTPlayers(currentRoundEngagementList[index]));
                    startTPlayers = Int32.Parse(BreakEngagmentServ.returnTPlayers(currentRoundEngagementList[index]));
                }

                if (currentRoundEngagementList.ElementAtOrDefault(index + 1) != null && currentRoundEngagementList[index + 1].timerElapsed == true)
                {
                    int endCTPlayers = 0;
                    int endTPlayers = 0;
                    if (BreakEngagmentServ.returnCTPlayers(currentRoundEngagementList[index + 1]) != null && BreakEngagmentServ.returnTPlayers(currentRoundEngagementList[index + 1]) != null)
                    {
                        endCTPlayers = Int32.Parse(BreakEngagmentServ.returnCTPlayers(currentRoundEngagementList[index + 1]));
                        endTPlayers = Int32.Parse(BreakEngagmentServ.returnTPlayers(currentRoundEngagementList[index + 1]));

                    }

                    foreach (var player in liveTeamProfile.CTplayers)
                    {
                        foreach (var playerEngagementStats in player.engagementStatistics)
                        {

                            if (Int32.Parse(playerEngagementStats.engagementStatus[0].ToString()) == startCTPlayers && Int32.Parse(playerEngagementStats.engagementStatus[2].ToString()) == startTPlayers)
                            {
                                if (firstdocument.win_team == "CT")
                                {
                                    if (player.team == CTteamName)
                                    {
                                        playerEngagementStats.won++;
                                    }
                                    else
                                    {
                                        playerEngagementStats.lost++;
                                    }
                                }
                                foreach (var kill in engagement.KillsInEngagements)
                                {
                                    if (player.Name == kill.victim_Player_Name || player.Name == kill.killing_Player_Name)
                                    {
                                        playerEngagementStats.participated++;
                                        break;
                                    }
                                }
                                if (checkEngagementWinnerServ.Winner(startCTPlayers, startTPlayers, endCTPlayers, endTPlayers) == "T")
                                {

                                    if (player.team == TteamName)
                                    {
                                         playerEngagementStats.success++;
                                    }   
                                    else
                                    {
                                        playerEngagementStats.failure++;
                                    }
                                    foreach (var kill in engagement.KillsInEngagements)
                                    {
                                        if (player.Name == kill.killing_Player_Name)
                                        {
                                            if (player.team == TteamName)
                                            {
                                                playerEngagementStats.killedAndSuccess++;
                                            }
                                            else
                                            {
                                                playerEngagementStats.killedAndFailure++;
                                            }                                           
                                        }
                                        if (player.Name == kill.victim_Player_Name)
                                        {
                                            if (player.team == TteamName)
                                            {
                                                playerEngagementStats.diedAndSuccess++;
                                            }
                                            else
                                            {
                                                playerEngagementStats.diedAndFailure++;
                                            }
                                        }
                                    }
                                }
                                else if (checkEngagementWinnerServ.Winner(startCTPlayers, startTPlayers, endCTPlayers, endTPlayers) == "CT")
                                {
                                    if (player.team == CTteamName)
                                    {
                                        playerEngagementStats.success++;
                                    }
                                    else
                                    {
                                        playerEngagementStats.failure++;
                                    }
                                    foreach (var kill in engagement.KillsInEngagements)
                                    {
                                        if (player.Name == kill.killing_Player_Name)
                                        {
                                            if (player.team == CTteamName)
                                            {
                                                playerEngagementStats.killedAndSuccess++;
                                            }
                                            else
                                            {
                                                playerEngagementStats.killedAndFailure++;
                                            }
                                        }
                                        if (player.Name == kill.victim_Player_Name)
                                        {
                                            if (player.team == CTteamName)
                                            {
                                                playerEngagementStats.diedAndSuccess++;
                                            }
                                            else
                                            {
                                                playerEngagementStats.diedAndFailure++;
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                    foreach (var player in liveTeamProfile.Tplayers)
                    {
                        foreach (var playerEngagementStats in player.engagementStatistics)
                        {

                            if (Int32.Parse(playerEngagementStats.engagementStatus[0].ToString()) == startCTPlayers && Int32.Parse(playerEngagementStats.engagementStatus[2].ToString()) == startTPlayers)
                            {
                                if (firstdocument.win_team == "T")
                                {
                                    if (player.team == TteamName)
                                    {
                                        playerEngagementStats.won++;
                                    }
                                    else
                                    {
                                        playerEngagementStats.lost++;
                                    }
                                }
                                foreach (var kill in engagement.KillsInEngagements)
                                {
                                    if (player.Name == kill.victim_Player_Name || player.Name == kill.killing_Player_Name)
                                    {
                                        playerEngagementStats.participated++;
                                        break;
                                    }
                                }
                                if (checkEngagementWinnerServ.Winner(startCTPlayers, startTPlayers, endCTPlayers, endTPlayers) == "T")
                                {

                                    if (player.team == TteamName)
                                    {
                                        playerEngagementStats.success++;
                                    }
                                    else
                                    {
                                        playerEngagementStats.failure++;
                                    }
                                    foreach (var kill in engagement.KillsInEngagements)
                                    {
                                        if (player.Name == kill.killing_Player_Name)
                                        {
                                            if (player.team == TteamName)
                                            {
                                                playerEngagementStats.killedAndSuccess++;
                                            }
                                            else
                                            {
                                                playerEngagementStats.killedAndFailure++;
                                            }
                                        }
                                        if (player.Name == kill.victim_Player_Name)
                                        {
                                            if (player.team == TteamName)
                                            {
                                                playerEngagementStats.diedAndSuccess++;
                                            }
                                            else
                                            {
                                                playerEngagementStats.diedAndFailure++;
                                            }
                                        }
                                    }
                                }
                                else if (checkEngagementWinnerServ.Winner(startCTPlayers, startTPlayers, endCTPlayers, endTPlayers) == "CT")
                                {
                                    if (player.team == CTteamName)
                                    {
                                        playerEngagementStats.success++;
                                    }
                                    else
                                    {
                                        playerEngagementStats.failure++;
                                    }
                                    foreach (var kill in engagement.KillsInEngagements)
                                    {
                                        if (player.Name == kill.killing_Player_Name)
                                        {
                                            if (player.team == CTteamName)
                                            {
                                                playerEngagementStats.killedAndSuccess++;
                                            }
                                            else
                                            {
                                                playerEngagementStats.killedAndFailure++;
                                            }
                                        }
                                        if (player.Name == kill.victim_Player_Name)
                                        {
                                            if (player.team == CTteamName)
                                            {
                                                playerEngagementStats.diedAndSuccess++;
                                            }
                                            else
                                            {
                                                playerEngagementStats.diedAndFailure++;
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }

                }
                index++;
            }
        
        }
    }
}
