namespace WeatherMonitoringLib.Interfaces
{
    /// <summary>
    /// Observer interface for receiving weather updates.
    /// </summary>
    public interface IObserver
    {
        void Update(float temperature, float humidity, float pressure);
    }
}
