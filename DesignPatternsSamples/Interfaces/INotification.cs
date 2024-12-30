namespace FactoryPatternSample.Interfaces
{
    /// <summary>
    /// Defines the contract for a notification service that sends messages to recipients.
    /// </summary>
    public interface INotification
    {
        /// <summary>
        /// Sends a notification message to the specified recipient.
        /// </summary>
        /// <param name="message">The content of the notification message.</param>
        /// <param name="recipient">The recipient of the notification.</param>
        /// <returns>A string indicating the result of the send operation.</returns>
        public string Send(string message, string recipient);
    }
}
