using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using WeatherApp.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WeatherApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SunriseSunsetPage : Page
    {
        string cityName = "Perth"; // Default City Name
        string unit = "Metric"; // Default Unit
        public SunriseSunsetPage()
        {
            this.InitializeComponent();
            UpdateUI();
            GetTimes();
        }

        private async void GetTimes()
        {
            WeatherAPI weatherApi = new WeatherAPI();
            await weatherApi.GetCurrentWeatherAPI(cityName, unit);
            var data = JsonConvert.DeserializeObject<WeatherData>(weatherApi.responseString);
            
            DateTime sunrise = Sys.ConvertDateTime(data.Sys.Sunrise); 
            DateTime sunset = Sys.ConvertDateTime(data.Sys.Sunset);

            todaysDate.Text = DateTime.Now.ToShortDateString();
            sunriseTime.Text = sunrise.ToShortTimeString();
            sunsetTime.Text = sunset.ToShortTimeString();
        }

        private void UpdateUI()
        {
            if ((string)ApplicationData.Current.LocalSettings.Values["Location"] == "Perth")
            {
                cityName = "Perth";
            }
            else if ((string)ApplicationData.Current.LocalSettings.Values["Location"] == "Brisbane")
            {
                cityName = "Brisbane";
            }
            else if ((string)ApplicationData.Current.LocalSettings.Values["Location"] == "Sydney")
            {
                cityName = "Sydney";
            }
            else if ((string)ApplicationData.Current.LocalSettings.Values["Location"] == "Melbourne")
            {
                cityName = "Melbourne";
            }
        }
        private void close_Click(object sender, RoutedEventArgs e)
        {
            if(ApplicationData.Current.LocalSettings.Values.ContainsKey("Sound"))
            {
                if (((bool)ApplicationData.Current.LocalSettings.Values["Sound"]) == true)
                {
                    SoundEffects.PlayTapEffect();
                }
            }
            this.Frame.GoBack();
        }
    }
}
