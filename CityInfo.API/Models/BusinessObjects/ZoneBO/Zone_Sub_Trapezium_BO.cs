using System;
using System.Collections.Generic;
using System.Text;

namespace CSGO_GSI_Backend.Models.BusinessObjects.ZoneBO
{
    public class sub_zones_trapezium
    {
        public sub_zones_trapezium(string name, decimal side_one, string side_one_compass, bool side_one_greaterThan, decimal side_two, string side_two_compass, bool side_two_greaterThan, decimal side_three, string side_three_compass, bool side_three_greaterThan, Tuple<string, string, string, string> side_four, bool side_four_greaterThan, decimal verticality_z)
        {
            this.name = name;
            this.side_one = side_one;
            this.side_one_compass = side_one_compass;
            this.side_one_greaterThan = side_one_greaterThan;
            this.side_two = side_two;
            this.side_two_compass = side_two_compass;
            this.side_two_greaterThan = side_two_greaterThan;
            this.side_three = side_three;
            this.side_three_compass = side_three_compass;
            this.side_three_greaterThan = side_three_greaterThan;
            this.side_four = side_four;
            this.side_four_greaterThan = side_four_greaterThan;
            this.verticality_z = verticality_z;
        }

        //name to refer to zone by
        public string name { get; set; }

        //the sides first, second, third are the straight lines
        //number them anyway 
        //make sure to get the write greater than value 
        //especially considering quadrants 
        //the greater than value determines which side of a given
        //edge player needs to lie on for it to be true to be in zone
        //i.e. it lies to the left/right side of (if) left or right side recorded
        //it lies above/below side of (if) top or bottom side recorded

        //if recording for left/right side - keep RIGHT side as true
        //and LEFT side as false i.e. if a player needs to be to the
        //left of a given edge that is either east or west then bool value 
        //should be kept FALSE and vice verse for if a player needs to be
        //to the right (bool value should be kept TRUE)

        //similarly for top/bottom side - keep TOP side as true 
        //and BOTTOM side as false i.e. if a player needs to be 
        //above of a given edge that is either north or south then bool
        //value should be kept TRUE and vice verse for if a player needs to 
        //be below (bool value should be kept FALSE)

        //first side of trapezium
        public decimal side_one { get; set; }

        //which side of trapezium 
        public string side_one_compass { get; set; }

        //which side of the edge does the player need to be in 
        public bool side_one_greaterThan { get; set; }

        //second side of trapezium
        public decimal side_two { get; set; }

        //which side of trapezium 
        public string side_two_compass { get; set; }

        //which side of the edge does the player need to be in 
        public bool side_two_greaterThan { get; set; }

        //third side of trapezium
        public decimal side_three { get; set; }

        //which side of trapezium 
        public string side_three_compass { get; set; }

        //which side of the edge does the player need to be in 
        public bool side_three_greaterThan { get; set; }

        //side four is our coordinates for the slant height
        //Item1 - x1 Item2 - y1
        //Item3 - x2 Item4 - y2
        public Tuple<string, string, string, string> side_four { get; set; }

        //which side of the edge does the player need to be in 
        public bool side_four_greaterThan { get; set; }

        //Used to check for zones that are overlapping 
        public decimal verticality_z { get; set; }
    }
}
