using EO.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Models
{
    public class WeatherModel
    {
        [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
        public class Coord
        {
            public double lon { get; set; }
            public double lat { get; set; }

        }
        [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
        public class Weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }

        }
        [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
        public class Main
        {
            public double temp { get; set; }
            public double feels_like { get; set; }
            public double temp_min { get; set; }
            public int temp_max { get; set; }
            public int pressure { get; set; }
            public int humidity { get; set; }

        }
        [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
        public class Wind
        {
            public double speed { get; set; }
            public int deg { get; set; }

        }
        public class Rain
        {
            //public double 1h { get; set; }

    }
        [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
        public class Clouds
        {
            public int all { get; set; }

        }
        [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
        public class Sys
        {
            public int type { get; set; }
            public int id { get; set; }
            public string country { get; set; }
            public int sunrise { get; set; }
            public int sunset { get; set; }

        }
        [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
        public class Application
        {
            public Coord coord { get; set; }
            public IList<Weather> weather { get; set; }
            public Main main { get; set; }
            public int visibility { get; set; }
            public Wind wind { get; set; }
            public Rain rain { get; set; }
            public Clouds clouds { get; set; }
            public int dt { get; set; }
            public Sys sys { get; set; }
            public int timezone { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public int cod { get; set; }

        }
    }
}
