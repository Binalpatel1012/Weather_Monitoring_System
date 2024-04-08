using System;
using System.Collections.Generic;

namespace WeatherMonitoringLib
{
    /// <summary>
    /// Singleton class that acts as the subject in the Observer pattern, managing weather data.
    /// It collects weather data and notifies all registered observers when the data changes.
    /// </summary>
    public class WeatherData
    {
        private static WeatherData? instance;
        private List<IObserver> observers;
        private float temperature;
        private float humidity;
        private float pressure;

        /// <summary>
        /// Private constructor to prevent instance creation outside the class.
        /// Initializes the observer list.
        /// </summary>
        private WeatherData()
        {
            observers = new List<IObserver>();
        }

        /// <summary>
        /// Provides a global access point to the singleton instance of the WeatherData class.
        /// </summary>
        public static WeatherData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WeatherData();
                }
                return instance;
            }
        }

        /// <summary>
        /// Registers an observer to receive updates.
        /// </summary>
        /// <param name="observer">The observer to be added to the list.</param>
        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        /// <summary>
        /// Removes an observer from the list, ceasing its updates.
        /// </summary>
        /// <param name="observer">The observer to be removed from the list.</param>
        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        /// <summary>
        /// Notifies all registered observers by invoking their Update method with the latest measurements.
        /// </summary>
        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(temperature, humidity, pressure);
            }
        }

        /// <summary>
        /// Triggers an update in weather measurements. It's called after new data has been set.
        /// </summary>
        public void MeasurementsChanged()
        {
            NotifyObservers();
        }

        /// <summary>
        /// Sets new weather measurements and notifies observers of the change.
        /// </summary>
        /// <param name="temperature">The new temperature measurement.</param>
        /// <param name="humidity">The new humidity measurement.</param>
        /// <param name="pressure">The new atmospheric pressure measurement.</param>
        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            MeasurementsChanged();
        }
    }
}
