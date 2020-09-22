using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace WeatherApp
{
    public sealed class LoggingService
    {
        private static LoggingService instance = null;
        private StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

        private LoggingService()
        {
            
        }

        public static LoggingService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoggingService();
                }
                return instance;
            }
        }

        // log the given text as a warning
        public void LogSuccess(DateTime date, string message)
        {
            string error = "***** SUCCESS: ";
            error += message;
            SaveErrorToFile(date + " " + error);
        }
        // log the given text as an error and quit the app
        public void LogCatastrophicError(DateTime date, string message)
        {
            string error = "***** Catastrophic Error: ";
            error += message;
            SaveErrorToFile(date + " " + error);
        }

        // log the given text as an error
        public void LogError(DateTime date, string message)
        {
            string error = "***** Error: ";
            error += message;
            SaveErrorToFile(date + " " + error);

        }
        // log the given text as a warning
        public void LogWarning(DateTime date, string message)
        {
            string error = "***** Warning: ";
            error += message;
            SaveErrorToFile(date + " " + error);
        }

        // Save all errors to a file
        public async void SaveErrorToFile(string error)
        {
            StorageFile file = await storageFolder.CreateFileAsync("weather_app_logs.txt", CreationCollisionOption.OpenIfExists);
            await FileIO.AppendTextAsync(file, error + "\n");
        }
    }
}
