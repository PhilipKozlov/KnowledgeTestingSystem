using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
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
