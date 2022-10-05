using System;
using System.Collections.Generic;
using System.Text;

namespace CSGO_GSI_Backend.Models.BusinessObjects.BaseGameStateBO
{
    public class Base_GameState_Player_State_BO
    {
        public decimal health { get; set; }
        public decimal armor { get; set; }
        public bool helmet { get; set; }
        public int flashed { get; set; }
        public int smoked { get; set; }
        public int burning { get; set; }
        public int money { get; set; }
        public int round_kills { get; set; }
        public int round_killhs { get; set; }
        public int round_totaldmg { get; set; }
        public int equip_value { get; set; }
    }
}
