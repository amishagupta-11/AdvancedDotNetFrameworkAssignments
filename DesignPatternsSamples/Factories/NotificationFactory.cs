using FactoryPatternSample.Interfaces;
using FactoryPatternSample.Services;

namespace FactoryPatternSample.Factories
{
    /// <summary>
    /// A factory class that provides the appropriate notification service based on the given type.
    /// </summary>
    public static class NotificationFactory
    {
        /// <summary>
        /// Returns an instance of the appropriate notification service based on the provided type.
        /// </summary>
        /// <param name="type">The type of notification (e.g., "email" or "sms").</param>
        /// <returns>An implementation of the INotification interface for the specified notification type.</returns>
        /// <exception cref="ArgumentException">Thrown when an invalid notification type is provided.</exception>
        public static INotification GetNotification(string type)
        {
            return type.ToLower() switch
            {
                // Returns email notification service
                "email" => new EmailNotification(),
                // Returns SMS notification service
                "sms" => new SMSNotification(),
                // Throws exception for invalid type
                _ => throw new ArgumentException("Invalid notification type"),
            };
        }
    }
}
