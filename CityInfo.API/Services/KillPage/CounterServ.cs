using CityInfo.API.Services.DatabaseServ;
using CityInfo.API.ViewModels.EconomyModels;
using CSGSI_FrontEnd.ViewModels.BasicStatsPageModels;
using CSGSI_FrontEnd.ViewModels.CounterModels;

namespace CityInfo.API.Services.KillPage
{
    public class CounterServ
    {
        public int totalRoundCount { get; set; }
        public string FH { get; set; }
        public string SH { get; set; }
        public string FT { get; set; }
        public string ot { get; set; }
        public PopulateCounterTableServ counterTable { get; set; }
        public EconomyTableModel economyTableModel { get; set; }
        public UniqueKillStatsModel uniqueKillStatsModel { get; set; }
        public CounterTableModel counterTableModel { get; set; }
        public CounterServ(string FH, string SH, string FT, string ot, int totalRoundCount)
        {
            this.FH = FH;
            this.SH = SH;
            this.FT = FT;
            this.ot = ot;
            this.totalRoundCount = totalRoundCount;
            uniqueKillStatsModel = new UniqueKillStatsModel();
            economyTableModel = new EconomyTableModel();
            counterTable = new PopulateCounterTableServ();
        }
        public CounterServ()
        {
            uniqueKillStatsModel = new UniqueKillStatsModel();
            economyTableModel = new EconomyTableModel();
            counterTable = new PopulateCounterTableServ();
        }
        public void SetEcononmyTable(ServerDataBase serverDataBase)
        {
            for (int i = 0; i < totalRoundCount; i++)
            {
                if (i == 15) 
                {
                    counterTable.SwitchEconomyTableModelValues(economyTableModel);
                    counterTable.SwitchUniqueKillTableValues(uniqueKillStatsModel);
                }
                counterTable.PopulateCounterTableService(serverDataBase, uniqueKillStatsModel, economyTableModel, i);
                Console.WriteLine("Round" + i);
            }
        }
        public void CheckFiltersCounterTable(ServerDataBase serverDataBase)
        {
            if (FH == "on")
            {
                SetFirstHalfCounterTable(serverDataBase);
            }
            else if (SH == "on")
            {
                SetSecondHalfCounterTable(serverDataBase);
            }
            else if (FT == "on")
            {
                SetFullTimeCounterTable(serverDataBase);
            }
            else if (ot == "on")
            {
                SetOTCounterTable(serverDataBase);
            }
        }
        public void SetFirstHalfCounterTable(ServerDataBase serverDataBase)
        {
            if (totalRoundCount > 15)
            {
                for (int i = 0; i < 15; i++)
                {
                    counterTable.PopulateCounterTableService(serverDataBase, uniqueKillStatsModel, economyTableModel, i);
                }
            }
            else
            {
                for (int i = 0; i < totalRoundCount; i++)
                {
                    counterTable.PopulateCounterTableService(serverDataBase, uniqueKillStatsModel, economyTableModel, i);
                }
            }
        }
        public void SetSecondHalfCounterTable(ServerDataBase serverDataBase)
        {
            if (totalRoundCount > 15 && totalRoundCount < 30)
            {
                for (int i = 15; i < totalRoundCount; i++)
                {
                    if (i >= 30)
                    {
                        break;
                    }
                    counterTable.PopulateCounterTableService(serverDataBase, uniqueKillStatsModel, economyTableModel, i);
                }
            }
        }
        public void SetFullTimeCounterTable(ServerDataBase serverDataBase)
        {
            for (int i = 0; i < totalRoundCount; i++)
            {
                if (i == 15)
                {
                    counterTable.SwitchEconomyTableModelValues(economyTableModel);
                    counterTable.SwitchUniqueKillTableValues(uniqueKillStatsModel);
                }

                counterTable.PopulateCounterTableService(serverDataBase, uniqueKillStatsModel, economyTableModel, i);

                Console.WriteLine("Round" + i);
            }
        }
        public void SetOTCounterTable(ServerDataBase serverDataBase)
        {
            for (int i = 30; i < totalRoundCount; i++)
            {
                counterTable.PopulateCounterTableService(serverDataBase, uniqueKillStatsModel, economyTableModel, i);
            }
        }
        public void MergeModels(ServerDataBase serverDataBase)
        {
            var temp = serverDataBase.GetPlayerTeamDerivObj(totalRoundCount);
            counterTableModel = new CounterTableModel(economyTableModel, uniqueKillStatsModel, temp.CTplayers[0].Clan, temp.Tplayers[0].Clan);
        }

    }
}
