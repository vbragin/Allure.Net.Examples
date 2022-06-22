using System;
using Newtonsoft.Json;

namespace Allure.Net.Examples.xUnit.Tests.Library.Models
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public  int TemperatureC { get; set; }

        public  int TemperatureF { get; set; }
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}