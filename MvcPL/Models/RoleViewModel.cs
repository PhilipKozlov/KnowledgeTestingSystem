using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models
{
    /// <summary>
    /// Represents role.
    /// </summary>
    public class RoleViewModel
    {
        /// <summary>
        /// Gets or sets Role identificator.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets Role Name.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Role description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets weather the role was selected.
        /// </summary>
        public bool IsSelected { get; set; }
    }
}