using CityInfo.API.Filters;
using CityInfo.API.Services.DatabaseServ;
using CityInfo.API.Services.UniqueKillServ;
using CSGO_GSI_Backend.Models.BusinessObjects.DerivBO;
using CSGSI_FrontEnd.FrontEndServices.UniqueKillServ;
using CSGSI_FrontEnd.ViewModels.BasicStatsPageModels;

namespace CityInfo.API.Services.KillPage
{
    public class PopulateCounterTableServ
    {
        public IndexFilters indexFilters { get; set; }
        FirstResponseKillServ firstResponseKill { get; set; }
        FollowupFragServ followupFrag { get; set; }
        FourvFourEqualizerServ FourvFourEqualizer { get; set; }
        OpenerKillServ openerKill { get; set; }
        public PopulateCounterTableServ()
        {
            indexFilters = new IndexFilters();
            firstResponseKill = new FirstResponseKillServ();
            followupFrag = new FollowupFragServ();
            FourvFourEqualizer = new FourvFourEqualizerServ();
            openerKill = new OpenerKillServ();
        }
        public void PopulateCounterTableService(ServerDataBase serverDataBase, UniqueKillStatsModel uniqueKillStatsModel, EconomyTableModel economyTableModel, int i)
        {
            var roundCondFilter = indexFilters.GetRoundCondFilter(i);
            var firstdocument = serverDataBase.GetRoundCondDerivObj(roundCondFilter);

            var roundEconomyStateFilter = indexFilters.GetRoundEconomyStateFilter(i);
            var secondDocument = serverDataBase.GetRoundEconomyStateDerivObj(roundEconomyStateFilter);

            if (firstdocument != null && secondDocument != null)
            {
                PopulateEconomyTableModel(secondDocument, firstdocument, economyTableModel);
            }

            var killfilter = indexFilters.GetKillBOFilter(i);
            var KillsList = serverDataBase.GetDeriv_Kill_BO(killfilter);

            firstResponseKill.PopulateFirstResponseKillServ(KillsList, uniqueKillStatsModel.firstResponseKill);
            followupFrag.PopulateFollowUpFrag(KillsList, uniqueKillStatsModel.followUpFragsUT, uniqueKillStatsModel.followUpFragsTo, serverDataBase);
            FourvFourEqualizer.PopulateFourVFourServ(KillsList, uniqueKillStatsModel.fourVfourEqualizer, serverDataBase);
            openerKill.populateOpenerKillServ(KillsList, uniqueKillStatsModel.tradedOpeners, uniqueKillStatsModel.unTradedOpeners, serverDataBase);
        }
        public void SwitchUniqueKillTableValues(UniqueKillStatsModel uniqueKillStatsModel)
        {
            int tempX = uniqueKillStatsModel.unTradedOpeners.teamCTTotal;
            uniqueKillStatsModel.unTradedOpeners.teamCTTotal = uniqueKillStatsModel.unTradedOpeners.TeamTTotal;
            uniqueKillStatsModel.unTradedOpeners.TeamTTotal = tempX;

            tempX = uniqueKillStatsModel.tradedOpeners.teamCTTotal;
            uniqueKillStatsModel.tradedOpeners.teamCTTotal = uniqueKillStatsModel.tradedOpeners.TeamTTotal;
            uniqueKillStatsModel.tradedOpeners.TeamTTotal = tempX;

            tempX = uniqueKillStatsModel.firstResponseKill.teamCTTotal;
            uniqueKillStatsModel.firstResponseKill.teamCTTotal = uniqueKillStatsModel.firstResponseKill.TeamTTotal;
            uniqueKillStatsModel.firstResponseKill.TeamTTotal = tempX;

            tempX = uniqueKillStatsModel.followUpFragsUT.teamCTTotal;
            uniqueKillStatsModel.followUpFragsUT.teamCTTotal = uniqueKillStatsModel.followUpFragsUT.TeamTTotal;
            uniqueKillStatsModel.followUpFragsUT.TeamTTotal = tempX;

            tempX = uniqueKillStatsModel.followUpFragsTo.teamCTTotal;
            uniqueKillStatsModel.followUpFragsTo.teamCTTotal = uniqueKillStatsModel.followUpFragsTo.TeamTTotal;
            uniqueKillStatsModel.followUpFragsTo.TeamTTotal = tempX;

            tempX = uniqueKillStatsModel.fourVfourEqualizer.teamCTTotal;
            uniqueKillStatsModel.fourVfourEqualizer.teamCTTotal = uniqueKillStatsModel.fourVfourEqualizer.TeamTTotal;
            uniqueKillStatsModel.fourVfourEqualizer.TeamTTotal = tempX;
        }
        public void PopulateEconomyTableModel(Deriv_RoundEconomyState_BO deriv_RoundEconomyState_BO, Deriv_RoundCond_BO deriv_RoundCond_BO, EconomyTableModel economyTableModel)
        {
            if (deriv_RoundEconomyState_BO.ecoBuyCT == true)
            {
                if (deriv_RoundCond_BO.win_team == "CT")
                {
                    economyTableModel.ecoRoundEconomy.teamCTEconomy.won += 1;
                }
                else if (deriv_RoundCond_BO.win_team == "T")
                {
                    economyTableModel.ecoRoundEconomy.teamCTEconomy.lost += 1;
                }
                economyTableModel.ecoRoundEconomy.teamCTEconomy.total += 1;
            }
            if (deriv_RoundEconomyState_BO.ecoBuyT == true)
            {
                if (deriv_RoundCond_BO.win_team == "T")
                {
                    economyTableModel.ecoRoundEconomy.teamTEconomy.won += 1;
                }
                else if (deriv_RoundCond_BO.win_team == "CT")
                {
                    economyTableModel.ecoRoundEconomy.teamTEconomy.lost += 1;
                }
                economyTableModel.ecoRoundEconomy.teamTEconomy.total += 1;
            }
            if (deriv_RoundEconomyState_BO.halfBuyCT == true)
            {
                if (deriv_RoundCond_BO.win_team == "CT")
                {
                    economyTableModel.halfbuyRoundEconomy.teamCTEconomy.won += 1;
                }
                if (deriv_RoundCond_BO.win_team == "T")
                {
                    economyTableModel.halfbuyRoundEconomy.teamCTEconomy.lost += 1;
                }
                economyTableModel.halfbuyRoundEconomy.teamCTEconomy.total += 1;
            }
            if (deriv_RoundEconomyState_BO.halfBuyT == true)
            {
                if (deriv_RoundCond_BO.win_team == "T")
                {
                    economyTableModel.halfbuyRoundEconomy.teamTEconomy.won += 1;
                }
                if (deriv_RoundCond_BO.win_team == "CT")
                {
                    economyTableModel.halfbuyRoundEconomy.teamTEconomy.lost += 1;
                }
                economyTableModel.halfbuyRoundEconomy.teamTEconomy.total += 1;
            }
            if (deriv_RoundEconomyState_BO.forceBuyCT == true)
            {
                if (deriv_RoundCond_BO.win_team == "CT")
                {
                    economyTableModel.forcebuyRoundEconomy.teamCTEconomy.won += 1;
                }
                else if (deriv_RoundCond_BO.win_team == "T")
                {
                    economyTableModel.forcebuyRoundEconomy.teamCTEconomy.lost += 1;
                }
                economyTableModel.forcebuyRoundEconomy.teamCTEconomy.total += 1;
            }
            if (deriv_RoundEconomyState_BO.forceBuyT == true)
            {
                if (deriv_RoundCond_BO.win_team == "T")
                {
                    economyTableModel.forcebuyRoundEconomy.teamTEconomy.won += 1;
                }
                else if (deriv_RoundCond_BO.win_team == "T")
                {
                    economyTableModel.forcebuyRoundEconomy.teamTEconomy.lost += 1;
                }
                economyTableModel.forcebuyRoundEconomy.teamTEconomy.total += 1;
            }
            if (deriv_RoundEconomyState_BO.fullBuyCT == true)
            {
                if (deriv_RoundCond_BO.win_team == "CT")
                {
                    economyTableModel.fullbuyRoundEconomy.teamCTEconomy.won += 1;
                }
                else if (deriv_RoundCond_BO.win_team == "T")
                {
                    economyTableModel.fullbuyRoundEconomy.teamCTEconomy.lost += 1;
                }
                economyTableModel.fullbuyRoundEconomy.teamCTEconomy.total += 1;
            }
            if (deriv_RoundEconomyState_BO.fullBuyT == true)
            {
                if (deriv_RoundCond_BO.win_team == "CT")
                {
                    economyTableModel.fullbuyRoundEconomy.teamTEconomy.lost += 1;
                }
                else if (deriv_RoundCond_BO.win_team == "T")
                {
                    economyTableModel.fullbuyRoundEconomy.teamTEconomy.won += 1;
                }
                economyTableModel.fullbuyRoundEconomy.teamTEconomy.total += 1;
            }
            if (deriv_RoundEconomyState_BO.partialfullBuyCT == true)
            {
                if (deriv_RoundCond_BO.win_team == "CT")
                {
                    economyTableModel.partialfullbuyRoundEconomy.teamCTEconomy.won += 1;
                }
                else if (deriv_RoundCond_BO.win_team == "T")
                {
                    economyTableModel.partialfullbuyRoundEconomy.teamCTEconomy.lost += 1;
                }
                economyTableModel.partialfullbuyRoundEconomy.teamCTEconomy.total += 1;
            }
            if (deriv_RoundEconomyState_BO.partialfullBuyT == true)
            {
                if (deriv_RoundCond_BO.win_team == "CT")
                {
                    economyTableModel.partialfullbuyRoundEconomy.teamTEconomy.lost += 1;
                }
                else if (deriv_RoundCond_BO.win_team == "T")
                {
                    economyTableModel.partialfullbuyRoundEconomy.teamTEconomy.won += 1;
                }
                economyTableModel.partialfullbuyRoundEconomy.teamTEconomy.total += 1;
            }
            if (deriv_RoundEconomyState_BO.breakRoundCT == true)
            {
                if (deriv_RoundCond_BO.win_team == "CT")
                {
                    economyTableModel.breakRoundEconomy.teamCTEconomy.won += 1;
                }
                else if (deriv_RoundCond_BO.win_team == "T")
                {
                    economyTableModel.breakRoundEconomy.teamCTEconomy.lost += 1;
                }
                economyTableModel.breakRoundEconomy.teamCTEconomy.total += 1;
            }
            if (deriv_RoundEconomyState_BO.breakRoundT == true)
            {
                if (deriv_RoundCond_BO.win_team == "CT")
                {
                    economyTableModel.breakRoundEconomy.teamTEconomy.lost += 1;
                }
                else if (deriv_RoundCond_BO.win_team == "T")
                {
                    economyTableModel.breakRoundEconomy.teamTEconomy.won += 1;
                }
                economyTableModel.breakRoundEconomy.teamTEconomy.total += 1;
            }
            if (deriv_RoundEconomyState_BO.pistolRoundCT == true)
            {
                if (deriv_RoundCond_BO.win_team == "CT")
                {
                    economyTableModel.pistolRoundEconomy.teamCTEconomy.won += 1;
                }
                else if (deriv_RoundCond_BO.win_team == "T")
                {
                    economyTableModel.pistolRoundEconomy.teamCTEconomy.lost += 1;
                }
                economyTableModel.pistolRoundEconomy.teamCTEconomy.total += 1;
            }
            if (deriv_RoundEconomyState_BO.pistolRoundT == true)
            {
                if (deriv_RoundCond_BO.win_team == "CT")
                {
                    economyTableModel.pistolRoundEconomy.teamTEconomy.lost += 1;
                }
                else if (deriv_RoundCond_BO.win_team == "T")
                {
                    economyTableModel.pistolRoundEconomy.teamTEconomy.won += 1;
                }
                economyTableModel.pistolRoundEconomy.teamTEconomy.total += 1;
            }
            if (deriv_RoundEconomyState_BO.postPistolRoundCT == true)
            {
                if (deriv_RoundCond_BO.win_team == "CT")
                {
                    economyTableModel.postPistolRoundEconomy.teamCTEconomy.won += 1;
                }
                else if (deriv_RoundCond_BO.win_team == "T")
                {
                    economyTableModel.postPistolRoundEconomy.teamCTEconomy.lost += 1;
                }
                economyTableModel.postPistolRoundEconomy.teamCTEconomy.total += 1;
            }
            if (deriv_RoundEconomyState_BO.postPistolRoundT == true)
            {
                if (deriv_RoundCond_BO.win_team == "CT")
                {
                    economyTableModel.postPistolRoundEconomy.teamTEconomy.lost += 1;
                }
                else if (deriv_RoundCond_BO.win_team == "T")
                {
                    economyTableModel.postPistolRoundEconomy.teamTEconomy.won += 1;
                }
                economyTableModel.postPistolRoundEconomy.teamTEconomy.total += 1;
            }
        }
        public void SwitchEconomyTableModelValues(EconomyTableModel economyTableModel)
        {
            int tempX = economyTableModel.ecoRoundEconomy.teamCTEconomy.won;
            int tempY = economyTableModel.ecoRoundEconomy.teamCTEconomy.lost;
            int tempZ = economyTableModel.ecoRoundEconomy.teamCTEconomy.total;
            economyTableModel.ecoRoundEconomy.teamCTEconomy.won = economyTableModel.ecoRoundEconomy.teamTEconomy.won;
            economyTableModel.ecoRoundEconomy.teamCTEconomy.lost = economyTableModel.ecoRoundEconomy.teamTEconomy.lost;
            economyTableModel.ecoRoundEconomy.teamCTEconomy.total = economyTableModel.ecoRoundEconomy.teamTEconomy.total;
            economyTableModel.ecoRoundEconomy.teamTEconomy.won = tempX;
            economyTableModel.ecoRoundEconomy.teamTEconomy.lost = tempY;
            economyTableModel.ecoRoundEconomy.teamTEconomy.total = tempZ;

            tempX = economyTableModel.halfbuyRoundEconomy.teamCTEconomy.won;
            tempY = economyTableModel.halfbuyRoundEconomy.teamCTEconomy.lost;
            tempZ = economyTableModel.halfbuyRoundEconomy.teamCTEconomy.total;
            economyTableModel.halfbuyRoundEconomy.teamCTEconomy.won = economyTableModel.halfbuyRoundEconomy.teamTEconomy.won;
            economyTableModel.halfbuyRoundEconomy.teamCTEconomy.lost = economyTableModel.halfbuyRoundEconomy.teamTEconomy.lost;
            economyTableModel.halfbuyRoundEconomy.teamCTEconomy.total = economyTableModel.halfbuyRoundEconomy.teamTEconomy.total;
            economyTableModel.halfbuyRoundEconomy.teamTEconomy.won = tempX;
            economyTableModel.halfbuyRoundEconomy.teamTEconomy.lost = tempY;
            economyTableModel.halfbuyRoundEconomy.teamTEconomy.total = tempZ;

            tempX = economyTableModel.forcebuyRoundEconomy.teamCTEconomy.won;
            tempY = economyTableModel.forcebuyRoundEconomy.teamCTEconomy.lost;
            tempZ = economyTableModel.forcebuyRoundEconomy.teamCTEconomy.total;
            economyTableModel.forcebuyRoundEconomy.teamCTEconomy.won = economyTableModel.forcebuyRoundEconomy.teamTEconomy.won;
            economyTableModel.forcebuyRoundEconomy.teamCTEconomy.lost = economyTableModel.forcebuyRoundEconomy.teamTEconomy.lost;
            economyTableModel.forcebuyRoundEconomy.teamCTEconomy.total = economyTableModel.forcebuyRoundEconomy.teamTEconomy.total;
            economyTableModel.forcebuyRoundEconomy.teamTEconomy.won = tempX;
            economyTableModel.forcebuyRoundEconomy.teamTEconomy.lost = tempY;
            economyTableModel.forcebuyRoundEconomy.teamTEconomy.total = tempZ;

            tempX = economyTableModel.fullbuyRoundEconomy.teamCTEconomy.won;
            tempY = economyTableModel.fullbuyRoundEconomy.teamCTEconomy.lost;
            tempZ = economyTableModel.fullbuyRoundEconomy.teamCTEconomy.total;
            economyTableModel.fullbuyRoundEconomy.teamCTEconomy.won = economyTableModel.fullbuyRoundEconomy.teamTEconomy.won;
            economyTableModel.fullbuyRoundEconomy.teamCTEconomy.lost = economyTableModel.fullbuyRoundEconomy.teamTEconomy.lost;
            economyTableModel.fullbuyRoundEconomy.teamCTEconomy.total = economyTableModel.fullbuyRoundEconomy.teamTEconomy.total;
            economyTableModel.fullbuyRoundEconomy.teamTEconomy.won = tempX;
            economyTableModel.fullbuyRoundEconomy.teamTEconomy.lost = tempY;
            economyTableModel.fullbuyRoundEconomy.teamTEconomy.total = tempZ;

            tempX = economyTableModel.partialfullbuyRoundEconomy.teamCTEconomy.won;
            tempY = economyTableModel.partialfullbuyRoundEconomy.teamCTEconomy.lost;
            tempZ = economyTableModel.partialfullbuyRoundEconomy.teamCTEconomy.total;
            economyTableModel.partialfullbuyRoundEconomy.teamCTEconomy.won = economyTableModel.partialfullbuyRoundEconomy.teamTEconomy.won;
            economyTableModel.partialfullbuyRoundEconomy.teamCTEconomy.lost = economyTableModel.partialfullbuyRoundEconomy.teamTEconomy.lost;
            economyTableModel.partialfullbuyRoundEconomy.teamCTEconomy.total = economyTableModel.partialfullbuyRoundEconomy.teamTEconomy.total;
            economyTableModel.partialfullbuyRoundEconomy.teamTEconomy.won = tempX;
            economyTableModel.partialfullbuyRoundEconomy.teamTEconomy.lost = tempY;
            economyTableModel.partialfullbuyRoundEconomy.teamTEconomy.total = tempZ;

            tempX = economyTableModel.breakRoundEconomy.teamCTEconomy.won;
            tempY = economyTableModel.breakRoundEconomy.teamCTEconomy.lost;
            tempZ = economyTableModel.breakRoundEconomy.teamCTEconomy.total;
            economyTableModel.breakRoundEconomy.teamCTEconomy.won = economyTableModel.breakRoundEconomy.teamTEconomy.won;
            economyTableModel.breakRoundEconomy.teamCTEconomy.lost = economyTableModel.breakRoundEconomy.teamTEconomy.lost;
            economyTableModel.breakRoundEconomy.teamCTEconomy.total = economyTableModel.breakRoundEconomy.teamTEconomy.total;
            economyTableModel.breakRoundEconomy.teamTEconomy.won = tempX;
            economyTableModel.breakRoundEconomy.teamTEconomy.lost = tempY;
            economyTableModel.breakRoundEconomy.teamTEconomy.total = tempZ;

            tempX = economyTableModel.pistolRoundEconomy.teamCTEconomy.won;
            tempY = economyTableModel.pistolRoundEconomy.teamCTEconomy.lost;
            tempZ = economyTableModel.pistolRoundEconomy.teamCTEconomy.total;
            economyTableModel.pistolRoundEconomy.teamCTEconomy.won = economyTableModel.pistolRoundEconomy.teamTEconomy.won;
            economyTableModel.pistolRoundEconomy.teamCTEconomy.lost = economyTableModel.pistolRoundEconomy.teamTEconomy.lost;
            economyTableModel.pistolRoundEconomy.teamCTEconomy.total = economyTableModel.pistolRoundEconomy.teamTEconomy.total;
            economyTableModel.pistolRoundEconomy.teamTEconomy.won = tempX;
            economyTableModel.pistolRoundEconomy.teamTEconomy.lost = tempY;
            economyTableModel.pistolRoundEconomy.teamTEconomy.total = tempZ;

            tempX = economyTableModel.postPistolRoundEconomy.teamCTEconomy.won;
            tempY = economyTableModel.postPistolRoundEconomy.teamCTEconomy.lost;
            tempZ = economyTableModel.postPistolRoundEconomy.teamCTEconomy.total;
            economyTableModel.postPistolRoundEconomy.teamCTEconomy.won = economyTableModel.postPistolRoundEconomy.teamTEconomy.won;
            economyTableModel.postPistolRoundEconomy.teamCTEconomy.lost = economyTableModel.postPistolRoundEconomy.teamTEconomy.lost;
            economyTableModel.postPistolRoundEconomy.teamCTEconomy.total = economyTableModel.postPistolRoundEconomy.teamTEconomy.total;
            economyTableModel.postPistolRoundEconomy.teamTEconomy.won = tempX;
            economyTableModel.postPistolRoundEconomy.teamTEconomy.lost = tempY;
            economyTableModel.postPistolRoundEconomy.teamTEconomy.total = tempZ;
        }
    }
}
