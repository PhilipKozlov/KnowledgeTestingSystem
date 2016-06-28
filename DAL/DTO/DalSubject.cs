using DAL.Interfaces;

namespace DAL.DTO
{
    /// <summary>
    /// Represents test subject.
    /// </summary>
    public class DalSubject : IEntity
    {
        /// <summary>
        /// Gets or sets Subject identificator.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets Subject name.
        /// </summary>
        public string Name { get; set; }
    }
}
