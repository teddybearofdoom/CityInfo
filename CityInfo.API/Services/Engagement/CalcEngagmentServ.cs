using CityInfo.API.Filters;
using CityInfo.API.Services.DatabaseServ;
using CSGO_GSI_Backend.Models.BusinessObjects.DerivBO;
using CSGSI_FrontEnd.ViewModels.Engagment_Models;
using System.Reflection;
namespace CSGSI_FrontEnd.FrontEndServices.EngagmentServ
{
    public class CalcEngagmentServ
    {
        public Engagement engagementCT { get; set; }
        public Engagement engagementT { get; set; }
        public CalcEngagmentServ()
        {
            engagementCT = new Engagement();
            engagementT = new Engagement();
        }
        public void EngagementWithFilters(ServerDataBase dataBase, string ctPlayers, string tPlayers)
        {
            IndexFilters indexFilters = new IndexFilters();

            CheckEngagementWinnerServ checkEngagementWinnerServ = new CheckEngagementWinnerServ();

            int tempEngagementStartCTPlayers = Int32.Parse(ctPlayers);
            int tempEngagementStartTPlayers = Int32.Parse(tPlayers);




            var derivObj = dataBase.GetPlayerTeamDerivObj(1);
            engagementCT.name = derivObj.CTplayers[0].Clan;
            engagementCT.ctPlayers = tempEngagementStartCTPlayers;
            engagementCT.tPlayers = tempEngagementStartTPlayers;

            engagementT.name = derivObj.Tplayers[0].Clan;
            engagementT.ctPlayers = tempEngagementStartCTPlayers;
            engagementT.tPlayers = tempEngagementStartTPlayers;

            for (int i = 0; i < dataBase.GetTotalRoundCount(); i++)
            {
                if (i == 15)
                {
                    Engagement engagement = engagementCT;
                    engagementCT = engagementT;
                    engagementT = engagement;

                }

                var currentRoundEngagementList = dataBase.GetEngagmentDerivObjList(indexFilters.GetEngagmentFilter(i));
                var roundCondfilter = indexFilters.GetRoundCondFilter(i);
                var roundCondObj = dataBase.GetRoundCondDerivObj(roundCondfilter);

                int index = 0;
                foreach (var engagement in currentRoundEngagementList)
                {
                    
                    int startCTPlayers = Int32.Parse(BreakEngagmentServ.returnCTPlayers(engagement));
                    int startTPlayers = Int32.Parse(BreakEngagmentServ.returnTPlayers(engagement));
                    if (startCTPlayers == tempEngagementStartCTPlayers &&
                        startTPlayers == tempEngagementStartTPlayers &&
                        engagement.timerElapsed == false)
                    {
                        if (currentRoundEngagementList.ElementAtOrDefault(index + 1) != null && currentRoundEngagementList[index + 1].timerElapsed == true)
                        {
                            int endCTPlayers = Int32.Parse(BreakEngagmentServ.returnCTPlayers(currentRoundEngagementList[index + 1]));
                            int endTPlayers = Int32.Parse(BreakEngagmentServ.returnTPlayers(currentRoundEngagementList[index + 1]));
                            if (checkEngagementWinnerServ.Winner(startCTPlayers, startTPlayers, endCTPlayers, endTPlayers) == "CT")
                            {
                                if (endCTPlayers == endTPlayers)
                                {
                                    engagementCT.equalizationLive++;
                                }
                                engagementCT.sucessLive++;                              
                            }
                            engagementCT.totalLive++;
                        }
                        if (roundCondObj != null)
                        {
                            if (checkEngagementWinnerServ.RoundWinner(roundCondObj) == "CT")
                            {
                                engagementCT.winLive++;
                            }
                        }
                    }
                    if (startCTPlayers == tempEngagementStartTPlayers && startTPlayers == tempEngagementStartCTPlayers &&
                        engagement.timerElapsed == false)
                    {
                        if (currentRoundEngagementList.ElementAtOrDefault(index + 1) != null && currentRoundEngagementList[index + 1].timerElapsed == true)
                        {
                            int endCTPlayers = Int32.Parse(BreakEngagmentServ.returnCTPlayers(currentRoundEngagementList[index + 1]));
                            int endTPlayers = Int32.Parse(BreakEngagmentServ.returnTPlayers(currentRoundEngagementList[index + 1]));
                            if (checkEngagementWinnerServ.Winner(startCTPlayers, startTPlayers, endCTPlayers, endTPlayers) == "T")
                            {
                                if (endCTPlayers == endTPlayers)
                                {
                                    if (startTPlayers == startCTPlayers)
                                    {
                                        engagementT.engagementEvenLive++;
                                    }
                                    engagementT.equalizationLive++;
                                }
                                engagementT.sucessLive++;                           
                            }
                            engagementT.totalLive++;
                        }
                        if (roundCondObj != null)
                        {
                            if (checkEngagementWinnerServ.RoundWinner(roundCondObj) == "T")
                            {
                                engagementT.winLive++;
                            }
                        }
                    }
                    //if ()
                    //{
                    //if (currentRoundEngagementList.ElementAtOrDefault(index + 1) != null && currentRoundEngagementList[index + 1].timerElapsed == true)
                    //{
                    //    int endCTPlayers = Int32.Parse(BreakEngagmentServ.returnCTPlayers(currentRoundEngagementList[index + 1]));
                    //    int endTPlayers = Int32.Parse(BreakEngagmentServ.returnTPlayers(currentRoundEngagementList[index + 1]));
                    //    checkEngagementWinnerServ.Winner(engagementCT, engagementT, startCTPlayers, startTPlayers, endCTPlayers, endTPlayers, roundCondObj);
                    //}
                    //}
                    index++;
                }
            }
        }
        public void Engagment(ServerDataBase dataBase)
        {
            IndexFilters indexFilters = new IndexFilters();

            var engagementObjList = dataBase.GetEngagmentDerivObjList(indexFilters.GetEngagmentFilter(dataBase.GetTotalRoundCount() - 1));
            CheckEngagementWinnerServ checkEngagementWinnerServ = new CheckEngagementWinnerServ();

            int tempEngagementStartCTPlayers = 0;
            int tempEngagementStartTPlayers = 0;


            if (engagementObjList.LastOrDefault().timerElapsed == true)
            {
                var engagementStartObj = engagementObjList[engagementObjList.Count - 2];
                tempEngagementStartCTPlayers = Int32.Parse(BreakEngagmentServ.returnCTPlayers(engagementStartObj));
                tempEngagementStartTPlayers = Int32.Parse(BreakEngagmentServ.returnTPlayers(engagementStartObj));

            }
            else
            {
                tempEngagementStartCTPlayers = Int32.Parse(BreakEngagmentServ.returnCTPlayers(engagementObjList.LastOrDefault()));
                tempEngagementStartTPlayers = Int32.Parse(BreakEngagmentServ.returnTPlayers(engagementObjList.LastOrDefault()));
            }

            var derivObj = dataBase.GetPlayerTeamDerivObj(1);
            engagementCT.name = derivObj.CTplayers[0].Clan;
            engagementCT.ctPlayers = tempEngagementStartCTPlayers;
            engagementCT.tPlayers = tempEngagementStartTPlayers;

            engagementT.name = derivObj.Tplayers[0].Clan;
            engagementT.ctPlayers = tempEngagementStartCTPlayers;
            engagementT.tPlayers = tempEngagementStartTPlayers;

            for (int i = 0; i < dataBase.GetTotalRoundCount(); i++)
            {
                if (i == 15)
                {
                    Engagement engagement = engagementCT;
                    engagementCT = engagementT;
                    engagementT = engagement;

                }

                var currentRoundEngagementList = dataBase.GetEngagmentDerivObjList(indexFilters.GetEngagmentFilter(i));
                var roundCondfilter = indexFilters.GetRoundCondFilter(i);
                var roundCondObj = dataBase.GetRoundCondDerivObj(roundCondfilter);

                int index = 0;
                foreach (var engagement in currentRoundEngagementList)
                {
                    int startCTPlayers = Int32.Parse(BreakEngagmentServ.returnCTPlayers(engagement));
                    int startTPlayers = Int32.Parse(BreakEngagmentServ.returnTPlayers(engagement));
                    if (startCTPlayers == tempEngagementStartCTPlayers &&
                        startTPlayers == tempEngagementStartTPlayers &&
                        engagement.timerElapsed == false)
                    {
                        if (currentRoundEngagementList.ElementAtOrDefault(index + 1) != null && currentRoundEngagementList[index + 1].timerElapsed == true)
                        {
                            int endCTPlayers = Int32.Parse(BreakEngagmentServ.returnCTPlayers(currentRoundEngagementList[index + 1]));
                            int endTPlayers = Int32.Parse(BreakEngagmentServ.returnTPlayers(currentRoundEngagementList[index + 1]));
                            if (checkEngagementWinnerServ.Winner(startCTPlayers, startTPlayers, endCTPlayers, endTPlayers) == "CT")
                            {
                                if (endCTPlayers == endTPlayers)
                                {
                                    engagementCT.equalizationLive++;
                                }
                                engagementCT.sucessLive++;
                            }
                            engagementCT.totalLive++;
                        }
                        if (roundCondObj != null)
                        {
                            if (checkEngagementWinnerServ.RoundWinner(roundCondObj) == "CT")
                            {
                                engagementCT.winLive++;
                            }
                        }
                    }
                    if (startCTPlayers == tempEngagementStartTPlayers && startTPlayers == tempEngagementStartCTPlayers &&
                        engagement.timerElapsed == false)
                    {
                        if (currentRoundEngagementList.ElementAtOrDefault(index + 1) != null && currentRoundEngagementList[index + 1].timerElapsed == true)
                        {
                            int endCTPlayers = Int32.Parse(BreakEngagmentServ.returnCTPlayers(currentRoundEngagementList[index + 1]));
                            int endTPlayers = Int32.Parse(BreakEngagmentServ.returnTPlayers(currentRoundEngagementList[index + 1]));
                            if (checkEngagementWinnerServ.Winner(startCTPlayers, startTPlayers, endCTPlayers, endTPlayers) == "T")
                            {

                                if (endCTPlayers == endTPlayers)
                                {
                                    if (startTPlayers == startCTPlayers)
                                    {
                                        engagementT.engagementEvenLive++;
                                    }
                                    engagementT.equalizationLive++;
                                }
                                engagementT.sucessLive++;

                            }
                            engagementT.totalLive++;
                        }
                        if (roundCondObj != null)
                        {
                            if (checkEngagementWinnerServ.RoundWinner(roundCondObj) == "T")
                            {
                                engagementT.winLive++;
                            }
                        }
                    }
                    //if ()
                    //{
                    //if (currentRoundEngagementList.ElementAtOrDefault(index + 1) != null && currentRoundEngagementList[index + 1].timerElapsed == true)
                    //{
                    //    int endCTPlayers = Int32.Parse(BreakEngagmentServ.returnCTPlayers(currentRoundEngagementList[index + 1]));
                    //    int endTPlayers = Int32.Parse(BreakEngagmentServ.returnTPlayers(currentRoundEngagementList[index + 1]));
                    //    checkEngagementWinnerServ.Winner(engagementCT, engagementT, startCTPlayers, startTPlayers, endCTPlayers, endTPlayers, roundCondObj);
                    //}
                    //}
                    index++;
                }
            }

            // CheckEngagementWinner(engagementCT.ctPlayers, engagementCT.tPlayers, previousEngagementCTplayers, previousEngagementTplayers, roundCond);
            //if (dataBase.GetTotalRoundCount() <= 15)
            //{
            //    FirstHalfEngagementServ.Engagement(dataBase, engagementCT, engagementT);
            //}
            //else if(dataBase.GetTotalRoundCount() > 15 && dataBase.GetTotalRoundCount() <30)
            //{
            //    FullTimeEngagementServ.Engagement(dataBase, engagementCT, engagementT);
            //}
            //else if (dataBase.GetTotalRoundCount() >30)
            //{
            //    OverTimeEngagementServ.Engagement(dataBase, engagementCT, engagementT);
            //}

        }
    }
}
