using DAL.DTO;

namespace DAL.Interfaces
{
    /// <summary>
    /// Represents Subject repository functionality.
    /// </summary>
    public interface ISubjectRepository : IRepository<DalSubject>
    {
        /// <summary>
        /// Adds new subject to data storage.
        /// </summary>
        /// <param name="subject"> Subject to add.</param>
        void Create(DalSubject subject);
    }
}
