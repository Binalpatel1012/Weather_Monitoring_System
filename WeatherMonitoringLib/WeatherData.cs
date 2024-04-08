using System;
using System.Collections.Generic;

namespace WeatherMonitoringLib
{
    /// <summary>
    /// Singleton class that represents weather data.
    /// </summary>
    public class WeatherData
    {
        private static WeatherData instance;
        private List<IObserver> observers;
        private float temperature;
        private float humidity;
        private float pressure;

        private WeatherData()
        {
            observers = new List<IObserver>();
        }

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

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(temperature, humidity, pressure);
            }
        }

        public void MeasurementsChanged()
        {
            NotifyObservers();
        }

        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            MeasurementsChanged();
        }
    }
}
