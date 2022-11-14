using CityInfo.API.Filters;
using CityInfo.API.Services.DatabaseServ;
using CSGO_GSI_Backend.Models.BusinessObjects.DerivBO;
using CSGSI_FrontEnd.HistoricalDatabaseModels.EngagementModels;
using CSGSI_FrontEnd.Utility;
using CSGSI_FrontEnd.ViewModels.Engagment_Models;
using System.Reflection;
namespace CSGSI_FrontEnd.FrontEndServices.EngagmentServ
{
    public class CalcEngagmentServ
    {
        public Engagement engagementCT { get; set; }
        public Engagement engagementT { get; set; }
        List<PlayersInfo> PlayersAlive { get; set; }
        List<PlayersInfo> TotalPlayers { get; set; }
        List<PlayersInfo> PlayersDead { get; set; }
        public CalcEngagmentServ()
        {
            engagementCT = new Engagement();
            engagementT = new Engagement();
            PlayersAlive = new List<PlayersInfo>();
            PlayersDead = new List<PlayersInfo>();
            TotalPlayers = new List<PlayersInfo>();
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
        public List<Deriv_Engagement_BO> CalcEngagement(ServerDataBase dataBase, int currentRound)
        {
            IndexFilters indexFilters = new IndexFilters();
            List<Deriv_Engagement_BO> currentRoundEngagementList = new List<Deriv_Engagement_BO>();
            //Getting Current Round Kill List
            var killFilter = indexFilters.GetKillBOFilter(currentRound);
            var currentRoundKillList = dataBase.GetDeriv_Kill_BO(killFilter);

            var playersDerivObj = dataBase.GetPlayerTeamDerivObj(currentRound + 1);

            if (playersDerivObj != null)
            {
                foreach (var player in playersDerivObj.CTplayers)
                {
                    PlayersInfo tempplayer = new PlayersInfo();
                    tempplayer.name = player.Name;
                    PlayersAlive.Add(tempplayer);
                    TotalPlayers.Add(tempplayer);
                }
                foreach (var player in playersDerivObj.Tplayers)
                {
                    PlayersInfo tempplayer = new PlayersInfo();
                    tempplayer.name = player.Name;
                    PlayersAlive.Add(tempplayer);
                    TotalPlayers.Add(tempplayer);
                }
            }
            //Setting Default players count to 5
            int CT_alive = 5;
            int T_alive = 5;
            //Setting Default Engagement Flag to false
            bool engagementOnGoing = false;
            int index = 0;

            List<Deriv_Kill_BO> EngagementKillList = new List<Deriv_Kill_BO>();
            foreach (var kill in currentRoundKillList)
            {
                //trigger for engagement start
                foreach (var player in PlayersAlive)
                {
                    if (kill.killing_Player_Name == player.name)
                    {
                        player.Kills.Add(kill);
                    }
                }


                if (engagementOnGoing == false)
                {
                    Deriv_Engagement_BO deriv_Engagement_BO = new Deriv_Engagement_BO();
                    EngagementKillList.Add(kill);

                    foreach (var pAlive in PlayersAlive)
                    {
                        PlayersInfo playersInfo = new PlayersInfo();
                        playersInfo = pAlive;
                        deriv_Engagement_BO.playersalive.Add(playersInfo);
                    }
                    foreach (var pDead in PlayersDead)
                    {
                        PlayersInfo playersInfo = new PlayersInfo();
                        playersInfo = pDead;
                        deriv_Engagement_BO.playersdead.Add(playersInfo);
                    }
                    foreach (var temp in EngagementKillList)
                    {
                        deriv_Engagement_BO.KillsInEngagements.Add(temp);
                    }
                    deriv_Engagement_BO.Initiationkill = kill;
                    SetEnagementDerivBO.setEngagementStatistics(deriv_Engagement_BO, CT_alive, T_alive, kill.time, kill.phase, false, currentRound);
                    currentRoundEngagementList.Add(deriv_Engagement_BO);
                    Console.WriteLine("engagementstart");
                    engagementOnGoing = true;
                    if (kill.victim_Player_Team == "CT")
                    {
                        CT_alive--;
                    }
                    else if (kill.victim_Player_Team == "T")
                    {
                        T_alive--;
                    }
                }
                //trigger for engagement end
                else if (engagementOnGoing == true)
                {
                    if (Util.GetTimeDiff(currentRoundKillList[index - 1].phase, currentRoundKillList[index - 1].time, kill.phase, kill.time, currentRound + 1, dataBase) > 5)
                    {
                        Deriv_Engagement_BO deriv_Engagement_BO = new Deriv_Engagement_BO();
                        EngagementKillList.Add(kill);
                        foreach (var temp in EngagementKillList)
                        {
                            deriv_Engagement_BO.KillsInEngagements.Add(temp);
                        }
                        SetEnagementDerivBO.setEngagementStatistics(deriv_Engagement_BO, CT_alive, T_alive, currentRoundKillList[index - 1].time, currentRoundKillList[index - 1].phase, true, currentRound);
                        foreach (var pAlive in PlayersAlive)
                        {
                            PlayersInfo playersInfo = new PlayersInfo();
                            playersInfo = pAlive;
                            deriv_Engagement_BO.playersalive.Add(playersInfo);
                        }
                        foreach (var pDead in PlayersDead)
                        {
                            PlayersInfo playersInfo = new PlayersInfo();
                            playersInfo = pDead;
                            deriv_Engagement_BO.playersdead.Add(playersInfo);
                        }
                        deriv_Engagement_BO.Initiationkill = kill;
                        currentRoundEngagementList.Add(deriv_Engagement_BO);

                        Deriv_Engagement_BO deriv_Engagement_BO_startingdocument = new Deriv_Engagement_BO();
                        foreach (var temp in EngagementKillList)
                        {
                            deriv_Engagement_BO_startingdocument.KillsInEngagements.Add(temp);
                        }

                        SetEnagementDerivBO.setEngagementStatistics(deriv_Engagement_BO_startingdocument, CT_alive, T_alive, kill.time, kill.phase, false, currentRound);
                        foreach (var pAlive in PlayersAlive)
                        {
                            PlayersInfo playersInfo = new PlayersInfo();
                            playersInfo = pAlive;
                            deriv_Engagement_BO_startingdocument.playersalive.Add(playersInfo);
                        }
                        foreach (var pDead in PlayersDead)
                        {
                            PlayersInfo playersInfo = new PlayersInfo();
                            playersInfo = pDead;
                            deriv_Engagement_BO_startingdocument.playersdead.Add(playersInfo);
                        }
                        deriv_Engagement_BO_startingdocument.Initiationkill = kill;
                        currentRoundEngagementList.Add(deriv_Engagement_BO_startingdocument);

                        if (kill.victim_Player_Team == "CT")
                        {
                            CT_alive--;
                        }
                        else if (kill.victim_Player_Team == "T")
                        {
                            T_alive--;
                        }
                        EngagementKillList = new List<Deriv_Kill_BO>();
                    }
                    else
                    {
                        EngagementKillList.Add(kill);
                        if (kill.victim_Player_Team == "CT")
                        {
                            CT_alive--;
                        }
                        else if (kill.victim_Player_Team == "T")
                        {
                            T_alive--;
                        }
                    }
                    PlayersInfo tempplayer = new PlayersInfo();
                    foreach (var player in TotalPlayers)
                    {
                        if (player.name == kill.victim_Player_Name)
                        {
                            tempplayer = player;
                        }
                    }
                    PlayersDead.Add(tempplayer);
                    PlayersAlive.Remove(tempplayer);
                }
                index++;
            }

            if (currentRoundEngagementList.LastOrDefault().timerElapsed == false)
            {
                Deriv_Engagement_BO deriv_Engagement_BO = new Deriv_Engagement_BO();
                SetEnagementDerivBO.setEngagementStatistics(deriv_Engagement_BO, CT_alive, T_alive, currentRoundKillList.LastOrDefault().time, currentRoundKillList.LastOrDefault().phase, true, currentRound);
                deriv_Engagement_BO.Initiationkill = currentRoundKillList.LastOrDefault();
                foreach (var pAlive in PlayersAlive)
                {
                    PlayersInfo playersInfo = new PlayersInfo();
                    playersInfo = pAlive;
                    deriv_Engagement_BO.playersalive.Add(playersInfo);
                }
                foreach (var pDead in PlayersDead)
                {
                    PlayersInfo playersInfo = new PlayersInfo();
                    playersInfo = pDead;
                    deriv_Engagement_BO.playersdead.Add(playersInfo);
                }
                currentRoundEngagementList.Add(deriv_Engagement_BO);
            }
            return currentRoundEngagementList;
        }

    }
}
