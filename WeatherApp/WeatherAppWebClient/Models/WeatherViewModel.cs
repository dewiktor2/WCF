using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherAppWebClient.Models
{
    public class WeatherViewModel
    {
        public Weather WebAppWeather { get; set; }
        public WeatherAppServices.Weather ServiceWeather { get; set; }
    }
}