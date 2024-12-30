namespace MicroservicesAssignment.Models
{
    /// <summary>
    /// Represents the response containing a JWT token returned from the authentication API.
    /// </summary>
    public class TokenResponse
    {
        /// <summary>
        /// Gets or sets the JWT token used for authentication.
        /// </summary>
        public string? Token { get; set; }
    }
}
