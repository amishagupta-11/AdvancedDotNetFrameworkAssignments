using FactoryPatternSample.Interfaces;

namespace FactoryPatternSample.Services
{
    public class SMSNotification:INotification
    {
        public string Send(string message, string recipient)
        {
            return $"SMS sent to {recipient} at {DateTime.Now}\nMessage: {message}";
        }
    }
}
