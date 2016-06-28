using System.Data.Entity.ModelConfiguration;

namespace ORM
{
    /// <summary>
    /// Represents Question entity configuration when mapping to database schema.
    /// </summary>
    public class QuestionConfiguration : EntityTypeConfiguration<Question>
    {
        /// <summary>
        /// Configures Question entity.
        /// </summary>
        public QuestionConfiguration()
        {
            HasKey(p => p.Id);
            Property(p => p.TestId).IsRequired();
            Property(p => p.QuestionText).IsRequired();
        }
    }
}
