using System;
using WeatherMonitoringLib.Interfaces;

namespace WeatherMonitoringLib
{
    public static class WeatherStation
    {
        
        public static IDisplay CreateDisplay(string type, ISubject weatherData)
        {
            switch (type.ToLower())
            {
                case "currentconditions":
                    return new CurrentConditionsDisplay(weatherData);
                case "statistics":
                    return new StatisticsDisplay(weatherData);
                case "forecast":
                    return new ForecastDisplay(weatherData);
                default:
                    throw new ArgumentException($"Unknown display type: {type}");
            }
        }

    }
}
