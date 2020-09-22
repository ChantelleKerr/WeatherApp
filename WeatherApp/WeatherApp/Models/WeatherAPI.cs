using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class WeatherAPI
    {
        public string responseString, forecastResponseString;
        private string API_KEY = "YOUR_KEY";

        // Get Current Weather from API
        public async Task<string> GetCurrentWeatherAPI(string cityName, string unit)
        {
            // Creats a HTTPClient class
            var client = new HttpClient();
            // Uses HTTPClient to make the request
            var response = await client.GetAsync("https://api.openweathermap.org/data/2.5/weather?q=" + cityName + ",au&units=" + unit + "&appid=" + API_KEY);
            // retrieves whatever it was we downloaded as a string
            responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }
        public async Task<string> GetForecastAPI(string cityName, string unit)
        {
            // Creats a HTTPClient class
            var client = new HttpClient();
            // Uses HTTPClient to make the request
            var response = await client.GetAsync("https://api.openweathermap.org/data/2.5/forecast?q=" + cityName + ",au&units=" + unit + "&appid=" + API_KEY + "&cnt=7");
            // retrieves whatever it was we downloaded as a string
            forecastResponseString = await response.Content.ReadAsStringAsync();
            return forecastResponseString;
        }
    }
}
