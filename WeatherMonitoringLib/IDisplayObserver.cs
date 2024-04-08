namespace WeatherMonitoringLib
{
    /// <summary>
    /// Interface for display elements.
    /// </summary>
    public interface IDisplay
    {
        void Display();
    }

    /// <summary>
    /// Observer interface for receiving weather updates.
    /// </summary>
    public interface IObserver
    {
        void Update(float temperature, float humidity, float pressure);
    }
}
