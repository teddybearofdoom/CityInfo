using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGO_GSI_Backend.Models.BusinessObjects.BaseGameStateBO
{
    public class Base_GameState_Root_BO
    {
        public Base_GameState_Provider_BO provider_BO { get; set; }
        public Base_GameState_FocusPlayer_BO focusPlayer_BO { get; set; }
        public Base_GameState_Map_BO map_BO { get; set; }
        public Base_GameState_Players_BO players_BO { get; set; }
        public Base_GameState_PhaseCountdowns_BO phaseCountdowns_BO { get; set; }
        public Base_GameState_Root_BO added_root_BO { get; set; }
        public Base_GameState_Root_BO previous_root_BO { get; set; }

    }
}
