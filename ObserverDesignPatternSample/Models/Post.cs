namespace ObserverDesignPatternSample.Models
{
    /// <summary>
    /// Represents a post made by a user on a social media account.
    /// Contains the account name and the content of the post.
    /// </summary>
    public class Post
    {
        /// <summary>
        /// Gets or sets the name of the account making the post.
        /// </summary>
        public string? AccountName { get; set; }

        /// <summary>
        /// Gets or sets the content of the post.
        /// </summary>
        public string? Content { get; set; }
    }
}
