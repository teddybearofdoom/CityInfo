using System;
using System.Collections.Generic;
using System.Text;

namespace CSGO_GSI_Backend.Models.BusinessObjects.BaseGameStateBO
{
    public class Base_GameState_PhaseCountdowns_BO
    {
        public string phase { get; set; }
        public float phase_ends_in { get; set; }
    }
}
