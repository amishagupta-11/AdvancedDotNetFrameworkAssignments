using FactoryPatternSample.Interfaces;

namespace FactoryPatternSample.Services
{
    /// <summary>
    /// An implementation of the INotification interface for sending email notifications.
    /// </summary>
    public class EmailNotification : INotification
    {
        /// <summary>
        /// Sends an email notification to the specified recipient with the provided message.
        /// </summary>
        /// <param name="message">The content of the email message.</param>
        /// <param name="recipient">The email address of the recipient.</param>
        /// <returns>A string indicating that the email was sent, including the recipient and message.</returns>
        public string Send(string message, string recipient)
        {
            return $"Email sent to {recipient} at {DateTime.Now}\nMessage: {message}";
        }
    }
}
