using System;
using System.Collections.Generic;
using System.Linq; // Needed for LINQ operations Max, Min, and Average
using WeatherMonitoringLib.Interfaces;

namespace WeatherMonitoringLib
{
    /// <summary>
    /// Displays statistical information about weather data.
    /// </summary>
    public class StatisticsDisplay : IObserver, IDisplay
    {
        private List<float> temperatures;
        private ISubject weatherData;

        /// <summary>
        /// Initializes a new instance of the StatisticsDisplay class.
        /// </summary>
        /// <param name="weatherData">The weather data subject to observe.</param>
        public StatisticsDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
            temperatures = new List<float>();
        }

        /// <summary>
        /// Updates the display with the latest temperature data.
        /// </summary>
        /// <param name="temperature">The current temperature.</param>
        /// <param name="humidity">The current humidity, not used in this display.</param>
        /// <param name="pressure">The current atmospheric pressure, not used in this display.</param>
        public void Update(float temperature, float humidity, float pressure)
        {
            temperatures.Add(temperature);
            Display();
        }

        /// <summary>
        /// Displays the average, maximum, and minimum recorded temperatures.
        /// </summary>
        public void Display()
        {
            float maxTemp = temperatures.Count > 0 ? temperatures.Max() : 0;
            float minTemp = temperatures.Count > 0 ? temperatures.Min() : 0;
            float avgTemp = temperatures.Count > 0 ? temperatures.Average() : 0;

            Console.WriteLine($"Avg/Max/Min temperature = {avgTemp:0.##}/{maxTemp:0.##}/{minTemp:0.##}");
        }
    }
}
