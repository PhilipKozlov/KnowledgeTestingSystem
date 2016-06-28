using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Represents Test repository functionality.
    /// </summary>
    public interface ITestRepository : IRepository<DalTest>
    {
        /// <summary>
        /// Adds new test to data storage.
        /// </summary>
        /// <param name="test"> Test to add.</param>
        void Create(DalTest test);
        /// <summary>
        /// Removes test from data storage.
        /// </summary>
        /// <param name="test"> Test to remove.</param>
        void Delete(DalTest test);
        /// <summary>
        /// Updates test in data storage.
        /// </summary>
        /// <param name="test"> Test to update.</param>
        void Update(DalTest test);
    }
}
