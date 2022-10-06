using CSGSI_FrontEnd.Filters.KillPageFilters;
using CSGSI_FrontEnd.FrontEndServices.DataBaseServ;
using CSGSI_FrontEnd.ViewModels.Engagment_Models;

namespace CSGSI_FrontEnd.FrontEndServices.EngagmentServ
{
    public static class FirstHalfEngagementServ
    {
        public static void Engagement(ServerDataBase dataBase,Engagement engagementCT, Engagement engagementT)
        {
            IndexFilters indexFilters = new IndexFilters();
            CheckEngagementWinnerServ checkEngagement = new CheckEngagementWinnerServ();

            for (int i = 0; i < dataBase.GetTotalRoundCount(); i++)
            {
                var temp = dataBase.GetEngagmentDerivObjList(indexFilters.GetEngagmentFilter(i));

                var roundCondfilter = indexFilters.GetRoundCondFilter(i);
                var roundCondObj = dataBase.GetRoundCondDerivObj(roundCondfilter);

                int index = 0;
                foreach (var engagementtemp in temp)
                {
                    int CTplayers = Int32.Parse(BreakEngagmentServ.returnCTPlayers(engagementtemp));
                    int Tplayers = Int32.Parse(BreakEngagmentServ.returnTPlayers(engagementtemp));

                    if (CTplayers == engagementCT.ctPlayers && Tplayers == engagementT.tPlayers)
                    {
                        if (index == 0)
                        {
                            checkEngagement.Winner(engagementCT.ctPlayers, engagementCT.tPlayers, 5, 5);
                        }
                        else
                        {
                            int previousCTplayers = Int32.Parse(BreakEngagmentServ.returnCTPlayers(temp[index - 1]));
                            int previousTplayers = Int32.Parse(BreakEngagmentServ.returnTPlayers(temp[index - 1]));

                            checkEngagement.Winner(engagementCT.ctPlayers, engagementCT.tPlayers, previousCTplayers, previousTplayers);
                        }
                    }
                    index++;
                }
            }
        }
    }
}
