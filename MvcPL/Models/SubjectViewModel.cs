using System.ComponentModel.DataAnnotations;


namespace MvcPL.Models
{
    /// <summary>
    /// Represents test subject.
    /// </summary>
    public class SubjectViewModel
    {
        /// <summary>
        /// Gets or sets Subject identificator.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets Subject name.
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "Subject")]
        public string Name { get; set; }
    }
}