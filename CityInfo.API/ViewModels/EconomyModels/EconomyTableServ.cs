using CityInfo.API.Filters;
using CityInfo.API.Services.DatabaseServ;
using CSGO_GSI_Backend.Models.BusinessObjects.DerivBO;

namespace CityInfo.API.ViewModels.EconomyModels
{
    public class EconomyTableServ
    {
        public EconomyTable economyTable { get; set; }
        public EconomyTableServ()
        {
            economyTable = new EconomyTable();
        }
        public void SetEcononmyTable(ServerDataBase serverDataBase)
        {
            IndexFilters indexFilters = new IndexFilters();
            for (int i = 0; i < serverDataBase.GetTotalRoundCount(); i++)
            {
                if (i == 15)
                {
                    SwitcheconomyTableValues();
                }

                var roundCondFilter = indexFilters.GetRoundCondFilter(i);
                var firstdocument = serverDataBase.GetRoundCondDerivObj(roundCondFilter);

                var roundEconomyStateFilter = indexFilters.GetRoundEconomyStateFilter(i);
                var secondDocument = serverDataBase.GetRoundEconomyStateDerivObj(roundEconomyStateFilter);

                if (firstdocument != null && secondDocument != null)
                {
                    PopulateeconomyTable(secondDocument, firstdocument);
                }
            }
            var document = serverDataBase.GetPlayerTeamDerivObj(serverDataBase.GetTotalRoundCount() - 1);
            economyTable.teamCT.teamName = document.CTplayers[0].Clan;
            economyTable.teamT.teamName = document.Tplayers[0].Clan;
        }
        public void PopulateeconomyTable(Deriv_RoundEconomyState_BO deriv_RoundEconomyState_BO, Deriv_RoundCond_BO deriv_RoundCond_BO)
        {
            if (deriv_RoundEconomyState_BO.ecoBuyCT == true)
            {
                if (deriv_RoundCond_BO.win_team == "CT")
                {
                    economyTable.teamCT.ecoRoundEconomy.won += 1;
                }
                economyTable.teamCT.ecoRoundEconomy.total += 1;
            }
            if (deriv_RoundEconomyState_BO.ecoBuyT == true)
            {
                if (deriv_RoundCond_BO.win_team == "T")
                {
                    economyTable.teamT.ecoRoundEconomy.won += 1;
                }
                economyTable.teamT.ecoRoundEconomy.won += 1;
            }
            if (deriv_RoundEconomyState_BO.halfBuyCT == true)
            {
                if (deriv_RoundCond_BO.win_team == "CT")
                {
                    economyTable.teamCT.halfbuyRoundEconomy.won += 1;
                }
                economyTable.teamCT.halfbuyRoundEconomy.total += 1;
            }

            if (deriv_RoundEconomyState_BO.halfBuyT == true)
            {
                if (deriv_RoundCond_BO.win_team == "T")
                {
                    economyTable.teamT.halfbuyRoundEconomy.won += 1;
                }
                economyTable.teamT.halfbuyRoundEconomy.total += 1;
            }

            if (deriv_RoundEconomyState_BO.forceBuyCT == true)
            {
                if (deriv_RoundCond_BO.win_team == "CT")
                {
                    economyTable.teamCT.forcebuyRoundEconomy.won += 1;
                }
                economyTable.teamCT.forcebuyRoundEconomy.total += 1;
            }

            if (deriv_RoundEconomyState_BO.forceBuyT == true)
            {
                if (deriv_RoundCond_BO.win_team == "T")
                {
                    economyTable.teamT.forcebuyRoundEconomy.won += 1;
                }
                economyTable.teamT.forcebuyRoundEconomy.total += 1;
            }

            if (deriv_RoundEconomyState_BO.fullBuyCT == true)
            {
                if (deriv_RoundCond_BO.win_team == "CT")
                {
                    economyTable.teamCT.fullbuyRoundEconomy.won += 1;
                }
                economyTable.teamCT.fullbuyRoundEconomy.total += 1;
            }
            if (deriv_RoundEconomyState_BO.fullBuyT == true)
            {
                if (deriv_RoundCond_BO.win_team == "T")
                {
                    economyTable.teamT.fullbuyRoundEconomy.won += 1;
                }
                economyTable.teamT.fullbuyRoundEconomy.total += 1;
            }

            if (deriv_RoundEconomyState_BO.partialfullBuyCT == true)
            {
                if (deriv_RoundCond_BO.win_team == "CT")
                {
                    economyTable.teamCT.partialfullbuyRoundEconomy.won += 1;
                }
                economyTable.teamCT.partialfullbuyRoundEconomy.total += 1;
            }
            if (deriv_RoundEconomyState_BO.partialfullBuyT == true)
            {
                if (deriv_RoundCond_BO.win_team == "CT")
                {
                    economyTable.teamT.partialfullbuyRoundEconomy.won += 1;
                }
                economyTable.teamT.partialfullbuyRoundEconomy.total += 1;
            }

            if (deriv_RoundEconomyState_BO.breakRoundCT == true)
            {
                if (deriv_RoundCond_BO.win_team == "CT")
                {
                    economyTable.teamCT.breakRoundEconomy.won += 1;
                }
                economyTable.teamCT.breakRoundEconomy.total += 1;
            }
            if (deriv_RoundEconomyState_BO.breakRoundT == true)
            {
                if (deriv_RoundCond_BO.win_team == "T")
                {
                    economyTable.teamT.breakRoundEconomy.won += 1;
                }
                economyTable.teamT.breakRoundEconomy.total += 1;
            }

            if (deriv_RoundEconomyState_BO.pistolRoundCT == true)
            {
                if (deriv_RoundCond_BO.win_team == "CT")
                {
                    economyTable.teamCT.pistolRoundEconomy.won += 1;
                }
                economyTable.teamCT.pistolRoundEconomy.total += 1;
            }
            if (deriv_RoundEconomyState_BO.pistolRoundT == true)
            {
                if (deriv_RoundCond_BO.win_team == "T")
                {
                    economyTable.teamT.pistolRoundEconomy.won += 1;
                }
                economyTable.teamT.pistolRoundEconomy.total += 1;
            }
            if (deriv_RoundEconomyState_BO.postPistolRoundCT == true)
            {
                if (deriv_RoundCond_BO.win_team == "CT")
                {
                    economyTable.teamCT.postPistolRoundEconomy.won += 1;
                }
                economyTable.teamCT.postPistolRoundEconomy.total += 1;
            }
            if (deriv_RoundEconomyState_BO.postPistolRoundT == true)
            {
                if (deriv_RoundCond_BO.win_team == "T")
                {
                    economyTable.teamT.postPistolRoundEconomy.won += 1;
                }
                economyTable.teamT.postPistolRoundEconomy.total += 1;
            }
        }
        public void SwitcheconomyTableValues()
        {
            int tempX = economyTable.teamCT.ecoRoundEconomy.won;
            int tempZ = economyTable.teamCT.ecoRoundEconomy.total;
            economyTable.teamCT.ecoRoundEconomy.won = economyTable.teamT.ecoRoundEconomy.won;
            economyTable.teamCT.ecoRoundEconomy.total = economyTable.teamT.ecoRoundEconomy.total;
            economyTable.teamT.ecoRoundEconomy.won = tempX;
            economyTable.teamT.ecoRoundEconomy.total = tempZ;

            tempX = economyTable.teamCT.halfbuyRoundEconomy.won;
            tempZ = economyTable.teamCT.halfbuyRoundEconomy.total;
            economyTable.teamCT.halfbuyRoundEconomy.won = economyTable.teamT.halfbuyRoundEconomy.won;
            economyTable.teamCT.halfbuyRoundEconomy.total = economyTable.teamT.halfbuyRoundEconomy.total;
            economyTable.teamT.halfbuyRoundEconomy.won = tempX;
            economyTable.teamT.halfbuyRoundEconomy.total = tempZ;

            tempX = economyTable.teamCT.forcebuyRoundEconomy.won;
            tempZ = economyTable.teamCT.forcebuyRoundEconomy.total;
            economyTable.teamCT.forcebuyRoundEconomy.won = economyTable.teamT.forcebuyRoundEconomy.won;
            economyTable.teamCT.forcebuyRoundEconomy.total = economyTable.teamT.forcebuyRoundEconomy.total;
            economyTable.teamT.forcebuyRoundEconomy.won = tempX;
            economyTable.teamT.forcebuyRoundEconomy.total = tempZ;

            tempX = economyTable.teamCT.fullbuyRoundEconomy.won;
            tempZ = economyTable.teamCT.fullbuyRoundEconomy.total;
            economyTable.teamCT.fullbuyRoundEconomy.won = economyTable.teamT.fullbuyRoundEconomy.won;
            economyTable.teamCT.fullbuyRoundEconomy.total = economyTable.teamT.fullbuyRoundEconomy.total;
            economyTable.teamT.fullbuyRoundEconomy.won = tempX;
            economyTable.teamT.fullbuyRoundEconomy.total = tempZ;

            tempX = economyTable.teamCT.partialfullbuyRoundEconomy.won;
            tempZ = economyTable.teamCT.partialfullbuyRoundEconomy.total;
            economyTable.teamCT.partialfullbuyRoundEconomy.won = economyTable.teamT.partialfullbuyRoundEconomy.won;
            economyTable.teamCT.partialfullbuyRoundEconomy.total = economyTable.teamT.partialfullbuyRoundEconomy.total;
            economyTable.teamT.partialfullbuyRoundEconomy.won = tempX;
            economyTable.teamT.partialfullbuyRoundEconomy.total = tempZ;

            tempX = economyTable.teamCT.breakRoundEconomy.won;
            tempZ = economyTable.teamCT.breakRoundEconomy.total;
            economyTable.teamCT.breakRoundEconomy.won = economyTable.teamT.breakRoundEconomy.won;
            economyTable.teamCT.breakRoundEconomy.total = economyTable.teamT.breakRoundEconomy.total;
            economyTable.teamT.breakRoundEconomy.won = tempX;
            economyTable.teamT.breakRoundEconomy.total = tempZ;

            tempX = economyTable.teamCT.pistolRoundEconomy.won;
            tempZ = economyTable.teamCT.pistolRoundEconomy.total;
            economyTable.teamCT.pistolRoundEconomy.won = economyTable.teamT.pistolRoundEconomy.won;
            economyTable.teamCT.pistolRoundEconomy.total = economyTable.teamT.pistolRoundEconomy.total;
            economyTable.teamT.pistolRoundEconomy.won = tempX;
            economyTable.teamT.pistolRoundEconomy.total = tempZ;

            tempX = economyTable.teamCT.postPistolRoundEconomy.won;
            tempZ = economyTable.teamCT.postPistolRoundEconomy.total;
            economyTable.teamCT.postPistolRoundEconomy.won = economyTable.teamT.postPistolRoundEconomy.won;
            economyTable.teamCT.postPistolRoundEconomy.total = economyTable.teamT.postPistolRoundEconomy.total;
            economyTable.teamT.postPistolRoundEconomy.won = tempX;
            economyTable.teamT.postPistolRoundEconomy.total = tempZ;
        }
    }
}
