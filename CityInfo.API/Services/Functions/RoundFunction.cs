using CityInfo.API.Filters;
using CityInfo.API.FrontEndServices.KillPageServ;
using CityInfo.API.Models.BusinessObjects.DerivBO;
using CityInfo.API.Services.DatabaseServ;
using CityInfo.API.Services.KillPage.ScoreBoard;
using CityInfo.API.ViewModels.BasicStatsPageModels.ScoreBoardModels;

namespace CityInfo.API.Services.Functions
{
    public class RoundFunction
    {
        public IndexFilters indexFilters { get; set; }

        public RoundFunction()
        {
            indexFilters = new IndexFilters();
        }
        //Round Function
        public KillTableModel CheckRoundFunction(int RoundX, int RoundY, ServerDataBase serverDataBase)
        {
            //Service for Populating ScoreBoard for a list of Rounds
            PopulateScoreBoardServ populateScoreBoardTableServ = new PopulateScoreBoardServ();

            List<Deriv_PlayerTeam_BO> ListofRounds = new List<Deriv_PlayerTeam_BO>();
            for (int i = RoundX; i <= RoundY; i++)
            {
                var deriv_PlayerTeam_BO = serverDataBase.GetPlayerTeamDerivObj(i);
                ListofRounds.Add(deriv_PlayerTeam_BO);
            }
            populateScoreBoardTableServ.PopulateScoreBoard(ListofRounds);

            return populateScoreBoardTableServ.killTableModel;
        }
        //Round and Timer Function
        public KillTableModel CheckRoundFunction(int RoundX, int RoundY, float timestamp, string Phase, ServerDataBase serverDataBase)
        {
            PopulateScoreBoardServ populateScoreBoardTableServ = new PopulateScoreBoardServ();

            List<Deriv_PlayerTeam_BO> ListofRounds = new List<Deriv_PlayerTeam_BO>();

            var filter = indexFilters.GetPlayerTeamFilter(timestamp, Phase);


            for (int i = RoundX; i <= RoundY; i++)
            {
                var document = serverDataBase.GetPlayerTeamDerivObj(filter, i);

                ListofRounds.Add(document);
            }
            populateScoreBoardTableServ.PopulateScoreBoard(ListofRounds);

            return populateScoreBoardTableServ.killTableModel;
        }
        public KillTableModel CheckRoundFunctionWithFilters(int RoundX, int RoundY, ServerDataBase serverDataBase, EconomyFilters_ScoreBoard economyFilters_ScoreBoard)
        {
            for (int i = RoundX; i < RoundY; i++)
            {
                var RoundEconomyFilter = indexFilters.GetRoundEconomyStateFilter(i);
                var RoundEconomyDocument = serverDataBase.GetRoundEconomyStateDerivObj(RoundEconomyFilter);

                if (RoundEconomyDocument != null)
                {
                    var AwpFilter = indexFilters.GetAWPEquipFilter(i);
                    var AwpDocument = serverDataBase.GetAwpEquipDerivObj(AwpFilter);

                    var CurrentRoundDocument = serverDataBase.GetPlayerTeamDerivObj(RoundEconomyDocument.Round);

                    if (CurrentRoundDocument != null && i == RoundX)
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
        public KillTableModel CheckRoundFunctionWithTimerFunctionAndFilters(int RoundX, int RoundY, float timestamp, string Phase, ServerDataBase serverDataBase, EconomyFilters_ScoreBoard economyFilters_ScoreBoard, TimerFunction timerFunction)
        {
            for (int i = RoundX; i < RoundY; i++)
            {
                var RoundEconomyFilter = indexFilters.GetRoundEconomyStateFilter(i);
                var RoundEconomyDocument = serverDataBase.GetRoundEconomyStateDerivObj(RoundEconomyFilter);

                if (RoundEconomyDocument != null)
                {
                    var AwpFilter = indexFilters.GetAWPEquipFilter(RoundEconomyDocument.Round);
                    var AwpDocument = serverDataBase.GetAwpEquipDerivObj(AwpFilter);

                    var CurrentRoundDocument = timerFunction.CheckTimerFunctionForlistofRounds(timestamp, Phase, RoundEconomyDocument.Round, serverDataBase);
                    var PreviousRoundDocument = timerFunction.CheckTimerFunctionForlistofRounds(timestamp, Phase, RoundEconomyDocument.Round - 1, serverDataBase);

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
