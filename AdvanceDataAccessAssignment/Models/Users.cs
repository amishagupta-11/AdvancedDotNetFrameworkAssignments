using System.ComponentModel.DataAnnotations;

namespace AdvanceDataAccessAssignment.Models
{
    /// <summary>
    /// Represents a user in the system.
    /// Contains properties for UserId, UserName, PhoneNumber, EmailAddress, and the user's preferred electronic item.
    /// </summary>
    public class Users
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        [Key]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// The username is required and cannot exceed 100 characters.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string? UserName { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the user.
        /// The phone number is required and must be in a valid international format (with optional leading '+').
        /// </summary>
        [Required]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Please enter a valid phone number.")]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string? EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the name of the electronics item associated with the user.
        /// </summary>
        public string? ElectronicName { get; set; }
    }
}
