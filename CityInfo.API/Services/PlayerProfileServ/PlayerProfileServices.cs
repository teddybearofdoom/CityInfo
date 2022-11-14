using CityInfo.API.Filters;
using CityInfo.API.Services.DatabaseServ;
using CSGSI_FrontEnd.FrontEndServices.KillPageServ.ScoreBoard.MatchSegmentFilters_ScoreBoard;
using CSGSI_FrontEnd.ViewModels.PlayerProfile;

namespace CSGSI_FrontEnd.FrontEndServices.PlayerProfileServ
{
    public class PlayerProfileServices
    {
        LiveTeamProfile teamProfiles { get; set; }
        public PlayerProfileServices()
        {
            teamProfiles = new LiveTeamProfile();
        }
        public LiveTeamProfile PopulateTeamProfiles(ServerDataBase serverDataBase)
        {
            IntializePlayerProfiles(serverDataBase);
            IntializePlayerCounters();
            PopulatePlayerScoreBoard(serverDataBase);
            PopulatePlayerCounters(serverDataBase);
            return teamProfiles;
        }
        void IntializePlayerProfiles(ServerDataBase serverDataBase)
        {
            var deriv_PlayerTeam_BO = serverDataBase.GetPlayerTeamDerivObj(serverDataBase.GetTotalRoundCount());
            foreach (var player in deriv_PlayerTeam_BO.CTplayers)
            {
                LivePlayerProfile livePlayerProfile = new LivePlayerProfile();
                livePlayerProfile.Name = player.Name;
                livePlayerProfile.team = player.Clan;
                teamProfiles.CTplayers.Add(livePlayerProfile);
            }
            foreach (var player in deriv_PlayerTeam_BO.Tplayers)
            {
                LivePlayerProfile livePlayerProfile = new LivePlayerProfile();
                livePlayerProfile.Name = player.Name;
                livePlayerProfile.team = player.Clan;
                teamProfiles.Tplayers.Add(livePlayerProfile);
            }
        }
        void IntializePlayerCounters()
        {

            foreach (var player in teamProfiles.CTplayers)
            {
                PlayerCounters playerCounters = new PlayerCounters();
                playerCounters.type = "Untraded Openers";

                PlayerCounters playerCounters1 = new PlayerCounters();
                playerCounters1.type = "Traded Openers";

                PlayerCounters playerCounters2 = new PlayerCounters();
                playerCounters2.type = "FRK";

                PlayerCounters playerCounters3 = new PlayerCounters();
                playerCounters3.type = "4v4Eq";

                PlayerCounters playerCounters4 = new PlayerCounters();
                playerCounters4.type = "FUFTradeoffs";

                PlayerCounters playerCounters5 = new PlayerCounters();
                playerCounters5.type = "FUFUnTraded";

                PlayerCounters playerCounters6 = new PlayerCounters();
                playerCounters6.type = "PistolRounds";

                PlayerCounters playerCounters7 = new PlayerCounters();
                playerCounters7.type = "Traded";

                PlayerCounters playerCounters8 = new PlayerCounters();
                playerCounters8.type = "DryDeaths";

                PlayerCounters playerCounters9 = new PlayerCounters();
                playerCounters9.type = "EngagementsIntializationKill";

                PlayerCounters playerCounters10 = new PlayerCounters();
                playerCounters10.type = "Equalizers";

                player.playerCounters.Add(playerCounters);
                player.playerCounters.Add(playerCounters1);
                player.playerCounters.Add(playerCounters2);
                player.playerCounters.Add(playerCounters3);
                player.playerCounters.Add(playerCounters4);
                player.playerCounters.Add(playerCounters5);
                player.playerCounters.Add(playerCounters6);
                player.playerCounters.Add(playerCounters7);
                player.playerCounters.Add(playerCounters8);
                player.playerCounters.Add(playerCounters9);
                player.playerCounters.Add(playerCounters10);
            }
            foreach (var player in teamProfiles.Tplayers)
            {
                PlayerCounters playerCounters = new PlayerCounters();
                playerCounters.type = "Untraded Openers";

                PlayerCounters playerCounters1 = new PlayerCounters();
                playerCounters1.type = "Traded Openers";

                PlayerCounters playerCounters2 = new PlayerCounters();
                playerCounters2.type = "FRK";

                PlayerCounters playerCounters3 = new PlayerCounters();
                playerCounters3.type = "4v4Eq";

                PlayerCounters playerCounters4 = new PlayerCounters();
                playerCounters4.type = "FUFTradeoffs";

                PlayerCounters playerCounters5 = new PlayerCounters();
                playerCounters5.type = "FUFUnTraded";

                PlayerCounters playerCounters6 = new PlayerCounters();
                playerCounters6.type = "PistolRounds";

                PlayerCounters playerCounters7 = new PlayerCounters();
                playerCounters7.type = "Traded";

                PlayerCounters playerCounters8 = new PlayerCounters();
                playerCounters8.type = "DryDeaths";

                PlayerCounters playerCounters9 = new PlayerCounters();
                playerCounters9.type = "EngagementsIntializationKill";

                PlayerCounters playerCounters10 = new PlayerCounters();
                playerCounters10.type = "Equalizers";

                player.playerCounters.Add(playerCounters);
                player.playerCounters.Add(playerCounters1);
                player.playerCounters.Add(playerCounters2);
                player.playerCounters.Add(playerCounters3);
                player.playerCounters.Add(playerCounters4);
                player.playerCounters.Add(playerCounters5);
                player.playerCounters.Add(playerCounters6);
                player.playerCounters.Add(playerCounters7);
                player.playerCounters.Add(playerCounters8);
                player.playerCounters.Add(playerCounters9);
                player.playerCounters.Add(playerCounters10);
            }
        }
        void PopulatePlayerScoreBoard(ServerDataBase serverDataBase)
        {
            var killTableModel = new FullTimeScoreBoardServ(serverDataBase.GetTotalRoundCount()).SetFullTimeScoreBoard(serverDataBase);
            foreach (var player in killTableModel.team_CT)
            {
                foreach (var playerprofile in teamProfiles.CTplayers)
                {
                    if (player.name == playerprofile.Name)
                    {
                        playerprofile.kills = player.kills;
                        playerprofile.assists = player.assist;
                        playerprofile.deaths = player.deaths;
                        playerprofile.ADR = player.adr;
                    }
                }
                foreach (var playerprofile in teamProfiles.Tplayers)
                {
                    if (player.name == playerprofile.Name)
                    {
                        playerprofile.kills = player.kills;
                        playerprofile.assists = player.assist;
                        playerprofile.deaths = player.deaths;
                        playerprofile.ADR = player.adr;
                    }
                }
            }
            foreach (var player in killTableModel.team_T)
            {
                foreach (var playerprofile in teamProfiles.CTplayers)
                {
                    if (player.name == playerprofile.Name)
                    {
                        playerprofile.kills = player.kills;
                        playerprofile.assists = player.assist;
                        playerprofile.deaths = player.deaths;
                        playerprofile.ADR = player.adr;
                    }
                }
                foreach (var playerprofile in teamProfiles.Tplayers)
                {
                    if (player.name == playerprofile.Name)
                    {
                        playerprofile.kills = player.kills;
                        playerprofile.assists = player.assist;
                        playerprofile.deaths = player.deaths;
                        playerprofile.ADR = player.adr;
                    }
                }
            }
        }
        void PopulatePlayerCounters(ServerDataBase serverDataBase)
        {
            for (int i = 0; i < serverDataBase.GetTotalRoundCount(); i++)
            {
                var killList = serverDataBase.GetDeriv_Kill_BO(new IndexFilters().GetKillBOFilter(i));
                if (i == 0 && i == 15)
                {
                    //pistol roundStats
                    foreach (var kill in killList)
                    {
                        foreach (var player in teamProfiles.CTplayers)
                        {
                            if (player.Name == kill.killing_Player_Name)
                            {
                                player.playerCounters[6].Total++;
                                player.playerCounters[6].Live++;
                            }
                        }
                        foreach (var player in teamProfiles.Tplayers)
                        {
                            if (player.Name == kill.killing_Player_Name)
                            {
                                player.playerCounters[6].Total++;
                                player.playerCounters[6].Live++;
                            }
                        }
                    }
                }
                else
                {
                    string equalizer4v4player = " ";
                    string killTradedPlayer = " ";
                    string EqualizerKillPlayer = " ";
                    string firstResponsekillPlayerName = " ";
                    string followupFragTradedPlayerName = " ";
                    string followUpFragUntradedPlayerName = " ";

                    if (KillUtilities.GetFirstResponseKill(killList) != null)
                    {
                        firstResponsekillPlayerName = KillUtilities.GetFirstResponseKill(killList).killing_Player_Name;
                    }
                    if (KillUtilities.GetFollowUpFragTraded(killList, serverDataBase) != null)
                    {
                        followupFragTradedPlayerName = KillUtilities.GetFollowUpFragTraded(killList, serverDataBase).killing_Player_Name;
                    }
                    if (KillUtilities.GetFollowUpFragUntraded(killList, serverDataBase) != null)
                    {
                        followUpFragUntradedPlayerName = KillUtilities.GetFollowUpFragUntraded(killList, serverDataBase).killing_Player_Name;
                    }
                    var openingkillPlayerName = KillUtilities.GetOpeningKill(killList).killing_Player_Name;
                    var tradedOpeners = KillUtilities.GetIsTraded(0, killList, serverDataBase);

                    if (KillUtilities.GetIs4v4Equalizer(1, killList, serverDataBase))
                    {
                        equalizer4v4player = killList[1].killing_Player_Name;
                    }
                    for (int j = 0; j < killList.Count; j++)
                    {
                        if (KillUtilities.GetIsTraded(j, killList, serverDataBase))
                        {
                            killTradedPlayer = killList[j].killing_Player_Name;
                            foreach (var player in teamProfiles.CTplayers)
                            {
                                if (player.Name == killTradedPlayer)
                                {
                                    player.playerCounters[7].Total++;
                                    player.playerCounters[7].Live++;
                                }
                            }
                            foreach (var player in teamProfiles.Tplayers)
                            {
                                if (player.Name == killTradedPlayer)
                                {
                                    player.playerCounters[7].Total++;
                                    player.playerCounters[7].Live++;
                                }
                            }
                        }
                    }
                    for (int j = 0; j < killList.Count; j++)
                    {
                        if (KillUtilities.GetIsEqualizer(j, killList, serverDataBase))
                        {
                            EqualizerKillPlayer = killList[j].killing_Player_Name;
                            foreach (var player in teamProfiles.CTplayers)
                            {
                                if (player.Name == EqualizerKillPlayer)
                                {
                                    player.playerCounters[10].Total++;
                                    player.playerCounters[10].Live++;
                                }
                            }
                            foreach (var player in teamProfiles.Tplayers)
                            {
                                if (player.Name == EqualizerKillPlayer)
                                {
                                    player.playerCounters[10].Total++;
                                    player.playerCounters[10].Live++;
                                }
                            }
                        }
                    }
                    Console.WriteLine("ez");
                    foreach (var player in teamProfiles.CTplayers)
                    {
                        if (player.Name == openingkillPlayerName && tradedOpeners == false)
                        {
                            player.playerCounters[0].Total++;
                            player.playerCounters[0].Live++;
                        }
                        else if (player.Name == openingkillPlayerName && tradedOpeners == true)
                        {
                            player.playerCounters[1].Total++;
                            player.playerCounters[1].Live++;
                        }
                        if (player.Name == firstResponsekillPlayerName)
                        {
                            player.playerCounters[2].Total++;
                            player.playerCounters[2].Live++;
                        }
                        if (player.Name == followupFragTradedPlayerName)
                        {
                            player.playerCounters[3].Total++;
                            player.playerCounters[3].Live++;
                        }
                        if (player.Name == followUpFragUntradedPlayerName)
                        {
                            player.playerCounters[4].Total++;
                            player.playerCounters[4].Live++;
                        }
                        if (player.Name == equalizer4v4player)
                        {
                            player.playerCounters[5].Total++;
                            player.playerCounters[5].Live++;
                        }
                    }
                    foreach (var player in teamProfiles.Tplayers)
                    {
                        if (player.Name == openingkillPlayerName && tradedOpeners == false)
                        {
                            player.playerCounters[0].Total++;
                            player.playerCounters[0].Live++;
                        }
                        else if (player.Name == openingkillPlayerName && tradedOpeners == true)
                        {
                            player.playerCounters[1].Total++;
                            player.playerCounters[1].Live++;
                        }
                        if (player.Name == firstResponsekillPlayerName)
                        {
                            player.playerCounters[2].Total++;
                            player.playerCounters[2].Live++;
                        }
                        if (player.Name == followupFragTradedPlayerName)
                        {
                            player.playerCounters[3].Total++;
                            player.playerCounters[3].Live++;
                        }
                        if (player.Name == followUpFragUntradedPlayerName)
                        {
                            player.playerCounters[4].Total++;
                            player.playerCounters[4].Live++;
                        }
                        if (player.Name == equalizer4v4player)
                        {
                            player.playerCounters[5].Total++;
                            player.playerCounters[5].Live++;
                        }
                    }
                    foreach (var player in teamProfiles.CTplayers)
                    {
                        foreach (var counters in player.playerCounters)
                        {
                            counters.PerRound = counters.Live / serverDataBase.GetTotalRoundCount();
                        }
                    }
                    foreach (var player in teamProfiles.CTplayers)
                    {
                        foreach (var counters in player.playerCounters)
                        {
                            counters.PerRound = counters.Live / serverDataBase.GetTotalRoundCount();
                        }
                    }
                }
            }
        }
        void PopulatePlayerRankings()
        {
            teamProfiles.CTplayers[0].playerCounters[0].Rank = 0;
            teamProfiles.CTplayers[1].playerCounters[0].Rank = 0;
            teamProfiles.CTplayers[2].playerCounters[0].Rank = 0;
            teamProfiles.CTplayers[3].playerCounters[0].Rank = 0;
            teamProfiles.CTplayers[4].playerCounters[0].Rank = 0;

            teamProfiles.Tplayers[0].playerCounters[0].Rank = 0;
            teamProfiles.Tplayers[1].playerCounters[0].Rank = 0;
            teamProfiles.Tplayers[2].playerCounters[0].Rank = 0;
            teamProfiles.Tplayers[3].playerCounters[0].Rank = 0;
            teamProfiles.Tplayers[4].playerCounters[0].Rank = 0;

            teamProfiles.CTplayers[0].playerCounters[1].Rank = 0;
            teamProfiles.CTplayers[1].playerCounters[1].Rank = 0;
            teamProfiles.CTplayers[2].playerCounters[1].Rank = 0;
            teamProfiles.CTplayers[3].playerCounters[1].Rank = 0;
            teamProfiles.CTplayers[4].playerCounters[1].Rank = 0;

            teamProfiles.Tplayers[0].playerCounters[1].Rank = 0;
            teamProfiles.Tplayers[1].playerCounters[1].Rank = 0;
            teamProfiles.Tplayers[2].playerCounters[1].Rank = 0;
            teamProfiles.Tplayers[3].playerCounters[1].Rank = 0;
            teamProfiles.Tplayers[4].playerCounters[1].Rank = 0;

            teamProfiles.CTplayers[0].playerCounters[2].Rank = 0;
            teamProfiles.CTplayers[1].playerCounters[2].Rank = 0;
            teamProfiles.CTplayers[2].playerCounters[2].Rank = 0;
            teamProfiles.CTplayers[3].playerCounters[2].Rank = 0;
            teamProfiles.CTplayers[4].playerCounters[2].Rank = 0;

            teamProfiles.Tplayers[0].playerCounters[2].Rank = 0;
            teamProfiles.Tplayers[1].playerCounters[2].Rank = 0;
            teamProfiles.Tplayers[2].playerCounters[2].Rank = 0;
            teamProfiles.Tplayers[3].playerCounters[2].Rank = 0;
            teamProfiles.Tplayers[4].playerCounters[2].Rank = 0;



        }
    }
}
