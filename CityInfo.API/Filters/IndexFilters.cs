
using CityInfo.API.Models.BusinessObjects.DerivBO;
using CSGO_GSI_Backend.Models.BusinessObjects.DerivBO;
using MongoDB.Driver;

namespace CityInfo.API.Filters
{
    public class IndexFilters
    {
        public FilterDefinition<Deriv_RoundCond_BO> GetRoundCondFilter(int i)
        {
            var builder = Builders<Deriv_RoundCond_BO>.Filter;

            var filter = builder.Eq("round", i);
            return filter;
        }
        public FilterDefinition<Deriv_RoundEconomyState_BO> GetRoundEconomyStateFilter(int i)
        {
            var RoundEconomyStatebuilder = Builders<Deriv_RoundEconomyState_BO>.Filter;

            var RoundEconomyStatefilter = RoundEconomyStatebuilder.Eq("Round", i);
            return RoundEconomyStatefilter;

        }
        public FilterDefinition<Deriv_Engagement_BO> GetEngagmentFilter(int i)
        {
            var engagementStatebuilder = Builders<Deriv_Engagement_BO>.Filter;

            var engagmentStateFilter = engagementStatebuilder.Eq("round", i);
            return engagmentStateFilter;
        }
        public FilterDefinition<Deriv_AWP_BOs> GetAWPEquipFilter(int i)
        {
            var AwpConditionStatebuilder = Builders<Deriv_AWP_BOs>.Filter;

            var AwpConditionCollectionfilter = AwpConditionStatebuilder.Eq("round", i);
            return AwpConditionCollectionfilter;
        }
        public FilterDefinition<Deriv_Kill_BO> GetKillBOFilter(int i)
        {
            var KillBObuilder = Builders<Deriv_Kill_BO>.Filter;

            var KillBOFilter = KillBObuilder.Eq("round", i);
            return KillBOFilter;
        }
        public FilterDefinition<Deriv_PlayerTeam_BO> GetPlayerTeamFilter(string phase)
        {
            var playerTeamBuilder = Builders<Deriv_PlayerTeam_BO>.Filter;

            var playerTeamFilter = playerTeamBuilder.Eq("Timer.phase", phase);
            return playerTeamFilter;
        }
        public FilterDefinition<Deriv_PlayerTeam_BO> GetPlayerTeamFilter(float timestamp, string Phase)
        {
            var builder = Builders<Deriv_PlayerTeam_BO>.Filter;

            var playerTeamFilter = builder.Gte("Timer.phase_ends_in", timestamp) & builder.Lte("Timer.phase_ends_in", timestamp + 0.1) & builder.Eq("Timer.phase", Phase);
            return playerTeamFilter;
        }
    }
}
