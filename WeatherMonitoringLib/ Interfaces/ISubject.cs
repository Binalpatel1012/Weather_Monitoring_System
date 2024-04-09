namespace WeatherMonitoringLib.Interfaces
{
    /// <summary>
    /// Interface for the subject part of the Observer pattern. 
    /// This interface defines methods for registering, removing, and notifying observers.
    /// </summary>
    public interface ISubject
    {
        /// <summary>
        /// Registers an observer to receive updates.
        /// </summary>
        /// <param name="observer">The observer to register.</param>
        void RegisterObserver(IObserver observer);

        /// <summary>
        /// Removes an observer from the notification list.
        /// </summary>
        /// <param name="observer">The observer to remove.</param>
        void RemoveObserver(IObserver observer);

        /// <summary>
        /// Notifies all registered observers of a change.
        /// </summary>
        void NotifyObservers();
    }
}
