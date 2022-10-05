using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGO_GSI_Backend.Models.BusinessObjects.BaseGameStateBO
{
    public class Base_GameState_FocusPlayer_BO
    {
        public string steamid { get; set; }
        public string name { get; set; }
        public int observer_slot { get; set; }
        public string team { get; set; }
        public string activity { get; set; }
        [JsonIgnore]
        public Base_GameState_Player_State_BO playerCond_BO { get; set; } = new Base_GameState_Player_State_BO();
        [JsonIgnore]
        public Base_GameState_Player_MatchStats_BO playerStats_BO { get; set; } = new Base_GameState_Player_MatchStats_BO();
        [JsonIgnore]
        public Base_GameState_Weapon_BO weapon_BO { get; set; } = new Base_GameState_Weapon_BO(); 
        public string spectarget { get; set; }
        public string position { get; set; }
        public string forward { get; set; }

    }
}
