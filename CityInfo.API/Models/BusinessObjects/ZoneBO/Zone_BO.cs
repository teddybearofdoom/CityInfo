using System;
using System.Collections.Generic;
using System.Text;

namespace CSGO_GSI_Backend.Models.BusinessObjects.ZoneBO
{
    public class zones
    {
        public string name { get; set; }
        public List<sub_zones_rectangle> sub_Zones_Rectangles { get; set; }
        public List<sub_zones_trapezium> sub_Zones_Trapezia { get; set; }
        public zones(string name)
        {
            this.name = name;
            sub_Zones_Rectangles = new List<sub_zones_rectangle>();
            sub_Zones_Trapezia = new List<sub_zones_trapezium>();
        }
    }
}
