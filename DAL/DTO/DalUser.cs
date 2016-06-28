using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Represents User entity.
    /// </summary>
    public class DalUser : IEntity
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
        /// Gets or sets User password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets user roles.
        /// </summary>
        public ICollection<DalRole> Roles { get; set; }
    }
}
