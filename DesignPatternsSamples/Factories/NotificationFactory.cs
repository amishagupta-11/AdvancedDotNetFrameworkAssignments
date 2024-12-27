using FactoryPatternSample.Interfaces;
using FactoryPatternSample.Services;

namespace FactoryPatternSample.Factories
{
    public static class NotificationFactory
    {
        public static INotification GetNotification(string type)
        {
            return type.ToLower() switch
            {
                "email" => new EmailNotification(),
                "sms" => new SMSNotification(),
                _ => throw new ArgumentException("Invalid notification type"),
            };
        }
    }
}
