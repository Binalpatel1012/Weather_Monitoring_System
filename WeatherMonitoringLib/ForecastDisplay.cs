using System;
using WeatherMonitoringLib.Interfaces;

namespace WeatherMonitoringLib
{
    /// <summary>
    /// Displays a weather forecast based on pressure changes.
    /// </summary>
    public class ForecastDisplay : IObserver, IDisplay
    {
        private float currentPressure = 1013f; 
        private float lastPressure;
        private readonly ISubject weatherData; 

        /// <summary>
        /// Initializes a new instance of the ForecastDisplay class.
        /// </summary>
        /// <param name="weatherData">The weather data to observe.</param>
        public ForecastDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }

        /// <summary>
        /// Updates the display with the latest measurements.
        /// </summary>
        /// <param name="temperature">The temperature measurement.</param>
        /// <param name="humidity">The humidity measurement.</param>
        /// <param name="pressure">The pressure measurement.</param>
        public void Update(float temperature, float humidity, float pressure)
        {
            lastPressure = currentPressure;
            currentPressure = pressure;
            Display();
        }

        /// <summary>
        /// Displays the latest forecast based on pressure changes.
        /// </summary>
        public void Display()
        {
            string forecast = "Forecast: ";
            if (currentPressure > lastPressure)
            {
                forecast += "Improving weather on the way!";
            }
            else if (currentPressure == lastPressure)
            {
                forecast += "More of the same.";
            }
            else if (currentPressure < lastPressure)
            {
                forecast += "Watch out for cooler, rainy weather.";
            }

            Console.WriteLine(forecast);
        }
    }
}
