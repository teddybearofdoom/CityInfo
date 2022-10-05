using System;
using System.Collections.Generic;
using System.Text;

namespace CSGO_GSI_Backend.Models.BusinessObjects.BaseGameStateBO
{
    public class Base_GameState_Player_MatchStats_BO
    {
        public int kills { get; set; }
        public int assists { get; set; }
        public int deaths { get; set; }
        public int mvps { get; set; }
        public int score { get; set; }
    }
}
