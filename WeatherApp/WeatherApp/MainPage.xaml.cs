using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using WeatherApp.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WeatherApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string cityName;
        private string unit;
        private DateTime now;
        public MainPage()
        {
            this.InitializeComponent();
            cityName = "Perth"; // Default City Name
            unit = "Metric";
            UpdateUI();
            GetCurrentWeather();
        }

        // Uses the API class to get the current weather data
        private async void GetCurrentWeather()
        {
            try
            {
                WeatherAPI weatherApi = new WeatherAPI();
                await weatherApi.GetCurrentWeatherAPI(cityName, unit);
                var data = JsonConvert.DeserializeObject<WeatherData>(weatherApi.responseString);

                int curTemp = (int)data.Main.Temp;
                int curMax = (int)data.Main.Temp_Max;
                int curMin = (int)data.Main.Temp_Min;
                int curHum = data.Main.Humidity;
                int windDeg = data.Wind.Deg;
                double speed = data.Wind.Speed;

                temp.Text = curTemp.ToString() + "°";
                maxTemp.Text = curMax.ToString() + "°";
                minTemp.Text = curMin.ToString() + "°";
                humidity.Text = curHum.ToString() + "%";
                windSpeed.Text = speed.ToString();
                windDirection.Text = WindDirection.GetWindDirection(windDeg);
                desc.Text = data.Weather[0].Description.ToUpper();
                UpdateWeatherIcon();
                now = DateTime.Now;
                LoggingService.Instance.LogSuccess(now, "Connected to API");
            }
            catch
            {
                now = DateTime.Now;
                LoggingService.Instance.LogCatastrophicError(now, "Can't connect to API!");
                ContentDialog noConnection = new ContentDialog
                {
                    Title = "Can't Connect to API",
                    Content = "Check your connection and try again.",
                    CloseButtonText = "Ok"
                };
                ContentDialogResult result = await noConnection.ShowAsync();
            }
        }

        void UpdateWeatherIcon()
        {
            try
            {
                if (desc.Text.Contains("CLOUDS"))
                {
                    weatherIcon.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/cloudy.png"));
                }
                else if (desc.Text.Contains("RAIN") || desc.Text.Contains("DRIZZLE"))
                {
                    weatherIcon.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/rain.png"));
                }
                else if (desc.Text.Contains("THUNDERSTORM"))
                {
                    weatherIcon.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/storm.png"));
                }
                else
                {
                    weatherIcon.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/sunny.png"));
                }
            }
            catch
            {
                now = DateTime.Now;
                LoggingService.Instance.LogWarning(now, "Can't update weather icon");
            }
            
        }


        private void settings_Click(object sender, RoutedEventArgs e)
        {
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("Sound"))
            {
                if (((bool)ApplicationData.Current.LocalSettings.Values["Sound"]) == true)
                {
                    SoundEffects.PlayTapEffect();
                }
            }
            this.Frame.Navigate(typeof(PropertiesPage));
        }


        private void UpdateUI()
        {
            try
            {
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
            }
            catch
            {
                now = DateTime.Now;
                LoggingService.Instance.LogError(now, "No Unit Set");
            }

            GetLocation();

            try
            {
                if (ApplicationData.Current.LocalSettings.Values.ContainsKey("Colour"))
                {

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
            }
            catch
            {
                now = DateTime.Now;
                LoggingService.Instance.LogError(now, "No Colour Set");
            }
        }
            

        private void GetLocation()
        {
            try
            {
                if (ApplicationData.Current.LocalSettings.Values.ContainsKey("Location"))
                {
                    if ((string)ApplicationData.Current.LocalSettings.Values["Location"] == "Perth")
                    {
                        cityName = "Perth";
                        city.Text = "PERTH";
                    }
                    else if ((string)ApplicationData.Current.LocalSettings.Values["Location"] == "Sydney")
                    {
                        cityName = "Sydney";
                        city.Text = "SYDNEY";
                    }
                    else if ((string)ApplicationData.Current.LocalSettings.Values["Location"] == "Brisbane")
                    {
                        cityName = "Brisbane";
                        city.Text = "BRISBANE";
                    }
                    else if ((string)ApplicationData.Current.LocalSettings.Values["Location"] == "Melbourne")
                    {
                        cityName = "Melbourne";
                        city.Text = "MELBOURNE";
                    }
                }
            }
            catch
            {
                now = DateTime.Now;
                LoggingService.Instance.LogError(now, "No Location Set");
            }
        }

        private void BlueScheme()
        {
            appBG.Color = Color.FromArgb(255, 110, 160, 181);

            Style blueTitle = Application.Current.Resources["DarkBlueTitle"] as Style;
            city.Style = blueTitle;
            temp.Style = blueTitle;
            desc.Style = blueTitle;
            minTemp.Style = blueTitle;
            maxTemp.Style = blueTitle;
            humidity.Style = blueTitle;
            windDirection.Style = blueTitle;
            windSpeed.Style = blueTitle;
            speedUnit.Style = blueTitle;

            Style blueSubTitle = Application.Current.Resources["LightBlueTitle"] as Style;
            min_txt.Style = blueSubTitle;
            max_txt.Style = blueSubTitle;
            hum_txt.Style = blueSubTitle;
            windDir_txt.Style = blueSubTitle;
            speed_txt.Style = blueSubTitle;
            updateButtonTitle.Style = blueSubTitle;
            sunButtonTitle.Style = blueSubTitle;

            Style blueButton = Application.Current.Resources["BlueButton"] as Style;
            sunTimesButton.Style = blueButton;
            updatesButton.Style = blueButton;
        }

        private void PurpleScheme()
        {
            appBG.Color = Color.FromArgb(255, 124, 110, 181);

            Style purpleTitle = Application.Current.Resources["DarkPurpleTitle"] as Style;
            city.Style = purpleTitle;
            temp.Style = purpleTitle;
            desc.Style = purpleTitle;
            minTemp.Style = purpleTitle;
            maxTemp.Style = purpleTitle;
            humidity.Style = purpleTitle;
            windDirection.Style = purpleTitle;
            windSpeed.Style = purpleTitle;
            speedUnit.Style = purpleTitle;

            Style purpleSubTitle = Application.Current.Resources["LightPurpleTitle"] as Style;
            min_txt.Style = purpleSubTitle;
            max_txt.Style = purpleSubTitle;
            hum_txt.Style = purpleSubTitle;
            windDir_txt.Style = purpleSubTitle;
            speed_txt.Style = purpleSubTitle;
            updateButtonTitle.Style = purpleSubTitle;
            sunButtonTitle.Style = purpleSubTitle;

            Style purpleButton = Application.Current.Resources["PurpleButton"] as Style;
            sunTimesButton.Style = purpleButton;
            updatesButton.Style = purpleButton;
        }

        private void GreenScheme()
        {
            appBG.Color = Color.FromArgb(255, 110, 181, 130);

            Style greenTitle = Application.Current.Resources["DarkGreenTitle"] as Style;
            city.Style = greenTitle;
            temp.Style = greenTitle;
            desc.Style = greenTitle;
            minTemp.Style = greenTitle;
            maxTemp.Style = greenTitle;
            humidity.Style = greenTitle;
            windDirection.Style = greenTitle;
            windSpeed.Style = greenTitle;
            speedUnit.Style = greenTitle;

            Style greenSubTitle = Application.Current.Resources["LightGreenTitle"] as Style;
            min_txt.Style = greenSubTitle;
            max_txt.Style = greenSubTitle;
            hum_txt.Style = greenSubTitle;
            windDir_txt.Style = greenSubTitle;
            speed_txt.Style = greenSubTitle;
            updateButtonTitle.Style = greenSubTitle;
            sunButtonTitle.Style = greenSubTitle;

            Style greenButton = Application.Current.Resources["GreenButton"] as Style;
            sunTimesButton.Style = greenButton;
            updatesButton.Style = greenButton;
        }

        private void sunTimesButton_Click(object sender, RoutedEventArgs e)
        {
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("Sound"))
            {
                if (((bool)ApplicationData.Current.LocalSettings.Values["Sound"]) == true)
                {
                    SoundEffects.PlayTapEffect();
                }
            }
            this.Frame.Navigate(typeof(SunriseSunsetPage));
        }

        private void updatesButton_Click(object sender, RoutedEventArgs e)
        {
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("Sound"))
            {
                if (((bool)ApplicationData.Current.LocalSettings.Values["Sound"]) == true)
                {
                    SoundEffects.PlayTapEffect();
                }
            }
            this.Frame.Navigate(typeof(WeatherUpdatesPage));
        }
    }
}