using CityInfo.API.Filters;
using CityInfo.API.FrontEndServices.KillPageServ;
using CityInfo.API.Services.DatabaseServ;
using CityInfo.API.Services.Functions;
using CityInfo.API.ViewModels.BasicStatsPageModels.ScoreBoardModels;
using CSGSI_FrontEnd.FrontEndServices.KillPageServ.ScoreBoard;
using CSGSI_FrontEnd.FrontEndServices.KillPageServ.ScoreBoard.MatchSegmentFilters_ScoreBoard;
//using CSGSI_FrontEnd.FrontEndServices.KillPageServ;

namespace CityInfo.API.Services.KillPage.ScoreBoard
{
    public class ScoreBoardServ
    {
        RoundFunction roundFunction { get; set; }
        TimerFunction timerFunction { get; set; }
        public IndexFilters indexFilters { get; set; }
        public KillTableModel killTableModel { get; set; }
        PopulateScoreBoardServ populateScoreBoardTableServ { get; set; }
        public int totalRoundCount { get; set; }
        EconomyFilters_ScoreBoard economyFilters_ScoreBoard { get; set; }
        public ScoreBoardServ()
        {
            roundFunction = new RoundFunction();
            timerFunction = new TimerFunction();
            indexFilters = new IndexFilters();
            killTableModel = new KillTableModel();
            populateScoreBoardTableServ = new PopulateScoreBoardServ();
        }
        public KillTableModel CheckScoreBoardFilters(ServerDataBase serverDataBase)
        {
            totalRoundCount = serverDataBase.GetTotalRoundCount();
            FullTimeScoreBoardServ fullTimeScoreBoard = new FullTimeScoreBoardServ(totalRoundCount);
            return fullTimeScoreBoard.SetFullTimeScoreBoard(serverDataBase);       
        }
        public KillTableModel CheckScoreBoardFilters(string FirstHalf, string SecondHalf, string FullTime, string OT, string FB, string HB, string Eco, string GunRound, string PartialGunRound, string GRAWP, string total, int RoundX, int RoundY, float timestamp, string Phase, int Round, ServerDataBase serverDataBase)
        {
            totalRoundCount = serverDataBase.GetTotalRoundCount();
            economyFilters_ScoreBoard = new EconomyFilters_ScoreBoard(FB, HB, Eco, GunRound, PartialGunRound, GRAWP, total);
            if (RoundX != 0 && RoundY != 0)
            {
                //this is called when Round and Time Function/Filters are pressed
                if (timestamp != 0 && Phase != "null")
                {
                    //this is called when Round and Time Functions along with Economic Filters are pressed
                    if (economyFilters_ScoreBoard.CheckEconomyFilters() == true)
                    {
                        return roundFunction.CheckRoundFunctionWithTimerFunctionAndFilters(RoundX, RoundY, timestamp, Phase, serverDataBase, economyFilters_ScoreBoard, timerFunction);
                    }
                    return roundFunction.CheckRoundFunction(RoundX, RoundY, timestamp, Phase, serverDataBase);
                }
                else if (economyFilters_ScoreBoard.CheckEconomyFilters() == true)
                {
                    return roundFunction.CheckRoundFunctionWithFilters(RoundX, RoundY, serverDataBase, economyFilters_ScoreBoard);
                }
                //This service is called when only Round Functionis pressed 
                return roundFunction.CheckRoundFunction(RoundX, RoundY, serverDataBase);
            }
            else if (FirstHalf == "on")
            {
                FirstHalfScoreBoardServ firstHalfScoreBoardServ = new FirstHalfScoreBoardServ();
                if (timestamp != 0 && Phase != "null")
                {
                    if (economyFilters_ScoreBoard.CheckEconomyFilters() == true)
                    {
                        return firstHalfScoreBoardServ.SetFirstHalfScoreBoard(timestamp, Phase, serverDataBase, economyFilters_ScoreBoard, timerFunction);
                    }
                }
                else if (economyFilters_ScoreBoard.CheckEconomyFilters() == true)
                {
                    return firstHalfScoreBoardServ.SetFirstHalfScoreBoard(serverDataBase, economyFilters_ScoreBoard);
                }
                return firstHalfScoreBoardServ.SetFirstHalfScoreBoard(serverDataBase);
            }
            else if (SecondHalf == "on")
            {
                SecondHalfScoreBoardServ secondHalfScoreBoardServ = new SecondHalfScoreBoardServ(totalRoundCount);
                if (timestamp != 0 && Phase != "null")
                {
                    if (economyFilters_ScoreBoard.CheckEconomyFilters() == true)
                    {
                        return secondHalfScoreBoardServ.SetSecondHalfScoreBoard(timestamp, Phase, serverDataBase, economyFilters_ScoreBoard, timerFunction);
                    }
                }
                else if (economyFilters_ScoreBoard.CheckEconomyFilters() == true)
                {
                    return secondHalfScoreBoardServ.SetSecondHalfScoreBoard(serverDataBase, economyFilters_ScoreBoard);
                }
                return secondHalfScoreBoardServ.SetSecondHalfScoreBoard(serverDataBase);
            }
            else if (OT == "on")
            {
                OverTimeScoreBoardServ overTimeScoreBoardServ = new OverTimeScoreBoardServ(totalRoundCount);
                if (timestamp != 0 && Phase != "null")
                {
                    if (economyFilters_ScoreBoard.CheckEconomyFilters() == true)
                    {
                        return overTimeScoreBoardServ.SetOverTimeScoreBoard(timestamp, Phase, serverDataBase, economyFilters_ScoreBoard, timerFunction);
                    }
                }
                else if (economyFilters_ScoreBoard.CheckEconomyFilters() == true)
                {
                    return overTimeScoreBoardServ.SetOverTimeScoreBoard(serverDataBase, economyFilters_ScoreBoard);
                }
                return overTimeScoreBoardServ.SetOverTimeScoreBoard(serverDataBase);
            }
            else if (FullTime == "on")
            {
                FullTimeScoreBoardServ fullTimeScoreBoardServ = new FullTimeScoreBoardServ(totalRoundCount);
                if (timestamp != 0 && Phase != "null")
                {
                    if (economyFilters_ScoreBoard.CheckEconomyFilters() == true)
                    {
                        return fullTimeScoreBoardServ.SetFullTimeScoreBoard(timestamp, Phase, serverDataBase, economyFilters_ScoreBoard, timerFunction);
                    }
                }
                else if (economyFilters_ScoreBoard.CheckEconomyFilters() == true)
                {
                    return fullTimeScoreBoardServ.SetFullTimeScoreBoard(serverDataBase, economyFilters_ScoreBoard);
                }
                return fullTimeScoreBoardServ.SetFullTimeScoreBoard(serverDataBase);
            }
            else if (timestamp != 0 && Phase != "null" && Round != 0)
            {
                if (economyFilters_ScoreBoard.CheckEconomyFilters() == true)
                {
                    return timerFunction.CheckTimerFunction(timestamp, Phase, Round, economyFilters_ScoreBoard, serverDataBase);
                }
                return timerFunction.CheckTimerFunction(timestamp, Phase, Round, serverDataBase);
            }
            else if (economyFilters_ScoreBoard.CheckEconomyFilters() == true)
            {
                FullTimeScoreBoardServ fullTimeScoreBoardServ = new FullTimeScoreBoardServ(totalRoundCount);
                return fullTimeScoreBoardServ.SetFullTimeScoreBoard(serverDataBase, economyFilters_ScoreBoard);

            }


            FullTimeScoreBoardServ fullTimeScoreBoard = new FullTimeScoreBoardServ(totalRoundCount);
            return fullTimeScoreBoard.SetFullTimeScoreBoard(serverDataBase);
        }
    }
}
