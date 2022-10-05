using System;
using System.Collections.Generic;
using System.Text;

namespace CSGO_GSI_Backend.Models.BusinessObjects.BaseGameStateBO
{
    public class Base_GameState_Provider_BO
    {
        public string name { get; set; }
        public int appid { get; set; }
        public int version { get; set; }
        public string steamid { get; set; }
        public int timestamp { get; set; }
    }
}
