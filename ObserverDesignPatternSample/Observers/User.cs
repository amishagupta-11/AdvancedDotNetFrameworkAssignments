using ObserverDesignPatternSample.Interfaces;

namespace ObserverDesignPatternSample.Observers
{
    /// <summary>
    /// Represents a user who follows a social media account and receives notifications
    /// about new posts from the accounts they follow.
    /// </summary>
    public class User : IObserver
    {
        /// <summary>
        /// The name of the user.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of the User class with a given name.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        public User(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Receives notifications when a followed account posts new content.
        /// </summary>
        /// <param name="accountName">The name of the account that made the post.</param>
        /// <param name="message">The content of the post being notified.</param>
        public void Update(string accountName, string message)
        {
            Console.WriteLine($"[{Name}] Notification from {accountName}: {message}");
        }
    }
}
