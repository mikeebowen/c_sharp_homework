using HelloWorld.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace HelloWorld
{
    public class WeatherService
    {
        private const string appId = "ba13addf5aea5b7a6ecd077819fc3cf0";

        public WeatherModel GetWeather()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/");

            var result = client.GetAsync(string.Format("weather?appId={0}&q={1}", appId, "seattle")).Result;

            var json = result.Content.ReadAsStringAsync().Result;

            var weatherModel = JsonConvert.DeserializeObject<WeatherModel>(json);

            return weatherModel;
        }
    }
}