
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using CityInfo.API.Services.DatabaseServ;
using CityInfo.API.Filters;

namespace CSGSI_FrontEnd.Utility
{
    public static class Util
    {
        public static float GetTimeDiff(string startPhase, float startPhaseTime, string endPhase, float endPhaseTime, int Round, ServerDataBase serverDataBase)
        {
            IndexFilters indexFilters = new IndexFilters();
            if (startPhase == endPhase)
            {
                return startPhaseTime - endPhaseTime;
            }
            else
            {
                var startPhaseList = serverDataBase.GetPlayerTeamDerivObj(Round, indexFilters.GetPlayerTeamFilter(startPhase));
                var last_document = startPhaseList.LastOrDefault(); 

                var endPhaseList = serverDataBase.GetPlayerTeamDerivObj(Round, indexFilters.GetPlayerTeamFilter(endPhase));
                var first_document = endPhaseList.FirstOrDefault();
                if (last_document != null && first_document != null)
                {
                    return (startPhaseTime - last_document.Timer.phase_ends_in) + (first_document.Timer.phase_ends_in - endPhaseTime);                  
                }
                else
                {
                    return startPhaseTime - endPhaseTime;
                }

            }

        }
    }
}
