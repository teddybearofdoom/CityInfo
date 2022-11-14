using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CSGO_GSI_Backend.Models.BusinessObjects.RadialPosBO
{
    public class RadialPos_Origin_BO
    {
        public string player_name; 
        public string player_steam_id;

        public int round;
        [BsonId]
        public ObjectId Id { get; set; }

        public bool movement_PositionalOrigin = false;
        public bool kill_PositionalOrigin = false;
        public List<PlayerCoord_Path> playerCoord_Paths = new List<PlayerCoord_Path>();
    }

    public class PlayerCoord_Path
    {
        public decimal x_coord;
        public decimal y_coord;
        public decimal z_coord;

        public decimal x_face;
        public decimal y_face;
        public decimal z_face;

        public bool isPositionalOrigin = false;
    }
}
