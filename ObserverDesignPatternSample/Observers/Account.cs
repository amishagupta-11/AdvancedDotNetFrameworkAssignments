using ObserverDesignPatternSample.Interfaces;

namespace ObserverDesignPatternSample.Observers
{
    /// <summary>
    /// Represents a social media account in the observer pattern.
    /// The account can have followers (observers) who are notified when new posts are made.
    /// </summary>
    public class Account : ISubject
    {
        /// <summary>
        /// List of followers (observers) attached to the account.
        /// </summary>
        public readonly List<IObserver> _followers = new();

        /// <summary>
        /// The name of the account.
        /// </summary>
        public string? Name { get; }

        /// <summary>
        /// Initializes a new instance of the Account class with a given name.
        /// </summary>
        /// <param name="name">The name of the account.</param>
        public Account(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Attaches a new observer (follower) to the account.
        /// </summary>
        /// <param name="observer">The observer to attach.</param>
        public void Attach(IObserver observer)
        {
            _followers.Add(observer);
        }

        /// <summary>
        /// Detaches an observer (follower) from the account.
        /// </summary>
        /// <param name="observer">The observer to detach.</param>
        public void Detach(IObserver observer)
        {
            _followers.Remove(observer);
        }

        /// <summary>
        /// Notifies all attached observers with a message.
        /// </summary>
        /// <param name="message">The message to send to the observers.</param>
        public void Notify(string message)
        {
            foreach (var follower in _followers)
            {
                follower.Update(Name, message);
            }
        }

        /// <summary>
        /// Creates a new post and notifies followers about the post content.
        /// </summary>
        /// <param name="content">The content of the post.</param>
        public void Post(string content)
        {
            Notify($"New post: {content}");
        }
    }
}
