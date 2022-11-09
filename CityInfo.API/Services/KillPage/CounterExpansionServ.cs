using CityInfo.API.Filters;
using CityInfo.API.Services.DatabaseServ;
using CityInfo.API.Services.UniqueKillServ;

using CSGSI_FrontEnd.ViewModels.CounterExpansionModels;

namespace CSGSI_FrontEnd.FrontEndServices.KillPageServ
{
    public class CounterExpansionServ
    {
        public string FirstHalf { get; set; }  
        public string SecondHalf { get; set; }
        public string FullTime { get; set; }
        public string OT { get; set; }
        public int totalRound { get; set; }
        public CounterExpansionModel counterExpansionModel { get; set; }
        public FirstResponseKillServ firstResponseKillServ { get; set; }
        IndexFilters indexFilters { get; set; }
        public CounterExpansionServ(string FirstHalf,string SecondHalf, string FullTime,string OT, int totalRound)
        {
            this.FirstHalf = FirstHalf;
            this.SecondHalf = SecondHalf;
            this.FullTime = FullTime;
            this.OT = OT;
            this.totalRound = totalRound;
            counterExpansionModel = new CounterExpansionModel();
            indexFilters = new IndexFilters();
            firstResponseKillServ = new FirstResponseKillServ();
        }
        public CounterExpansionServ()
        {
            counterExpansionModel = new CounterExpansionModel();
            indexFilters = new IndexFilters();
            firstResponseKillServ = new FirstResponseKillServ();
        }
        public void InitializeCounterExpansionModel(ServerDataBase serverDataBase)
        {
            var temp = serverDataBase.GetPlayerTeamDerivObj(1);
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
        }
        public void CheckFiltersCounterExpansionTable(ServerDataBase serverDataBase)
        {
            InitializeCounterExpansionModel(serverDataBase);
            if (FirstHalf == "on")
            {
                SetFirstHalfCounterExpansionTable(serverDataBase);
            }
            else if (SecondHalf == "on")
            {
                SetSecondHalfCounterExpansionTable(serverDataBase);
            }
            else if (FullTime == "on")
            {
                SetFullTimeCounterExpansionTable(serverDataBase);
            }
            else if (OT == "on")
            {
                SetOTCounterExpansionTable(serverDataBase);
            }
            else
            {
                SetFullTimeCounterExpansionTable(serverDataBase);
            }
        }
        public void SetFirstHalfCounterExpansionTable(ServerDataBase serverDataBase)
        {
            
            if (totalRound >= 15)
            {
                for (int i = 0; i < 15; i++)
                {
                    var killfilter = indexFilters.GetKillBOFilter(i);
                    var KillsList = serverDataBase.GetDeriv_Kill_BO(killfilter);
                    firstResponseKillServ.PopulateFirstResponseKillServ(KillsList, counterExpansionModel);
                }
            }
            else
            {
                for (int i = 0; i < totalRound; i++)
                {
                    var killfilter = indexFilters.GetKillBOFilter(i);
                    var KillsList = serverDataBase.GetDeriv_Kill_BO(killfilter);
                    firstResponseKillServ.PopulateFirstResponseKillServ(KillsList, counterExpansionModel);
                }
            }
        }
        public void SetSecondHalfCounterExpansionTable(ServerDataBase serverDataBase)
        {
            if (totalRound >= 15)
            {
                for (int i = 15; i < totalRound; i++)
                {
                    var killfilter = indexFilters.GetKillBOFilter(i);
                    var KillsList = serverDataBase.GetDeriv_Kill_BO(killfilter);
                    firstResponseKillServ.PopulateFirstResponseKillServ(KillsList, counterExpansionModel);
                }
            }
        }
        public void SetFullTimeCounterExpansionTable(ServerDataBase serverDataBase)
        {
            for (int i = 0; i < totalRound; i++)
            {
                var killfilter = indexFilters.GetKillBOFilter(i);
                var KillsList = serverDataBase.GetDeriv_Kill_BO(killfilter);
                firstResponseKillServ.PopulateFirstResponseKillServ(KillsList, counterExpansionModel);
            }
        }
        public void SetOTCounterExpansionTable(ServerDataBase serverDataBase)
        {
            if (totalRound > 30)
            {
                for (int i = 30; i < totalRound; i++)
                {
                    var killfilter = indexFilters.GetKillBOFilter(i);
                    var KillsList = serverDataBase.GetDeriv_Kill_BO(killfilter);
                    firstResponseKillServ.PopulateFirstResponseKillServ(KillsList, counterExpansionModel);
                }
            }
        }
    }
}
