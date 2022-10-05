using System;
using System.Collections.Generic;
using System.Text;

namespace CSGO_GSI_Backend.Models.BusinessObjects.BaseGameStateBO
{
    public class Base_GameState_Map_Team_BO
    {
        public int score { get; set; }
        public int timeouts_remaining { get; set; }
        public int matches_won_this_series { get; set; }
    }
}
