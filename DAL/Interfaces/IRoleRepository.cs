using DAL.DTO;

namespace DAL.Interfaces
{
    /// <summary>
    /// Represents Role repository functionality.
    /// </summary>
    public interface IRoleRepository : IRepository<DalRole>
    {
        /// <summary>
        /// Adds new role to data storage.
        /// </summary>
        /// <param name="role"> Role to add.</param>
        void Create(DalRole role);
    }
}
