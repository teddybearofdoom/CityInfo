using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_GSI_Backend.Models.BusinessObjects.DerivBO
{
    public class Deriv_Kill_BO
    {
        public string killing_Player_Name { get; set; }
        public string killing_Player_Team { get; set; }
        public string killing_Player_Weapon { get; set; }
        public string victim_Player_Name { get; set; }
        public string victim_Player_Team { get; set; }
        public string victim_Player_Weapon { get; set; }
        public float time { get; set; }
        public string phase { get; set; }
        public string killing_Player_Zone { get;set;}
        public string victim_Player_Zone { get; set; }
        public int round { get; set; }
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
