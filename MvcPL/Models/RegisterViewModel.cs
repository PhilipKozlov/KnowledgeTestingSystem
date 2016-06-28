using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models
{
    /// <summary>
    /// Represents model for registration.
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// User Name.
        /// </summary>
        /// <summary>
        /// Gets or sets Role Name.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets User Last Name.
        /// </summary>
        /// <summary>
        /// Gets or sets Role Name.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets user email.
        /// </summary>
        [Display(Name = "Enter your e-mail")]
        [Required(ErrorMessage = "The field can not be empty!")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid email")]
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets user password.
        /// </summary>
        [Required(ErrorMessage = "Enter your password")]
        [StringLength(20, ErrorMessage = "The password must contain at least {2} characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Enter your password")]
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets user confirmed password.
        /// </summary>
        [Required(ErrorMessage = "Confirm the password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm the password")]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }
        /// <summary>
        /// Gets or sets Captcha string represented by Captcha image.
        /// </summary>
        [Required(ErrorMessage = "Wrong code, please try again.")]
        [Display(Name = "Enter the code from the image")]
        public string Captcha { get; set; }
    }
}