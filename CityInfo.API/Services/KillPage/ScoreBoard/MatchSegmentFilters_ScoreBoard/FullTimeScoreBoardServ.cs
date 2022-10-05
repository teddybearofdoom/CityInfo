using CityInfo.API.Filters;
using CityInfo.API.FrontEndServices.KillPageServ;
using CityInfo.API.Models.BusinessObjects.DerivBO;
using CityInfo.API.Services.DatabaseServ;
using CityInfo.API.Services.Functions;
using CityInfo.API.Services.KillPage.ScoreBoard;
using CityInfo.API.ViewModels.BasicStatsPageModels.ScoreBoardModels;


namespace CSGSI_FrontEnd.FrontEndServices.KillPageServ.ScoreBoard.MatchSegmentFilters_ScoreBoard
{
    public class FullTimeScoreBoardServ
    {
        public IndexFilters indexFilters { get; set; }
        public int totalRoundCount { get; set; }
        public FullTimeScoreBoardServ(int totalRoundCount)
        {
            indexFilters = new IndexFilters();
            this.totalRoundCount = totalRoundCount;
        }
        public KillTableModel SetFullTimeScoreBoard(ServerDataBase serverDataBase)
        {
            //List of player team across each round 
            List<Deriv_PlayerTeam_BO> ListofRounds = new List<Deriv_PlayerTeam_BO>();

            PopulateScoreBoardServ populateScoreBoardServ = new PopulateScoreBoardServ();

            for (int i = 1; i <= totalRoundCount; i++)
            {
                var CurrentRoundDocument = serverDataBase.GetPlayerTeamDerivObj(i);
                ListofRounds.Add(CurrentRoundDocument);
            }
            populateScoreBoardServ.PopulateScoreBoard(ListofRounds);
            return populateScoreBoardServ.killTableModel;
        }
        public KillTableModel SetFullTimeScoreBoard(ServerDataBase serverDataBase, EconomyFilters_ScoreBoard economyFilters_ScoreBoard)
        {
            for (int i = 1; i <= totalRoundCount; i++)
            {
                var RoundEconomyFilter = indexFilters.GetRoundEconomyStateFilter(i);
                var RoundEconomyDocument = serverDataBase.GetRoundEconomyStateDerivObj(RoundEconomyFilter);

                if (RoundEconomyDocument != null)
                {
                    var AwpFilter = indexFilters.GetAWPEquipFilter(i);
                    var AwpDocument = serverDataBase.GetAwpEquipDerivObj(AwpFilter);

                    var CurrentRoundDocument = serverDataBase.GetPlayerTeamDerivObj(RoundEconomyDocument.Round);

                    if (CurrentRoundDocument != null && i == 1)
                    {
                        economyFilters_ScoreBoard.IntializeScoreBoardForEconomyFilters(CurrentRoundDocument);
                    }
                    var PreviousRoundDocument = serverDataBase.GetPlayerTeamDerivObj(RoundEconomyDocument.Round - 1);

                    if (PreviousRoundDocument != null && CurrentRoundDocument != null)
                    {
                        economyFilters_ScoreBoard.CheckEconomyFilters(CurrentRoundDocument, PreviousRoundDocument, RoundEconomyDocument, AwpDocument);
                    }
                }
            }
            return economyFilters_ScoreBoard.killTableModel;
        }
        public KillTableModel SetFullTimeScoreBoard(float timestamp, string Phase, ServerDataBase serverDataBase, EconomyFilters_ScoreBoard economyFilters_ScoreBoard, TimerFunction timerFunction)
        {
            for (int i = 1; i <= totalRoundCount; i++)
            {
                var RoundEconomyFilter = indexFilters.GetRoundEconomyStateFilter(i);
                var RoundEconomyDocument = serverDataBase.GetRoundEconomyStateDerivObj(RoundEconomyFilter);

                if (RoundEconomyDocument != null)
                {
                    var AwpFilter = indexFilters.GetAWPEquipFilter(i);
                    var AwpDocument = serverDataBase.GetAwpEquipDerivObj(AwpFilter);

                    var CurrentRoundDocument = timerFunction.CheckTimerFunctionForlistofRounds(timestamp, Phase, RoundEconomyDocument.Round, serverDataBase);
                    var PreviousRoundDocument = timerFunction.CheckTimerFunctionForlistofRounds(timestamp, Phase, RoundEconomyDocument.Round - 1, serverDataBase);

                    if (CurrentRoundDocument != null && i == 1)
                    {
                        economyFilters_ScoreBoard.IntializeScoreBoardForEconomyFilters(CurrentRoundDocument);
                    }

                    if (PreviousRoundDocument != null && CurrentRoundDocument != null)
                    {
                        economyFilters_ScoreBoard.CheckEconomyFilters(CurrentRoundDocument, PreviousRoundDocument, RoundEconomyDocument, AwpDocument);
                    }
                }
            }
            return economyFilters_ScoreBoard.killTableModel;
        }
    }
}
