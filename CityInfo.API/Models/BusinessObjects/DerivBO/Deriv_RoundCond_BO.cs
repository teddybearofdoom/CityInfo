using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_GSI_Backend.Models.BusinessObjects.DerivBO
{
    public class Deriv_RoundCond_BO
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string win_team { get; set; }
        public int round{get;set;}
    }
}
