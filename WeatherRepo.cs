using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace WeatherAPI

{
    public class WeatherRepo
    {   
        public WeatherRepo()
        {

        }

        //Get information about a point such as city, state, distance to station, station,
        //radar station, forecast zone, etc.
        internal async Task<PointRoot> WeatherPointInformation(HttpClient weatherClient)
        {
            weatherClient.DefaultRequestHeaders.Accept.Clear();
            weatherClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/geo+json")
                );
            weatherClient.DefaultRequestHeaders.Add("User-Agent", ".net appliation development");

            //Serializes JSON response classes found in Point.cs
            var streamTask = weatherClient.GetStreamAsync("https://api.weather.gov/points/37.7938,-87.6940");
            var weatherPointInfo = await JsonSerializer.DeserializeAsync<PointRoot>(await streamTask);

            return weatherPointInfo;
/*
            //Returns String
            var stringTask = weatherClient.GetStringAsync("https://api.weather.gov/points/37.7938,-87.6940");

            var msg = await stringTask;
            return msg;
*/
        }

        internal async Task<string> WeatherPointInformation(HttpClient weatherClient, double latitude, double longitude)
        {
            weatherClient.DefaultRequestHeaders.Accept.Clear();
            weatherClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/geo+json") //Accept type defined in specification
                );
            weatherClient.DefaultRequestHeaders.Add("User-Agent", ".net appliation development");

            //build string to pass for api.weather.gov
            //see https://www.weather.gov/documentation/services-web-api#/default/get_points__point_

            string pointInfoWeb = "https://api.weather.gov/points/" + latitude.ToString() + "," + longitude.ToString();

            var stringTask = weatherClient.GetStringAsync(pointInfoWeb);

            var msg = await stringTask;

            return msg;
        }
    }
}
