using System;
using System.Collections.Generic;

namespace WeatherMonitoringLib
{
    /// <summary>
    /// Displays statistical information about weather data.
    /// </summary>
    public class StatisticsDisplay : IObserver, IDisplay
    {
        private List<float> temperatures;
        private WeatherData weatherData;

        public StatisticsDisplay(WeatherData weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
            temperatures = new List<float>();
        }

        public void Update(float temperature, float humidity, float pressure)
        {
            temperatures.Add(temperature);
            Display();
        }

        public void Display()
        {
            float maxTemp = temperatures.Count > 0 ? temperatures.Max() : 0;
            float minTemp = temperatures.Count > 0 ? temperatures.Min() : 0;
            float avgTemp = temperatures.Count > 0 ? temperatures.Average() : 0;

            Console.WriteLine($"Avg/Max/Min temperature = {avgTemp:0.##}/{maxTemp:0.##}/{minTemp:0.##}");
        }
    }
}
