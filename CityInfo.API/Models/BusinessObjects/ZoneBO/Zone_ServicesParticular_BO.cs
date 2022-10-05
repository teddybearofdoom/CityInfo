using System;
using System.Collections.Generic;
using System.Text;

namespace CSGO_GSI_Backend.Models.BusinessObjects.ZoneBO
{
    public class zone_variables
    {
        //player coords in different data types 
        public string x, x_coeff, y, y_coeff, z, z_coeff, player_name;
        public decimal x_coord, y_coord, z_coord;
        public zone_variables()
        {

        }
        //setting decimal coords
        public void set_player_inputs(decimal x, decimal y, decimal z)
        {
            set_coords(x, y, z);
        }

        public void set_player_inputs(string x, string y, string z)
        {
            set_coords(x, y, z);
        }

        public void set_player_inputs(double x, double y, double z)
        {
            set_coords(x, y, z);
        }

        public void set_coords(decimal x, decimal y, decimal z)
        {
            x_coord = x;
            y_coord = y;
            z_coord = z;
        }

        public void set_coords(double x, double y, double z)
        {
            x_coord = Convert.ToDecimal(x);
            y_coord = Convert.ToDecimal(y);
            z_coord = Convert.ToDecimal(z);
        }

        public void set_coords(string x, string y, string z)
        {
            x_coord = Convert.ToDecimal(x);
            y_coord = Convert.ToDecimal(y);
            z_coord = Convert.ToDecimal(z);
        }

        //function that is called to set up player inputs 
        public void set_variables(decimal x, decimal y, decimal z, string name)
        {
            this.x = x.ToString();
            this.y = y.ToString();
            this.z = z.ToString();
            set_player_inputs(x, y, z);
            player_name = name;
        }

        public void set_variables(double x, double y, double z, string name)
        {
            this.x = x.ToString();
            this.y = y.ToString();
            this.z = z.ToString();
            set_player_inputs(x, y, z);
            player_name = name;
        }

        public void set_variables(string x, string y, string z, string name)
        {
            this.x = x.ToString();
            this.y = y.ToString();
            this.z = z.ToString();
            set_player_inputs(x, y, z);
            player_name = name;
        }

        public void set_coeffs(string x_coeff, string y_coeff, string z_coeff)
        {
            this.x_coeff = x_coeff;
            this.y_coeff = y_coeff;
            this.z_coeff = z_coeff;
        }
    }
}
