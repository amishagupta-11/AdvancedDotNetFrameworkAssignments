using FactoryPatternSample.Interfaces;

namespace FactoryPatternSample.Services
{
    public class EmailNotification:INotification
    {
        public string Send(string message,string recipient)
        {
            return $"Email sent to {recipient} at {DateTime.Now}\nMessage:{message}";
        }
    }
}
