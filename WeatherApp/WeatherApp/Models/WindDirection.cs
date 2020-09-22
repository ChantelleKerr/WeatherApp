using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class WindDirection
    {
        // Receives int and uses it to find the direction, which is returned as a string
        public static string GetWindDirection(int degrees)
        {
            string direction = "";
            // North
            if (degrees == 0 || degrees == 360)
                direction = "N";
            // East
            if (degrees == 90)
                direction = "E";
            // South
            if (degrees == 180)
                direction = "S";
            // West
            if (degrees == 270)
                direction = "W";

            // North East
            if (degrees == 45)
                direction = "NE";
            // South East
            if (degrees == 135)
                direction = "SE";
            // South West
            if (degrees == 225)
                direction = "SW";
            // North West
            if (degrees == 315)
                direction = "NW";

            // North North East
            if (degrees > 0 && degrees < 45)
                direction = "NNE";
            // East North East
            if (degrees > 45 && degrees < 90)
                direction = "ENE";
            // East South East
            if (degrees > 90 && degrees < 135)
                direction = "ESE";
            //South South East
            if (degrees > 135 && degrees < 180)
                direction = "SSE";
            // South South West
            if (degrees > 180 && degrees < 225)
                direction = "SSW";
            // West South West
            if (degrees > 225 && degrees < 270)
                direction = "WSW";
            // West North West
            if (degrees > 270 && degrees < 315)
                direction = "WNW";
            // North North West
            if (degrees > 315 && degrees < 360)
                direction = "NNW";

            return direction;
        }

    }
}
