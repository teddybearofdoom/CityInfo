using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGO_GSI_Backend.Models.BusinessObjects.BaseGameStateBO
{
    public class Base_GameState_Map_BO
    {
        public string mode { get; set; }
        public string name { get; set; }
        public string phase { get; set; }
        public int round { get; set; }
        [JsonIgnore]
        public Base_GameState_Map_Team_BO teamCT_BO = new Base_GameState_Map_Team_BO();
        [JsonIgnore]
        public Base_GameState_Map_Team_BO teamT_BO = new Base_GameState_Map_Team_BO();
        public int num_matches_to_win_series { get; set; }
        public int current_spectators { get; set; }
        public int souvenirs_total { get; set; }
        public List<Base_GameState_Map_RoundWinCond_BO> map_RoundWinCond_BOs { get; set; } = new List<Base_GameState_Map_RoundWinCond_BO>();
 
        
    }
}
