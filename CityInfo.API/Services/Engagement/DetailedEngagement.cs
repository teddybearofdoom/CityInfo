namespace CityInfo.API.Services.Engagement
{
    public class DetailedEngagement
    {
        public DetailEngagementViewModel detailEngagements { get; set; }
        public DetailedEngagement()
        {
            detailEngagements = new DetailEngagementViewModel();
        }
        public void Engagment(ParserDatabaseServ dataBase)
        {
            IndexFilters indexFilters = new IndexFilters();
            CalcEngagmentServ calcEngagmentServ = new CalcEngagmentServ();
            var engagementObjList = calcEngagmentServ.CalcEngagement(dataBase, dataBase.GetTotalRoundCount() - 1);

            for (int i = 0; i < dataBase.GetTotalRoundCount(); i++)
            {

                var currentRoundEngagementList = calcEngagmentServ.CalcEngagement(dataBase, i);
                List<DetailEngagement> tempdetailEngagements = new List<DetailEngagement>();
                ListofDetailEngagement listofDetailEngagement = new ListofDetailEngagement();

                foreach (var engagement in currentRoundEngagementList)
                {
                    DetailEngagement detailEngagement = new DetailEngagement();
                    if (engagement.timerElapsed == false)
                    {
                        detailEngagement.ctPlayers = Int32.Parse(BreakEngagmentServ.returnCTPlayers(engagement));
                        detailEngagement.tPlayers = Int32.Parse(BreakEngagmentServ.returnTPlayers(engagement));
                        detailEngagement.time = engagement.startTime;
                        detailEngagement.phase = engagement.startPhase;
                    }
                    else if (engagement.timerElapsed == true)
                    {
                        detailEngagement.ctPlayers = Int32.Parse(BreakEngagmentServ.returnCTPlayers(engagement));
                        detailEngagement.tPlayers = Int32.Parse(BreakEngagmentServ.returnTPlayers(engagement));
                        detailEngagement.time = engagement.endTime;
                        detailEngagement.phase = engagement.endPhase;
                    }
                    tempdetailEngagements.Add(detailEngagement);
                }
                listofDetailEngagement.round = i;
                listofDetailEngagement.detailEngagements = tempdetailEngagements;
                detailEngagements.Engagements.Add(listofDetailEngagement);
            }
        }


    }
}
