using System.Data.Entity.ModelConfiguration;

namespace ORM
{
    /// <summary>
    /// Represents TestResult entity configuration when mapping to database schema.
    /// </summary>
    public class TestResultConfiguration : EntityTypeConfiguration<TestResult>
    {
        /// <summary>
        /// Configures TestResult entity.
        /// </summary>
        public TestResultConfiguration()
        {
            HasKey(p => p.Id);
            Property(p => p.DateTime).HasColumnType("datetime2").IsRequired();
            Property(p => p.Grade).IsRequired();
            Property(p => p.TimeSpent).IsRequired();

        }
    }
}
