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
using Windows.UI;
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
    public sealed partial class PropertiesPage : Page
    {
        public PropertiesPage()
        {
            this.InitializeComponent();
            Application.Current.Resources["ToggleSwitchFillOnPointerOver"] = new SolidColorBrush(Color.FromArgb(100, 47, 51, 59));
            Application.Current.Resources["ToggleSwitchFillOn"] = new SolidColorBrush(Color.FromArgb(100, 47, 51, 59));
            UpdateUI();
        }

        private void metricToggle_Toggled(object sender, RoutedEventArgs e)
        {
            ApplicationData.Current.LocalSettings.Values["Metric"] = metricToggle.IsOn;
            UpdateUI();

        }

        private void soundToggle_Toggled(object sender, RoutedEventArgs e)
        {
            ApplicationData.Current.LocalSettings.Values["Sound"] = soundToggle.IsOn;
            UpdateUI();
        }

        // Set the Colour Scheme
        private void colorSchemeCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((string)colorSchemeCB.SelectedItem == "Blue")
            {
                ApplicationData.Current.LocalSettings.Values["Colour"] = "Blue";
            }
            else if ((string)colorSchemeCB.SelectedItem == "Purple")
            {
                ApplicationData.Current.LocalSettings.Values["Colour"] = "Purple";
            }
            else if ((string)colorSchemeCB.SelectedItem == "Green")
            {
                ApplicationData.Current.LocalSettings.Values["Colour"] = "Green";
            }
            UpdateUI();
        }

        // Update the UI
        private void UpdateUI()
        {
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("Metric"))
            {
                if (((bool)ApplicationData.Current.LocalSettings.Values["Metric"]) == true)
                {
                    metricToggle.IsOn = true;
                }
                else
                {
                    metricToggle.IsOn = false;
                }
            }

            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("Sound"))
            {
                if (((bool)ApplicationData.Current.LocalSettings.Values["Sound"]) == true)
                {
                    soundToggle.IsOn = true;
                }
                else
                {
                    soundToggle.IsOn = false;
                }
            }
            
            try
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
            catch
            {
                Debug.WriteLine("Something went wrong");
            }

            try
            {
                if ((string)ApplicationData.Current.LocalSettings.Values["Location"] == "Perth")
                {
                    locationCB.SelectedIndex = 0;
                }
                else if ((string)ApplicationData.Current.LocalSettings.Values["Location"] == "Brisbane")
                {
                    locationCB.SelectedIndex = 1;
                }
                else if ((string)ApplicationData.Current.LocalSettings.Values["Location"] == "Sydney")
                {
                    locationCB.SelectedIndex = 2;
                }
                else if ((string)ApplicationData.Current.LocalSettings.Values["Location"] == "Melbourne")
                {
                    locationCB.SelectedIndex = 3;
                }
            }
            catch
            {
                Debug.WriteLine("Something went wrong");
            }
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

        private void locationCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((string)locationCB.SelectedItem == "Perth")
            {
                ApplicationData.Current.LocalSettings.Values["Location"] = "Perth";
            }
            else if ((string)locationCB.SelectedItem == "Sydney")
            {
                ApplicationData.Current.LocalSettings.Values["Location"] = "Sydney";
            }
            else if ((string)locationCB.SelectedItem == "Brisbane")
            {
                ApplicationData.Current.LocalSettings.Values["Location"] = "Brisbane";
            }
            else if ((string)locationCB.SelectedItem == "Melbourne")
            {
                ApplicationData.Current.LocalSettings.Values["Location"] = "Melbourne";
            }
        }


        private void BlueScheme()
        {
            

            colorSchemeCB.SelectedIndex = 0;
            appBG.Color = Color.FromArgb(255, 110, 160, 181);
            Style blueTitle = Application.Current.Resources["DarkBlueTitle"] as Style;
            Title.Style = blueTitle;
            SoundTitle.Style = blueTitle;
            MetricTitle.Style = blueTitle;
        }
        private void PurpleScheme()
        {

            colorSchemeCB.SelectedIndex = 1;
            appBG.Color = Color.FromArgb(255, 124, 110, 181);
            Style purpleTitle = Application.Current.Resources["DarkPurpleTitle"] as Style;
            Title.Style = purpleTitle;
            SoundTitle.Style = purpleTitle;
            MetricTitle.Style = purpleTitle;
        }
        private void GreenScheme()
        {
            colorSchemeCB.SelectedIndex = 2;
            appBG.Color = Color.FromArgb(255, 110, 181, 130);
            Style greenTitle = Application.Current.Resources["DarkGreenTitle"] as Style;
            Title.Style = greenTitle;
            SoundTitle.Style = greenTitle;
            MetricTitle.Style = greenTitle;
        }
    }
}
