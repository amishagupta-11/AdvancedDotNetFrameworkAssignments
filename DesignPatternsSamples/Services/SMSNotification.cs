using FactoryPatternSample.Interfaces;

namespace FactoryPatternSample.Services
{
    /// <summary>
    /// An implementation of the INotification interface for sending SMS notifications.
    /// </summary>
    public class SMSNotification : INotification
    {
        /// <summary>
        /// Sends an SMS notification to the specified recipient with the provided message.
        /// </summary>
        /// <param name="message">The content of the SMS message.</param>
        /// <param name="recipient">The phone number of the recipient.</param>
        /// <returns>A string indicating that the SMS was sent, including the recipient and message.</returns>
        public string Send(string message, string recipient)
        {
            return $"SMS sent to {recipient} at {DateTime.Now}\nMessage: {message}";
        }
    }
}
