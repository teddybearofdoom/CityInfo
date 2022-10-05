
using CSGO_GSI_Backend.Models.BusinessObjects.BaseGameStateBO;
using CSGO_GSI_Backend.Models.BusinessObjects.DerivBO;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityInfo.API.Models.BusinessObjects.DerivBO
{
    public class Deriv_PlayerTeam_BO
    {
        public Deriv_PlayerTeam_BO()
        {
            CTplayers = new List<Base_GameState_Player_BO>();
            Tplayers = new List<Base_GameState_Player_BO>();
            Timer = new Deriv_PhaseCountDowns_BO();
            //CTplayers = new List<PlayerNode>();
            //Tplayers = new List<PlayerNode>();
        }
        [BsonId]
        public ObjectId Id { get; set; }
        public Deriv_PhaseCountDowns_BO Timer { get; set; }
        public List<Base_GameState_Player_BO> CTplayers { get; set; }
        public List<Base_GameState_Player_BO> Tplayers { get; set; }
        //public List<PlayerNode> CTplayers { get; set; }
        //public List<PlayerNode> Tplayers { get; set; }
        
    }
}

