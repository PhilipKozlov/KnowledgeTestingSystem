using System.Data.Entity.ModelConfiguration;

namespace ORM
{
    /// <summary>
    /// Represents Answer entity configuration when mapping to database schema.
    /// </summary>
    public class AnswerConfiguration : EntityTypeConfiguration<Answer>
    {
        /// <summary>
        /// Configures Answer entity.
        /// </summary>
        public AnswerConfiguration()
        {
            HasKey(p => p.Id);
            Property(p => p.IsCorrect).IsRequired();
            Property(p => p.QuestionId).IsRequired();
            Property(p => p.AnswerText).IsRequired();
        }
    }
}
