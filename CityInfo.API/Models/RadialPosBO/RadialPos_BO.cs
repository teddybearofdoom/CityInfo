using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_GSI_Backend.Models.BusinessObjects.RadialPosBO
{
    //Business Object representing string of coordinate data for each
    //player against which radial positioning would be determined
    public class RadialPos_BO
    {
        //It is container of lists against each player
        public List<RadialPos_Player_BO> player1 { get; set; } = new List<RadialPos_Player_BO>();
        public List<RadialPos_Player_BO> player2 { get; set; } = new List<RadialPos_Player_BO>();
        public List<RadialPos_Player_BO> player3 { get; set; } = new List<RadialPos_Player_BO>();
        public List<RadialPos_Player_BO> player4 { get; set; } = new List<RadialPos_Player_BO>();
        public List<RadialPos_Player_BO> player5 { get; set; } = new List<RadialPos_Player_BO>();
        public List<RadialPos_Player_BO> player6 { get; set; } = new List<RadialPos_Player_BO>();
        public List<RadialPos_Player_BO> player7 { get; set; } = new List<RadialPos_Player_BO>();
        public List<RadialPos_Player_BO> player8 { get; set; } = new List<RadialPos_Player_BO>();
        public List<RadialPos_Player_BO> player9 { get; set; } = new List<RadialPos_Player_BO>();
        public List<RadialPos_Player_BO> player10 { get; set; } = new List<RadialPos_Player_BO>();

        public List<List<RadialPos_Player_BO>> radialPos_Player_BOs = new List<List<RadialPos_Player_BO>>();

        //public IEnumerable<RadialPos_Player_BO> playerList { get; set; }

        public RadialPos_BO()
        {
            //This populates the master list 
            //Master contains list of each players'
            //coordinate path
            radialPos_Player_BOs.Add(player1);
            radialPos_Player_BOs.Add(player2);
            radialPos_Player_BOs.Add(player3);
            radialPos_Player_BOs.Add(player4);
            radialPos_Player_BOs.Add(player5);
            radialPos_Player_BOs.Add(player6);
            radialPos_Player_BOs.Add(player7);
            radialPos_Player_BOs.Add(player8);
            radialPos_Player_BOs.Add(player9);
            radialPos_Player_BOs.Add(player10);
        }

    }
}
