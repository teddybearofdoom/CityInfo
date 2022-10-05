using CityInfo.API.Filters;
using CityInfo.API.FrontEndServices.KillPageServ;
using CityInfo.API.Models.BusinessObjects.DerivBO;
using CityInfo.API.Services.DatabaseServ;
using CityInfo.API.Services.Functions;
using CityInfo.API.Services.KillPage.ScoreBoard;
using CityInfo.API.ViewModels.BasicStatsPageModels.ScoreBoardModels;

using CSGSI_FrontEnd.ViewModels.BasicStatsPageModels;

namespace CSGSI_FrontEnd.FrontEndServices.KillPageServ.ScoreBoard.MatchSegmentFilters_ScoreBoard
{
    public class SecondHalfScoreBoardServ
    {
        public IndexFilters indexFilters { get; set; }
        public int SecondHalfRoundCount { get; set; }
        public SecondHalfScoreBoardServ(int totalRoundCount)
        {
            indexFilters = new IndexFilters();
            if (totalRoundCount > 30)
            {
                SecondHalfRoundCount = 30;
            }
            SecondHalfRoundCount = totalRoundCount;
        }
        public KillTableModel SetSecondHalfScoreBoard(ServerDataBase serverDataBase)
        {
            List<Deriv_PlayerTeam_BO> ListofRounds = new List<Deriv_PlayerTeam_BO>();
            PopulateScoreBoardServ populateScoreBoardServ = new PopulateScoreBoardServ();

            for (int i = 16; i <= SecondHalfRoundCount; i++)
            {
                var CurrentRoundDocument = serverDataBase.GetPlayerTeamDerivObj(i);
                ListofRounds.Add(CurrentRoundDocument);
            }
            populateScoreBoardServ.PopulateScoreBoard(ListofRounds);
            return populateScoreBoardServ.killTableModel;
        }
        public KillTableModel SetSecondHalfScoreBoard(ServerDataBase serverDataBase, EconomyFilters_ScoreBoard economyFilters_ScoreBoard)
        {
            for (int i = 16; i <= SecondHalfRoundCount; i++)
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
        public KillTableModel SetSecondHalfScoreBoard(float timestamp, string Phase, ServerDataBase serverDataBase, EconomyFilters_ScoreBoard economyFilters_ScoreBoard, TimerFunction timerFunction)
        {
            for (int i = 16; i <= SecondHalfRoundCount; i++)
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
