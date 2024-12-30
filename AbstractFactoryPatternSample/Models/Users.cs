namespace AbstractFactoryPatternSample.Models
{
    /// <summary>
    /// Represents a user with an Id, Name, and Role.
    /// </summary>
    public class Users
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the role of the user (e.g., Admin, User).
        /// </summary>
        public string? Role { get; set; }
    }
}
