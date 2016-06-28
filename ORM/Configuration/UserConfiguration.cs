using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace ORM
{
    /// <summary>
    /// Represents User entity configuration when mapping to database schema.
    /// </summary>
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        /// <summary>
        /// Configures User entity.
        /// </summary>
        public UserConfiguration()
        {
            HasKey(p => p.Id);
            Property(p => p.Name).IsRequired().HasMaxLength(100);
            Property(p => p.LastName).IsRequired().HasMaxLength(100);
            Property(p => p.Email).IsRequired().HasMaxLength(100);
            Property(p => p.Password).IsRequired();
        }
    }
}
