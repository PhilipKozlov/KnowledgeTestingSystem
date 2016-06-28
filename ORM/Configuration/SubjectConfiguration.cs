using System.Data.Entity.ModelConfiguration;

namespace ORM
{
    /// <summary>
    /// Represents Subject entity configuration when mapping to database schema.
    /// </summary>
    public class SubjectConfiguration : EntityTypeConfiguration<Subject>
    {
        /// <summary>
        /// Configures Subject entity.
        /// </summary>
        public SubjectConfiguration()
        {
            HasKey(p => p.Id);
            Property(p => p.Name).HasMaxLength(100).IsRequired();
        }
    }
}
