using System;
using System.Collections.Generic;
using System.Text;

namespace CSGO_GSI_Backend.Models.BusinessObjects.DerivBO
{
    /// <summary>
    /// Deriv Obj  to record respective teams Average Money
    /// </summary>
    public class Deriv_AverageMoney_BO
    {
        public int CT_averageMoney { get; set; }
        public int T_averageMoney { get; set; }
        public int round { get; set; }
    }
}
