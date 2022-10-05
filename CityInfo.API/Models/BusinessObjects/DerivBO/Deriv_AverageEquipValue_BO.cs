using System;
using System.Collections.Generic;
using System.Text;

namespace CSGO_GSI_Backend.Models.BusinessObjects.DerivBO
{
    /// <summary>
    /// Deriv Obj  to record respective teams Average Equip Values 
    /// </summary>
    public class Deriv_AverageEquipValue_BO
    {
        public int CT_averageEquipValue { get; set; }
        public int T_averageEquipValue { get; set; }
        public string roundPhase { get; set; }
        public int round { get; set; }

       
    }
}
