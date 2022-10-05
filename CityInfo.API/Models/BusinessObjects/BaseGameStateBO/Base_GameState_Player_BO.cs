
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGO_GSI_Backend.Models.BusinessObjects.BaseGameStateBO
{
    public class Base_GameState_Player_BO
    {
        public string Name { get; set; }
        public int observer_slot { get; set; }
        public string Team { get; set; }
        public string Activity { get; set; }
        public string Clan { get; set; }
        public Base_GameState_Player_State_BO playerCond_BO { get; set; }
        public Base_GameState_Player_MatchStats_BO playerStats_BO { get; set; }
        
        public Base_GameState_Weapons_BO weapons_BO { get; set; }
        public string Spectarget { get; set; }
        public string Position { get; set; }
        public string Forward { get; set; }
        public string Zone { get; set; }

    }
}
