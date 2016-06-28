using System.Collections.Generic;

namespace BLL.DTO
{
    /// <summary>
    /// Represents User entity.
    /// </summary>
    public class BllUser 
    {
        /// <summary>
        /// Gets or sets User identificator.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// User Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets User Last Name.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets User e-mail address.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets User phone number.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets user roles.
        /// </summary>
        public ICollection<BllRole> Roles { get; set; }
    }
}
