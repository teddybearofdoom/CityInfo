using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CSGSI_FrontEnd.HistoricalDatabaseModels
{
    public class HistoricalDatabaseViewModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int Round { get; set; }
        public int mapNumber { get; set; }
        public string mapName { get; set; }
        public string roundWinteam { get; set; }
        public TeamProfile TeamA { get; set; }
        public TeamProfile TeamB { get; set; }
        public HistoricalDatabaseViewModel(TeamProfile teamA, TeamProfile teamB, int Round, int mapNumber, string mapName, string roundWinteam)
        {
            this.TeamA = teamA;
            this.TeamB = teamB;
            this.Round = Round;
            this.mapNumber = mapNumber;
            this.mapName = mapName;
            this.roundWinteam = roundWinteam;
        }
    }
}
