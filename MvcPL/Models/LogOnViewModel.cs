using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models
{
    /// <summary>
    /// Represents model for logging in.
    /// </summary>
    public class LogOnViewModel
    {
        /// <summary>
        /// Gets or sets user email.
        /// </summary>
        [Required]
        [Display(Name = "Enter your e-mail")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets user password.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Enter your password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets weather to create persistent cookie.
        /// </summary>
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}