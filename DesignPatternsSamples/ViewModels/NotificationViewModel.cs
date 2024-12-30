namespace FactoryPatternSample.ViewModels
{
    /// <summary>
    /// Represents the view model for sending notifications, including the type, message, recipient, and result.
    /// </summary>
    public class NotificationViewModel
    {
        /// <summary>
        /// Gets or sets the type of the notification (e.g., Email, SMS).
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        /// Gets or sets the content of the notification message.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Gets or sets the result of the notification send operation.
        /// </summary>
        public string? Result { get; set; }

        /// <summary>
        /// Gets or sets the recipient of the notification.
        /// </summary>
        public string? Recipient { get; set; }
    }
}
