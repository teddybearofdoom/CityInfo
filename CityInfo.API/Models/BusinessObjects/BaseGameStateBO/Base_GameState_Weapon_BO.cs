using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CSGO_GSI_Backend.Models.BusinessObjects.BaseGameStateBO
{
    public class Base_GameState_Weapon_BO
    {
        public string name { get; set; }
        public string paintkit { get; set; }
        public string type { get; set; }
        public int ammo_clip { get; set; }
        public int ammo_clip_max { get; set; }
        public int ammo_reserve { get; set; }
        public string state { get; set; }
    }
}
