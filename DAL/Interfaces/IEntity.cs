namespace DAL.Interfaces
{
    /// <summary>
    /// Represents common functionality for all DAL entities.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets entity identificator.
        /// </summary>
        int Id { get; set; }
    }
}
