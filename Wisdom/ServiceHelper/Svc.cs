using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wisdom.ServiceReference1;

namespace Wisdom.ServiceHelper
{
    public class Svc
    {
        public static string GetWeatherByName(string name)
        {
            WeatherWebServiceSoapClient c = new WeatherWebServiceSoapClient();
            var result = c.getWeatherbyCityName(name);
            return result[6] + " " + result[10];
        }
    }
}
