using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models
{
    /// <summary>
    /// Represents user.
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// Gets or sets User identificator.
        /// </summary>
        public int Id { get; set; }
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
        /// Gets or sets User e-mail address.
        /// </summary>
        /// <summary>
        /// Gets or sets Role Name.
        /// </summary>
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid email.")]
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets User phone number.
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The password must contain at least {2} characters", MinimumLength = 8)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets user roles.
        /// </summary>
        [RequiredProperty("IsSelected", true, ErrorMessage = "User must be in at least one role!")]
        public ICollection<RoleViewModel> Roles { get; set; }
    }
}