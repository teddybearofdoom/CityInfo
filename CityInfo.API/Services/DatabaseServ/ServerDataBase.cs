using MongoDB.Driver;
using MongoDB.Bson;
using CSGO_GSI_Backend.Models.BusinessObjects.DerivBO;
using CityInfo.API.Models.BusinessObjects.DerivBO;

namespace CityInfo.API.Services.DatabaseServ
{
    public class ServerDataBase
    {
        private IMongoDatabase mongoDatabase { get; set; }
        public ServerDataBase(IMongoDatabase mongoDatabase)
        {
            this.mongoDatabase = mongoDatabase;
        }
        public int GetTotalRoundCount()
        {
            int count = 0;
            foreach (var item in mongoDatabase.ListCollectionsAsync().Result.ToListAsync<BsonDocument>().Result)
            {
                count++;
            }
            count = count - 8;
            return count;
        }
        public Deriv_PlayerTeam_BO GetPlayerTeamDerivObj(int i)
        {
            var document = mongoDatabase.GetCollection<Deriv_PlayerTeam_BO>("Round " + (i - 1).ToString());

            var last_document = IMongoCollectionExtensions.AsQueryable(document).OrderByDescending(e => e.Id).FirstOrDefault();

            return last_document;
        }
        public List<Deriv_PlayerTeam_BO> GetPlayerTeamDerivObj(int i, FilterDefinition<Deriv_PlayerTeam_BO> playerTeamFilter)
        {
            var document = mongoDatabase.GetCollection<Deriv_PlayerTeam_BO>("Round " + (i - 1).ToString());

            var listofdocuments = document.Find(playerTeamFilter).ToList();

            return listofdocuments;
        }
        public List<Deriv_Kill_BO> GetDeriv_Kill_BO(FilterDefinition<Deriv_Kill_BO> Killfilter)
        {
            var KillsCollection = mongoDatabase.GetCollection<Deriv_Kill_BO>("Kills");

            var Killslist = KillsCollection.Find(Killfilter).ToList();
            return Killslist;
        }
        public Deriv_RoundCond_BO GetRoundCondDerivObj(FilterDefinition<Deriv_RoundCond_BO> filter)
        {
            var round_Collection = mongoDatabase.GetCollection<Deriv_RoundCond_BO>("RoundCond");

            var deriv_RoundCond_BO = round_Collection.Find(filter).ToList().FirstOrDefault();

            return deriv_RoundCond_BO;
        }
        public Deriv_RoundEconomyState_BO GetRoundEconomyStateDerivObj(FilterDefinition<Deriv_RoundEconomyState_BO> RoundEconomyStatefilter)
        {
            var RoundEconomyStateCollection = mongoDatabase.GetCollection<Deriv_RoundEconomyState_BO>("RoundEconomyState");

            var deriv_RoundEconomyState_BO = RoundEconomyStateCollection.Find(RoundEconomyStatefilter).FirstOrDefault();
            return deriv_RoundEconomyState_BO;
        }
        public Deriv_Engagement_BO GetEngagmentDerivObj(FilterDefinition<Deriv_Engagement_BO> filter)
        {
            var engagementStateCollection = mongoDatabase.GetCollection<Deriv_Engagement_BO>("Engagements");

            var document = engagementStateCollection.Find(filter).ToList().OrderByDescending(e => e.Id).FirstOrDefault();
            return document;
        }
        public List<Deriv_Engagement_BO> GetEngagmentDerivObjList(FilterDefinition<Deriv_Engagement_BO> filter)
        {
            var engagementStateCollection = mongoDatabase.GetCollection<Deriv_Engagement_BO>("Engagements");

            var document = engagementStateCollection.Find(filter).ToList();
            return document;
        }
        public IMongoCollection<Deriv_RoundEconomyState_BO> GetRoundEconomyStateCollection()
        {
            var RoundEconomyStateCollection = mongoDatabase.GetCollection<Deriv_RoundEconomyState_BO>("RoundEconomyState");

            return RoundEconomyStateCollection;

        }
        public Deriv_AWP_BOs GetAwpEquipDerivObj(FilterDefinition<Deriv_AWP_BOs> filter)
        {
            var AwpConditionCollection = mongoDatabase.GetCollection<Deriv_AWP_BOs>("AWPEquip");

            var deriv_AWP_BOs = AwpConditionCollection.Find(filter).FirstOrDefault();
            return deriv_AWP_BOs;
        }
        public Deriv_PlayerTeam_BO GetPlayerTeamDerivObj(FilterDefinition<Deriv_PlayerTeam_BO> filter, int i)
        {
            var round_Collection = mongoDatabase.GetCollection<Deriv_PlayerTeam_BO>("Round " + (i - 1).ToString());

            var last_document = round_Collection.Find(filter).ToList().OrderByDescending(e => e.Id).FirstOrDefault();

            return last_document;
        }
    }
}
