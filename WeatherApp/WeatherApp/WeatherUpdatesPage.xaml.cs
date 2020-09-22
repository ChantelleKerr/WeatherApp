using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using WeatherApp.Models;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WeatherApp
{
    public sealed partial class WeatherUpdatesPage : Page
    {
        public ObservableCollection<Main_> weather = new ObservableCollection<Main_>();
        string cityName = "Perth";
        string unit = "Metric";
        public WeatherUpdatesPage()
        {
            this.InitializeComponent();
            weatherLV.ItemsSource = weather;
            UpdateUI();
            GetForecast();
        }

        private async void GetForecast()
        {

            WeatherAPI weatherApi = new WeatherAPI();
            await weatherApi.GetForecastAPI(cityName, unit);
            var data = JsonConvert.DeserializeObject<ForecastData>(weatherApi.forecastResponseString);

            foreach (var i in data.List)
            {
                DateTime dateTime = List.GetDate(i.Dt);
                weather.Add(new Main_ { DtString = dateTime.ToString(), Temp = i.main.Temp, Humidity = i.main.Humidity, Pressure = i.main.Pressure, Sea_Level = i.main.Sea_Level, Grnd_Level = i.main.Grnd_Level });
            }
        }

        private void UpdateUI()
        {
            try
            {
                GetLocation();

                if (ApplicationData.Current.LocalSettings.Values.ContainsKey("Metric"))
                {
                    if (((bool)ApplicationData.Current.LocalSettings.Values["Metric"]) == true)
                    {
                        unit = "Metric";
                    }
                    else
                    {
                        unit = "Imperial";
                    }
                }

                if ((string)ApplicationData.Current.LocalSettings.Values["Colour"] == "Blue")
                {
                    BlueScheme();
                }
                else if ((string)ApplicationData.Current.LocalSettings.Values["Colour"] == "Purple")
                {
                    PurpleScheme();
                }
                else if ((string)ApplicationData.Current.LocalSettings.Values["Colour"] == "Green")
                {
                    GreenScheme();
                }
            }
            catch
            {
                Debug.WriteLine("Something went wrong");
            }
        }

        private void GetLocation()
        {
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("Location"))
            {
                if ((string)ApplicationData.Current.LocalSettings.Values["Location"] == "Perth")
                {
                    cityName = "Perth";
                }
                else if ((string)ApplicationData.Current.LocalSettings.Values["Location"] == "Sydney")
                {
                    cityName = "Sydney";
                }
                else if ((string)ApplicationData.Current.LocalSettings.Values["Location"] == "Brisbane")
                {
                    cityName = "Brisbane";
                }
                else if ((string)ApplicationData.Current.LocalSettings.Values["Location"] == "Melbourne")
                {
                    cityName = "Melbourne";
                }
            }
        }
        private void BlueScheme()
        {
            appBG.Color = Color.FromArgb(255, 110, 160, 181);
            Style blueSubTitle = Application.Current.Resources["LightBlueTitle"] as Style;
            dateTime_txt.Style = blueSubTitle;
            temp_txt.Style = blueSubTitle;
            humidity_txt.Style = blueSubTitle;
            press_txt.Style = blueSubTitle;
            sea_txt.Style = blueSubTitle;
            grnd_txt.Style = blueSubTitle;
        }

        private void PurpleScheme()
        {
            appBG.Color = Color.FromArgb(255, 124, 110, 181);
            Style purpleSubTitle = Application.Current.Resources["LightPurpleTitle"] as Style;
            dateTime_txt.Style = purpleSubTitle;
            temp_txt.Style = purpleSubTitle;
            humidity_txt.Style = purpleSubTitle;
            press_txt.Style = purpleSubTitle;
            sea_txt.Style = purpleSubTitle;
            grnd_txt.Style = purpleSubTitle;
        }
        private void GreenScheme()
        {
            appBG.Color = Color.FromArgb(255, 110, 181, 130);
            Style greenSubTitle = Application.Current.Resources["LightGreenTitle"] as Style;
            dateTime_txt.Style = greenSubTitle;
            temp_txt.Style = greenSubTitle;
            humidity_txt.Style = greenSubTitle;
            press_txt.Style = greenSubTitle;
            sea_txt.Style = greenSubTitle;
            grnd_txt.Style = greenSubTitle;
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("Sound"))
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
