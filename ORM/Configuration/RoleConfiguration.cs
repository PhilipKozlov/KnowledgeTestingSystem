using System.Data.Entity.ModelConfiguration;

namespace ORM
{
    /// <summary>
    /// Represents Role entity configuration when mapping to database schema.
    /// </summary>
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        /// <summary>
        /// Configures Role entity.
        /// </summary>
        public RoleConfiguration()
        {
            HasKey(p => p.Id);
            Property(p => p.Name).IsRequired().HasMaxLength(100);
        }
    }
}
