using WeatherMonitoringLib;
using WeatherMonitoringLib.Interfaces;

class Program
{
    static void Main(string[] args)
    {
        ISubject weatherData = WeatherData.Instance;
        
        var currentDisplay = WeatherStation.CreateDisplay("currentconditions", weatherData);
        var statsDisplay = WeatherStation.CreateDisplay("statistics", weatherData);
        var forecastDisplay = WeatherStation.CreateDisplay("forecast", weatherData);

        // Cast back to WeatherData to call SetMeasurements, since ISubject doesn't have this method
        if (weatherData is WeatherData concreteWeatherData)
        {
            concreteWeatherData.SetMeasurements(25.3f, 65f, 1013.1f);
            concreteWeatherData.SetMeasurements(24.7f, 70f, 1012.5f);
        }
    }
}
