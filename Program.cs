using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace WeatherAPI
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            Console.WriteLine("API Locator");

            WeatherRepo wRepo = new WeatherRepo();
            PointRoot pointInformation = await wRepo.WeatherPointInformation(client);

            Console.WriteLine("Forecast: " + pointInformation.Properties.Forecast);
            Console.WriteLine("Hourly Forecast: " + pointInformation.Properties.ForecastHourly);
            Console.WriteLine("Forecast Office:  " + pointInformation.Properties.ForecastOffice);
            Console.WriteLine("Forecast Zone:  " + pointInformation.Properties.ForecastZone);
            Console.WriteLine("City:  " + pointInformation.Properties.RelativeLocation.Properties2.City);
            Console.WriteLine("State:  " + pointInformation.Properties.RelativeLocation.Properties2.State);
            Console.WriteLine("Distance To Office:  " + pointInformation.Properties.RelativeLocation.Properties2.Distance.Value);
            Console.WriteLine("Distance Units:   " + pointInformation.Properties.RelativeLocation.Properties2.Distance.UnitCode);
        }        
    }
}
