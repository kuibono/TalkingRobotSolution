using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceHelper.Model;
using ServiceHelper.WeacherService;

namespace ServiceHelper
{
    public class ServiceHelper
    {
        public static WeatherInfo GetWeatherByName(string name)
        {
            WeacherService.WeatherWebServiceSoapClient client=new WeatherWebServiceSoapClient();
            var w=  client.getWeatherbyCityName(name);
            
            WeatherInfo result=new WeatherInfo();

            return result;
        }
    }
}
