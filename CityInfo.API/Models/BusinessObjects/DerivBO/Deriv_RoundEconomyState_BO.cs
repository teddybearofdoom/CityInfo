using CSGO_GSI_Backend.Models.BusinessObjects.BaseGameStateBO;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
namespace CSGO_GSI_Backend.Models.BusinessObjects.DerivBO
{
    public class Deriv_RoundEconomyState_BO
    {
        public bool ecoBuyCT { get; set; }
        public bool ecoBuyT { get; set; }
        public bool halfBuyCT { get; set; }
        public bool halfBuyT { get; set; }
        public bool forceBuyCT { get; set; }
        public bool forceBuyT { get; set; }
        public bool fullBuyCT { get; set; }
        public bool fullBuyT { get; set; }
        public bool partialfullBuyCT { get; set; }
        public bool partialfullBuyT { get; set; }
        public bool pistolRoundCT { get; set; }
        public bool pistolRoundT { get; set; }
        public bool postPistolRoundCT { get; set; }
        public bool postPistolRoundT { get; set; }
        public bool breakRoundCT { get; set; }
        public bool breakRoundT { get; set; }
        public bool FirstResponseKillCT { get; set; }
        public bool FirstResponseKillT { get; set; }
        public bool FourvFourEqualizerCT {get;set;}
        public bool FourvFourEqualizerT { get; set; }
        public int Round { get; set; }
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
