using System;
using System.Collections.Generic;
using System.Text;

namespace CSGO_GSI_Backend.Models.BusinessObjects.ZoneBO
{
    public class sub_zones_rectangle
    {
        public sub_zones_rectangle(string name, decimal left_side, decimal right_side, decimal top_side, decimal bottom_side, decimal verticality_z)
        {
            this.name = name;
            this.left_side = left_side;
            this.right_side = right_side;
            this.top_side = top_side;
            this.bottom_side = bottom_side;
            this.verticality_z = verticality_z;
        }

        //name to refer to zone by
        public string name { get; set; }

        //the sides that are being recorded in form x and y coordinates that make a straight line which we are using as boundaries for zones

        //this left hand side of rect zone defined in an overall, need to check the player is the RIGHT of this side
        public decimal left_side { get; set; }

        //this right hand side of rect zone defined in an overall, need to check the player is to the LEFT of this side 
        public decimal right_side { get; set; }

        //this top side of rect zone defined in an overall, need to check the player is to BELOW of this side
        public decimal top_side { get; set; }

        //this bottom side of rect zone defined in an overall, need to check the player is ABOVE of this side
        public decimal bottom_side { get; set; }

        //Used to check for zones that are overlapping 
        public decimal verticality_z { get; set; }
    }
}
