namespace AdapterDesignPatternSample.Models
{
    /// <summary>
    /// Represents a customer with basic details such as ID, Name, and Address.
    /// </summary>
    public class Customers
    {
        /// <summary>
        /// Gets or sets the unique identifier for the customer.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the address of the customer.
        /// </summary>
        public string? Address { get; set; }
    }
}
