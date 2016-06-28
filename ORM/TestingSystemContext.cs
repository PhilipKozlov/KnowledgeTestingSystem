using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ORM
{
    /// <summary>
    /// Represents database context.
    /// </summary>
    public class TestingSystemContext : DbContext
    {
        /// <summary>
        /// Instanciates TestingSystemContext
        /// </summary>
        public TestingSystemContext() : base("name = TestingSystem")
        {
        }

        /// <summary>
        /// Gets or sets user roles.
        /// </summary>
        public virtual DbSet<Role> Roles { get; set; }
        /// <summary>
        /// Gets or sets users.
        /// </summary>
        public virtual DbSet<User> Users { get; set; }
        /// <summary>
        /// Gets or sets tests.
        /// </summary>
        public virtual DbSet<Test> Test { get; set; }
        /// <summary>
        /// Gets or sets subjects.
        /// </summary>
        public virtual DbSet<Subject> Subjects { get; set; }
        /// <summary>
        /// Gets or sets questions.
        /// </summary>
        public virtual DbSet<Question> Questions { get; set; }
        /// <summary>
        /// Gets or sets answers.
        /// </summary>
        public virtual DbSet<Answer> Answers { get; set; }
        /// <summary>
        /// Gets or sets test results.
        /// </summary>
        public virtual DbSet<TestResult> TestResults { get; set; }

        /// <summary>
        /// Adds requirements for entities when mapping to database schema.
        /// </summary>
        /// <param name="modelBuilder"> DbModelBuilder object used to map CLR classes to database schema.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new SubjectConfiguration());
            modelBuilder.Configurations.Add(new TestConfiguration());
            modelBuilder.Configurations.Add(new QuestionConfiguration());
            modelBuilder.Configurations.Add(new AnswerConfiguration());
            modelBuilder.Configurations.Add(new TestResultConfiguration());
        }
    }
}
