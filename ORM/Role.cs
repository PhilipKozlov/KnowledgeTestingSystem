using System.Collections.Generic;

namespace ORM
{
    /// <summary>
    /// Represents user role.
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Gets or sets Role identificator.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets Role Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Role description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets Users In Role.
        /// </summary>
        public virtual ICollection<User> Users { get; set; }
    }
}
