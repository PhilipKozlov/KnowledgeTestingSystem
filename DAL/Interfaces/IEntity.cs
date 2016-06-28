using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
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
