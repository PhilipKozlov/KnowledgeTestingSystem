using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
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
