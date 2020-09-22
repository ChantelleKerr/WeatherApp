using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class WeatherData
    {
        public List<Weather> Weather { get; set; }
        public Main Main { get; set; }
        public Wind Wind { get; set; }
        public Sys Sys { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public double Temp_Min { get; set; }
        public long Temp_Max { get; set; }
    }

    public partial class Weather
    {
        public long Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public partial class Wind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
    }
    public partial class Sys
    {
        public long Sunrise { get; set; }
        public long Sunset { get; set; }

        // Returns the local time on your device.. 
        //meaning if you change you city from Perth to Sydney (The time will still be displayed as Perth time)
        public static DateTime ConvertDateTime(long millisecond)
        {
            DateTime time = new DateTime(1970, 1, 1, 0, 0, 0).ToLocalTime();
            time = time.AddSeconds(millisecond).ToLocalTime();
            return time;
        }
    }
}
