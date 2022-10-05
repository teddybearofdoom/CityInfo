using CityInfo.API.Filters;
using CityInfo.API.FrontEndServices.KillPageServ;
using CityInfo.API.Models.BusinessObjects.DerivBO;
using CityInfo.API.Services.DatabaseServ;
using CityInfo.API.Services.KillPage.ScoreBoard;
using CityInfo.API.ViewModels.BasicStatsPageModels.ScoreBoardModels;

namespace CityInfo.API.Services.Functions
{
    public class TimerFunction
    {
        public IndexFilters indexFilters { get; set; }
        public List<Deriv_PlayerTeam_BO> deriv_PlayerTeam_BOs { get; set; }
        public TimerFunction()
        {
            deriv_PlayerTeam_BOs = new List<Deriv_PlayerTeam_BO>();
            indexFilters = new IndexFilters();
        }
        public KillTableModel CheckTimerFunction(float timestamp, string Phase, int Round, ServerDataBase serverDataBase)
        {
            PopulateScoreBoardServ populateScoreBoardServ = new PopulateScoreBoardServ();

            if (Round == 0)
            {
                Round++;
            }
            var filter = indexFilters.GetPlayerTeamFilter(timestamp, Phase);
            var document = serverDataBase.GetPlayerTeamDerivObj(filter, Round);

            var previousRoundDocument = serverDataBase.GetPlayerTeamDerivObj(Round - 1);

            if (document != null)
            {
                populateScoreBoardServ.IntializeScoreBoard(document);
                populateScoreBoardServ.PopulateScoreBoard(document, previousRoundDocument);
            }
            return populateScoreBoardServ.killTableModel;
        }
        public Deriv_PlayerTeam_BO CheckTimerFunctionForlistofRounds(float timestamp, string Phase, int Round, ServerDataBase serverDataBase)
        {
            var filter = indexFilters.GetPlayerTeamFilter(timestamp, Phase);
            var document = serverDataBase.GetPlayerTeamDerivObj(filter, Round);

            return document;
        }
        public KillTableModel CheckTimerFunction(float timestamp, string Phase, int Round, EconomyFilters_ScoreBoard economyFilters_ScoreBoard, ServerDataBase serverDataBase)
        {
            if (economyFilters_ScoreBoard.CheckEconomyFilters() == true)
            {
                if (Round == 0)
                {
                    Round++;
                }
                var RoundEconomyFilter = indexFilters.GetRoundEconomyStateFilter(Round);
                var RoundEconomyDocument = serverDataBase.GetRoundEconomyStateDerivObj(RoundEconomyFilter);

                if (RoundEconomyDocument != null)
                {
                    var AwpFilter = indexFilters.GetAWPEquipFilter(RoundEconomyDocument.Round);
                    var AwpDocument = serverDataBase.GetAwpEquipDerivObj(AwpFilter);

                    var document = CheckTimerFunctionForlistofRounds(timestamp, Phase, RoundEconomyDocument.Round, serverDataBase);
                    var previousRoundDocument = CheckTimerFunctionForlistofRounds(timestamp, Phase, RoundEconomyDocument.Round - 1, serverDataBase);

                    if (document != null)
                    {
                        economyFilters_ScoreBoard.IntializeScoreBoardForEconomyFilters(document);
                        economyFilters_ScoreBoard.CheckEconomyFilters(document, previousRoundDocument, RoundEconomyDocument, AwpDocument);
                    }
                }
            }
            return economyFilters_ScoreBoard.killTableModel;
        }
    }
}
