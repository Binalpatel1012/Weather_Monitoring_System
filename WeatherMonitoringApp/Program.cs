using WeatherMonitoringLib;

class Program
{
    static void Main(string[] args)
    {
        WeatherData weatherData = WeatherData.Instance;
        
        var currentDisplay = WeatherStation.CreateDisplay("currentconditions") as IDisplay;
        var statsDisplay = WeatherStation.CreateDisplay("statistics") as IDisplay;
        var forecastDisplay = WeatherStation.CreateDisplay("forecast") as IDisplay;

        
        weatherData.SetMeasurements(25.3f, 65f, 1013.1f);
}
