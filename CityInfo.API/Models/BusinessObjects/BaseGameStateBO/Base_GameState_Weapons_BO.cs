using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGO_GSI_Backend.Models.BusinessObjects.BaseGameStateBO
{
    public class Base_GameState_Weapons_BO
    {
        public List<Base_GameState_Weapon_BO> weapon_BOs { get; set; }
        [JsonIgnore]
        Base_GameState_Weapon_BO weapon_BO { get; set; }


    }
}
