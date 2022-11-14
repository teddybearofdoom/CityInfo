using CityInfo.API.Filters;
using CityInfo.API.Services.DatabaseServ;
using CityInfo.API.ViewModels.BasicStatsPageModels.CounterModels;
using CSGSI_FrontEnd.FrontEndServices.PlayerProfileServ;
using CSGSI_FrontEnd.FrontEndServices.UniqueKillServ;
using CSGSI_FrontEnd.ViewModels.BasicStatsPageModels;
using CSGSI_FrontEnd.ViewModels.CounterExpansionModels;

namespace CityInfo.API.Services.UniqueKillServ
{
    public class PopulateLT3KillCounterModel
    {
        LT3KillCounters lT3KillCounters = new LT3KillCounters();
        FirstResponseKillServ firstResponseKill = new FirstResponseKillServ();
        FollowupFragServ followupFrag = new FollowupFragServ();
        FourvFourEqualizerServ FourvFourEqualizer = new FourvFourEqualizerServ();
        OpenerKillServ openerKill = new OpenerKillServ();
        IndexFilters indexFilters = new IndexFilters();


        public void IntializeLT3KillCounterModel(ServerDataBase serverDataBase)
        {
            lT3KillCounters.teamCT = (serverDataBase.GetPlayerTeamDerivObj(serverDataBase.GetTotalRoundCount())).CTplayers[0].Clan;
            lT3KillCounters.teamT = (serverDataBase.GetPlayerTeamDerivObj(serverDataBase.GetTotalRoundCount())).Tplayers[0].Clan;

            LT3KillCounterChildModel lT3KillCounterChildModel = new LT3KillCounterChildModel();
            lT3KillCounterChildModel.type = "unTradedOpeners";

            LT3KillCounterChildModel lT3KillCounterChildModel1 = new LT3KillCounterChildModel();
            lT3KillCounterChildModel1.type = "tradedOpeners";

            LT3KillCounterChildModel lT3KillCounterChildModel2 = new LT3KillCounterChildModel();
            lT3KillCounterChildModel2.type = "firstResponseKill";

            LT3KillCounterChildModel lT3KillCounterChildModel3 = new LT3KillCounterChildModel();
            lT3KillCounterChildModel3.type = "followUpFragsUT";

            LT3KillCounterChildModel lT3KillCounterChildModel4 = new LT3KillCounterChildModel();
            lT3KillCounterChildModel4.type = "followUpFragsTo";

            LT3KillCounterChildModel lT3KillCounterChildModel5 = new LT3KillCounterChildModel();
            lT3KillCounterChildModel5.type = "fourVfourEqualizer";

            foreach (var player in (serverDataBase.GetPlayerTeamDerivObj(serverDataBase.GetTotalRoundCount())).CTplayers)
            {
                L3TKillCountersPlayerBreakDown PlayerBreakDown = new L3TKillCountersPlayerBreakDown();
                PlayerBreakDown.name = player.Name;
                lT3KillCounterChildModel.l3TKillCountersPlayerBreakDowns.Add(PlayerBreakDown);

                L3TKillCountersPlayerBreakDown PlayerBreakDown1 = new L3TKillCountersPlayerBreakDown();
                PlayerBreakDown1.name = player.Name;
                lT3KillCounterChildModel1.l3TKillCountersPlayerBreakDowns.Add(PlayerBreakDown1);


                L3TKillCountersPlayerBreakDown PlayerBreakDown2 = new L3TKillCountersPlayerBreakDown();
                PlayerBreakDown2.name = player.Name;
                lT3KillCounterChildModel2.l3TKillCountersPlayerBreakDowns.Add(PlayerBreakDown2);


                L3TKillCountersPlayerBreakDown PlayerBreakDown3 = new L3TKillCountersPlayerBreakDown();
                PlayerBreakDown3.name = player.Name;
                lT3KillCounterChildModel3.l3TKillCountersPlayerBreakDowns.Add(PlayerBreakDown3);

                L3TKillCountersPlayerBreakDown PlayerBreakDown4 = new L3TKillCountersPlayerBreakDown();
                PlayerBreakDown4.name = player.Name;
                lT3KillCounterChildModel4.l3TKillCountersPlayerBreakDowns.Add(PlayerBreakDown4);

                L3TKillCountersPlayerBreakDown PlayerBreakDown5 = new L3TKillCountersPlayerBreakDown();
                PlayerBreakDown5.name = player.Name;
                lT3KillCounterChildModel5.l3TKillCountersPlayerBreakDowns.Add(PlayerBreakDown5);
            }

            lT3KillCounters.lT3KillCountersCT.Add(lT3KillCounterChildModel);
            lT3KillCounters.lT3KillCountersCT.Add(lT3KillCounterChildModel1);
            lT3KillCounters.lT3KillCountersCT.Add(lT3KillCounterChildModel2);
            lT3KillCounters.lT3KillCountersCT.Add(lT3KillCounterChildModel3);
            lT3KillCounters.lT3KillCountersCT.Add(lT3KillCounterChildModel4);
            lT3KillCounters.lT3KillCountersCT.Add(lT3KillCounterChildModel5);

            LT3KillCounterChildModel lT3KillCounterChildModelT = new LT3KillCounterChildModel();
            lT3KillCounterChildModelT.type = "unTradedOpeners";

            LT3KillCounterChildModel lT3KillCounterChildModelT1 = new LT3KillCounterChildModel();
            lT3KillCounterChildModelT1.type = "tradedOpeners";

            LT3KillCounterChildModel lT3KillCounterChildModelT2 = new LT3KillCounterChildModel();
            lT3KillCounterChildModelT2.type = "firstResponseKill";

            LT3KillCounterChildModel lT3KillCounterChildModelT3 = new LT3KillCounterChildModel();
            lT3KillCounterChildModelT3.type = "followUpFragsUT";

            LT3KillCounterChildModel lT3KillCounterChildModelT4 = new LT3KillCounterChildModel();
            lT3KillCounterChildModelT4.type = "followUpFragsTo";

            LT3KillCounterChildModel lT3KillCounterChildModelT5 = new LT3KillCounterChildModel();
            lT3KillCounterChildModelT5.type = "fourVfourEqualizer";

            foreach (var player in (serverDataBase.GetPlayerTeamDerivObj(serverDataBase.GetTotalRoundCount())).Tplayers)
            {
                L3TKillCountersPlayerBreakDown PlayerBreakDown = new L3TKillCountersPlayerBreakDown();
                PlayerBreakDown.name = player.Name;
                lT3KillCounterChildModelT.l3TKillCountersPlayerBreakDowns.Add(PlayerBreakDown);

                L3TKillCountersPlayerBreakDown PlayerBreakDown1 = new L3TKillCountersPlayerBreakDown();
                PlayerBreakDown1.name = player.Name;
                lT3KillCounterChildModelT1.l3TKillCountersPlayerBreakDowns.Add(PlayerBreakDown1);


                L3TKillCountersPlayerBreakDown PlayerBreakDown2 = new L3TKillCountersPlayerBreakDown();
                PlayerBreakDown2.name = player.Name;
                lT3KillCounterChildModelT2.l3TKillCountersPlayerBreakDowns.Add(PlayerBreakDown2);


                L3TKillCountersPlayerBreakDown PlayerBreakDown3 = new L3TKillCountersPlayerBreakDown();
                PlayerBreakDown3.name = player.Name;
                lT3KillCounterChildModelT3.l3TKillCountersPlayerBreakDowns.Add(PlayerBreakDown3);

                L3TKillCountersPlayerBreakDown PlayerBreakDown4 = new L3TKillCountersPlayerBreakDown();
                PlayerBreakDown4.name = player.Name;
                lT3KillCounterChildModelT4.l3TKillCountersPlayerBreakDowns.Add(PlayerBreakDown4);

                L3TKillCountersPlayerBreakDown PlayerBreakDown5 = new L3TKillCountersPlayerBreakDown();
                PlayerBreakDown5.name = player.Name;
                lT3KillCounterChildModelT5.l3TKillCountersPlayerBreakDowns.Add(PlayerBreakDown5);
            }

            lT3KillCounters.lT3KillCountersT.Add(lT3KillCounterChildModelT);
            lT3KillCounters.lT3KillCountersT.Add(lT3KillCounterChildModelT1);
            lT3KillCounters.lT3KillCountersT.Add(lT3KillCounterChildModelT2);
            lT3KillCounters.lT3KillCountersT.Add(lT3KillCounterChildModelT3);
            lT3KillCounters.lT3KillCountersT.Add(lT3KillCounterChildModelT4);
            lT3KillCounters.lT3KillCountersT.Add(lT3KillCounterChildModelT5);

        }
        public LT3KillCounters PopulateModelFullTime(UniqueKillStatsModel uniqueKillStatsModel, ServerDataBase serverDataBase)
        {
            CounterExpansionModel counterExpansionModel = new CounterExpansionModel();

            var temp = serverDataBase.GetPlayerTeamDerivObj(serverDataBase.GetTotalRoundCount());
            foreach (var player in temp.CTplayers)
            {
                PlayerUniqueKillsModel playerUniqueKillsModel = new PlayerUniqueKillsModel();
                playerUniqueKillsModel.name = player.Name;
                playerUniqueKillsModel.team = player.Clan;
                counterExpansionModel.teamAList.Add(playerUniqueKillsModel);
            }
            foreach (var player in temp.Tplayers)
            {
                PlayerUniqueKillsModel playerUniqueKillsModel = new PlayerUniqueKillsModel();
                playerUniqueKillsModel.name = player.Name;
                playerUniqueKillsModel.team = player.Clan;
                counterExpansionModel.teamBList.Add(playerUniqueKillsModel);
            }


            for (int i = 0; i < serverDataBase.GetTotalRoundCount(); i++)
            {
                var killfilter = indexFilters.GetKillBOFilter(i);
                var KillsList = serverDataBase.GetDeriv_Kill_BO(killfilter);

                firstResponseKill.PopulateFirstResponseKillServ(KillsList, counterExpansionModel);
                followupFrag.PopulateFollowUpFrag(KillsList, counterExpansionModel, serverDataBase);
                FourvFourEqualizer.PopulateFourVFourServ(KillsList, counterExpansionModel, serverDataBase);
                openerKill.populateOpenerKillServ(KillsList, counterExpansionModel, serverDataBase);
            }


            lT3KillCounters.lT3KillCountersCT[0].total = uniqueKillStatsModel.unTradedOpeners.teamCTTotal;
            lT3KillCounters.lT3KillCountersT[0].total = uniqueKillStatsModel.unTradedOpeners.TeamTTotal;

            lT3KillCounters.lT3KillCountersCT[1].total = uniqueKillStatsModel.tradedOpeners.teamCTTotal;
            lT3KillCounters.lT3KillCountersT[1].total = uniqueKillStatsModel.tradedOpeners.TeamTTotal;

            lT3KillCounters.lT3KillCountersCT[2].total = uniqueKillStatsModel.firstResponseKill.teamCTTotal;
            lT3KillCounters.lT3KillCountersT[2].total = uniqueKillStatsModel.firstResponseKill.TeamTTotal;

            lT3KillCounters.lT3KillCountersCT[3].total = uniqueKillStatsModel.followUpFragsUT.teamCTTotal;
            lT3KillCounters.lT3KillCountersT[3].total = uniqueKillStatsModel.followUpFragsUT.TeamTTotal;

            lT3KillCounters.lT3KillCountersCT[4].total = uniqueKillStatsModel.followUpFragsTo.teamCTTotal;
            lT3KillCounters.lT3KillCountersT[4].total = uniqueKillStatsModel.followUpFragsTo.TeamTTotal;

            lT3KillCounters.lT3KillCountersCT[5].total = uniqueKillStatsModel.fourVfourEqualizer.teamCTTotal;
            lT3KillCounters.lT3KillCountersT[5].total = uniqueKillStatsModel.fourVfourEqualizer.TeamTTotal;


            foreach (var player in counterExpansionModel.teamAList)
            {
                foreach (var playerlT3 in lT3KillCounters.lT3KillCountersCT[0].l3TKillCountersPlayerBreakDowns)
                {
                    if (playerlT3.name == player.name)
                    {
                        playerlT3.contribution = player.untradedOpenersKills.Count();
                        playerlT3.Opportunity = player.untradedOpenersKillOpportunities.Count();
                        playerlT3.contributionPerRound = player.untradedOpenersKillOpportunities.Count() / serverDataBase.GetTotalRoundCount();
                    }
                }
                foreach (var playerlT3 in lT3KillCounters.lT3KillCountersCT[1].l3TKillCountersPlayerBreakDowns)
                {
                    if (playerlT3.name == player.name)
                    {
                        playerlT3.contribution = player.tradedOpenersKills.Count();
                        playerlT3.Opportunity = player.tradedOpenersKillOpportunities.Count();
                        playerlT3.contributionPerRound = player.tradedOpenersKills.Count() / serverDataBase.GetTotalRoundCount();
                    }
                }
                foreach (var playerlT3 in lT3KillCounters.lT3KillCountersCT[2].l3TKillCountersPlayerBreakDowns)
                {
                    if (playerlT3.name == player.name)
                    {
                        playerlT3.contribution = player.firstResponseKills.Count();
                        playerlT3.Opportunity = player.firstResponseKillOpportunities.Count();
                        playerlT3.contributionPerRound = player.firstResponseKills.Count() / serverDataBase.GetTotalRoundCount();
                    }
                }
                foreach (var playerlT3 in lT3KillCounters.lT3KillCountersCT[3].l3TKillCountersPlayerBreakDowns)
                {
                    if (playerlT3.name == player.name)
                    {
                        playerlT3.contribution = player.followUpFragsUTKills.Count();
                        playerlT3.Opportunity = player.followUpFragsUTKillOpportunities.Count();
                        playerlT3.contributionPerRound = player.followUpFragsUTKills.Count() / serverDataBase.GetTotalRoundCount();
                    }
                }
                foreach (var playerlT3 in lT3KillCounters.lT3KillCountersCT[4].l3TKillCountersPlayerBreakDowns)
                {
                    if (playerlT3.name == player.name)
                    {
                        playerlT3.contribution = player.followUpFragsToKills.Count();
                        playerlT3.Opportunity = player.followUpFragsToKillOpportunities.Count();
                        playerlT3.contributionPerRound = player.followUpFragsToKills.Count() / serverDataBase.GetTotalRoundCount();
                    }
                }
                foreach (var playerlT3 in lT3KillCounters.lT3KillCountersCT[5].l3TKillCountersPlayerBreakDowns)
                {
                    if (playerlT3.name == player.name)
                    {
                        playerlT3.contribution = player.fourVfourEqualizerKills.Count();
                        playerlT3.Opportunity = player.fourVfourEqualizerKillOpportunities.Count();
                        playerlT3.contributionPerRound = player.fourVfourEqualizerKills.Count() / serverDataBase.GetTotalRoundCount();
                    }
                }

            }

            foreach (var player in counterExpansionModel.teamBList)
            {

                foreach (var playerlT3 in lT3KillCounters.lT3KillCountersT[0].l3TKillCountersPlayerBreakDowns)
                {
                    if (playerlT3.name == player.name)
                    {
                        playerlT3.contribution = player.untradedOpenersKills.Count();
                        playerlT3.Opportunity = player.untradedOpenersKillOpportunities.Count();
                        playerlT3.contributionPerRound = player.untradedOpenersKillOpportunities.Count() / serverDataBase.GetTotalRoundCount();
                    }
                }
                foreach (var playerlT3 in lT3KillCounters.lT3KillCountersT[1].l3TKillCountersPlayerBreakDowns)
                {
                    if (playerlT3.name == player.name)
                    {
                        playerlT3.contribution = player.tradedOpenersKills.Count();
                        playerlT3.Opportunity = player.tradedOpenersKillOpportunities.Count();
                        playerlT3.contributionPerRound = player.tradedOpenersKills.Count() / serverDataBase.GetTotalRoundCount();
                    }
                }
                foreach (var playerlT3 in lT3KillCounters.lT3KillCountersT[2].l3TKillCountersPlayerBreakDowns)
                {
                    if (playerlT3.name == player.name)
                    {
                        playerlT3.contribution = player.firstResponseKills.Count();
                        playerlT3.Opportunity = player.firstResponseKillOpportunities.Count();
                        playerlT3.contributionPerRound = player.firstResponseKills.Count() / serverDataBase.GetTotalRoundCount();
                    }
                }
                foreach (var playerlT3 in lT3KillCounters.lT3KillCountersT[3].l3TKillCountersPlayerBreakDowns)
                {
                    if (playerlT3.name == player.name)
                    {
                        playerlT3.contribution = player.followUpFragsUTKills.Count();
                        playerlT3.Opportunity = player.followUpFragsUTKillOpportunities.Count();
                        playerlT3.contributionPerRound = player.followUpFragsUTKills.Count() / serverDataBase.GetTotalRoundCount();
                    }
                }
                foreach (var playerlT3 in lT3KillCounters.lT3KillCountersT[4].l3TKillCountersPlayerBreakDowns)
                {
                    if (playerlT3.name == player.name)
                    {
                        playerlT3.contribution = player.followUpFragsToKills.Count();
                        playerlT3.Opportunity = player.followUpFragsToKillOpportunities.Count();
                        playerlT3.contributionPerRound = player.followUpFragsToKills.Count() / serverDataBase.GetTotalRoundCount();
                    }
                }
                foreach (var playerlT3 in lT3KillCounters.lT3KillCountersT[5].l3TKillCountersPlayerBreakDowns)
                {
                    if (playerlT3.name == player.name)
                    {
                        playerlT3.contribution = player.fourVfourEqualizerKills.Count();
                        playerlT3.Opportunity = player.fourVfourEqualizerKillOpportunities.Count();
                        playerlT3.contributionPerRound = player.fourVfourEqualizerKills.Count() / serverDataBase.GetTotalRoundCount();
                    }
                }
            }
            return lT3KillCounters;
        }
    }
}
