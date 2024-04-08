using System;

namespace WeatherMonitoringLib
{
    /// <summary>
    /// Displays a weather forecast based on pressure changes.
    /// </summary>
    public class ForecastDisplay : IObserver, IDisplay
    {
        private float currentPressure = 1013f; // Average sea-level pressure in hPa
        private float lastPressure;
        private WeatherData weatherData;

        public ForecastDisplay(WeatherData weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }

        public void Update(float temperature, float humidity, float pressure)
        {
            lastPressure = currentPressure;
            currentPressure = pressure;
            Display();
        }

        public void Display()
        {
            string forecast = "Forecast: ";
            if (currentPressure > lastPressure)
            {
                forecast += "Improving weather on the way!";
            }
            else if (currentPressure == lastPressure)
            {
                forecast += "More of the same";
            }
            else if (currentPressure < lastPressure)
            {
                forecast += "Watch out for cooler, rainy weather";
            }

            Console.WriteLine(forecast);
        }
    }
}
