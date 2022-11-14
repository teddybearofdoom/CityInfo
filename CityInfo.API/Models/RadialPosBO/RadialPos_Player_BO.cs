using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_GSI_Backend.Models.BusinessObjects.RadialPosBO
{
    public class RadialPos_Player_BO
    {
        public decimal x_coord;
        public decimal y_coord;
        public decimal z_coord;

        public decimal x_face;
        public decimal y_face;
        public decimal z_face;

        public string player_name;
        public int roundNumber; 
        public bool radialPositionalCheck = false;
        public bool isProcessed = false; 
    }
}
