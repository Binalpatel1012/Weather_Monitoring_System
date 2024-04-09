using System;
using WeatherMonitoringLib.Interfaces;

namespace WeatherMonitoringLib
{
    /// <summary>
    /// Displays current conditions. Acts as both an observer and a decorator to add additional info like date and time.
    /// </summary>
    public class CurrentConditionsDisplay : IObserver, IDisplay
    {
        private float temperature;
        private float humidity;
        private ISubject weatherData;

        /// <summary>
        /// Initializes a new instance of the CurrentConditionsDisplay class, registering it as an observer of the specified WeatherData.
        /// </summary>
        /// <param name="weatherData">The ISubject object (WeatherData) to observe.</param>
        public CurrentConditionsDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            this.weatherData.RegisterObserver(this);
        }

        /// <summary>
        /// Updates the display with the latest weather conditions. This method is called whenever the observed WeatherData updates its measurements.
        /// </summary>
        /// <param name="temperature">The current temperature.</param>
        /// <param name="humidity">The current humidity.</param>
        /// <param name="pressure">The current atmospheric pressure. This parameter is not displayed but is required by the IObserver interface.</param>
        public void Update(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            Display();
        }

        /// <summary>
        /// Displays the latest weather conditions along with the current date and time.
        /// </summary>
        public void Display()
        {
            Console.WriteLine($"Current conditions: {temperature}°C and {humidity}% humidity. " +
                              $"Time: {DateTime.Now.ToString("T")}");
        }
    }
}
