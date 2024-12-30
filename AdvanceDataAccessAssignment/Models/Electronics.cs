namespace AdvanceDataAccessAssignment.Models
{
    /// <summary>
    /// Represents an electronic product in the system.
    /// Contains properties such as Id, Name, Description, Price, and Category for an electronic item.
    /// </summary>
    public class Electronics
    {
        /// <summary>
        /// Gets or sets the unique identifier for the electronics item.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the electronics item.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the electronics item.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the price of the electronics item.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the category of the electronics item.
        /// </summary>
        public string? Category { get; set; }
    }
}
