using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class ForecastData 
    {
        public List<List> List { get; set; }
    }
    public partial class List : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private long _dt;
        public Main_ main { get; set; }
        public long Dt 
        {
            get { return _dt; }
            set
            {
                _dt = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("dateTime"));
                }
            }
        }
        public static DateTime GetDate(long millisecond)
        {
            DateTime day = new System.DateTime(1970, 1, 1, 0, 0, 0).ToLocalTime();
            day = day.AddSeconds(millisecond).ToLocalTime();
            return day;
        }
    }

    public partial class Main_ : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        double _temp;
        int _pressure;
        int _humidity;
        int _seaLevel;
        int _grndLevel;
        private string _dts;
        public double Temp 
        {
            get { return _temp; }
            set
            {
                _temp = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Temp"));
                }
            }
        }
        
        public int Pressure
        {
            get { return _pressure; }
            set
            {
                _pressure = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Pressure"));
                }
            }
        }

        public int Humidity
        {
            get { return _humidity; }
            set
            {
                _humidity = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Humidity"));
                }
            }
        }
        public int Sea_Level
        {
            get { return _seaLevel; }
            set
            {
                _seaLevel = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Sea_Level"));
                }
            }
        }
        public int Grnd_Level
        {
            get { return _grndLevel; }
            set
            {
                _grndLevel = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Grnd_Level"));
                }
            }
        }
        public string DtString
        {
            get { return _dts; }
            set
            {
                _dts = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("DtString"));
                }
            }
        }
    }
}
