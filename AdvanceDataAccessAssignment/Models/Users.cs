using System.ComponentModel.DataAnnotations;

namespace AdvanceDataAccessAssignment.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string? UserName { get; set; }

        [Required]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Please enter a valid phone number.")]
        public string? PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string? ElectronicName { get; set; }       
    }
}
