namespace ObserverDesignPatternSample.Interfaces
{
    /// <summary>
    /// Defines the contract for an observer in the observer pattern.
    /// Observers are notified when there is an update from the subject (account).
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// Called to update the observer with new information from the subject.
        /// </summary>
        /// <param name="accountName">The name of the account that triggered the update.</param>
        /// <param name="message">The message or content associated with the update.</param>
        void Update(string accountName, string message);
    }
}
