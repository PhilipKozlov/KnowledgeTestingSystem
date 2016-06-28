using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Represents Subject functionality.
    /// </summary>
    public interface ISubjectService
    {
        /// <summary>
        /// Gets as single subject with given id.
        /// </summary>
        /// <param name="id"> Subject id.</param>
        /// <returns> Subject with given id.</returns>
        BllSubject GetSubject(int id);
        /// <summary>
        /// Gets all subjects.
        /// </summary>
        /// <returns> IEnumerable`1 of subjects.</returns>
        IEnumerable<BllSubject> GetAllSubjects();
    }
}
