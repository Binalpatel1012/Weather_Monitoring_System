using System; 

namespace WeatherMonitoringLib
{
    public class WeatherStation
    {
        public static IDisplay CreateDisplay(string type)
        {
            switch (type.ToLower()) 
            {
                case "currentconditions":
                    return new CurrentConditionsDisplay(WeatherData.Instance);
                case "statistics":
                    return new StatisticsDisplay(WeatherData.Instance);
                case "forecast":
                    return new ForecastDisplay(WeatherData.Instance);
                default:
                    throw new ArgumentException($"Unknown display type: {type}");
            }
        }

    }
}
