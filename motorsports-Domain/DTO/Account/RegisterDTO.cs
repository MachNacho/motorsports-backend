using System.ComponentModel.DataAnnotations;

namespace motorsports_Domain.DTO.Account
{
    /// <summary>
    /// Data Transfer Object used for user registration.
    /// Contains all required information to create a new user account.
    /// </summary>
    public class RegisterDTO
    {
        /// <summary>
        /// The desired username for the new account.
        /// </summary>
        [Required]
        public string? Username { get; set; }

        /// <summary>
        /// The user's email address. Must be in a valid email format.
        /// </summary>
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        /// <summary>
        /// The password for the new user account.
        /// </summary>
        [Required]
        public string? Password { get; set; }

        /// <summary>
        /// The user's first name.
        /// </summary>
        [Required]
        public string? UserFirstName { get; set; }

        /// <summary>
        /// The user's last name.
        /// </summary>
        [Required]
        public string? UserLastName { get; set; }
    }
}
