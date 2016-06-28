using ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Mappers;
using DAL.Interfaces;
using DAL.DTO;

namespace DAL.Concrete
{
    /// <summary>
    /// Represents test repository.
    /// </summary>
    public class TestRepository : ITestRepository
    {
        #region Fields
        private readonly Repository<Test> repository;
        private readonly DbContext context;
        #endregion

        #region Constructors
        /// <summary>
        /// Instanciates Repository with specified parameters.
        /// </summary>
        /// <param name="context"> Data base context.</param>
        /// <exception> System.ArgumentNullException if context is null.</exception>
        public TestRepository(DbContext context)
        {
            repository = new Repository<Test>(context);
            this.context = context;
        }
        #endregion

        #region IRepository Methods
        /// <summary>
        /// Adds new test to data storage.
        /// </summary>
        /// <param name="test"> Test to add.</param>
        /// <exception> System.ArgumentNullException if test is null.</exception>
        public void Create(DalTest test) => repository.Create(test?.ToTest());

        /// <summary>
        /// Removes test from data storage.
        /// </summary>
        /// <param name="test"> Test to remove.</param>
        /// <exception> System.ArgumentNullException if test is null.</exception>
        public void Delete(DalTest test) => repository.Delete(test?.ToTest());

        /// <summary>
        /// Gets all tests.
        /// </summary>
        /// <returns> IEnumerable`1 of tests.</returns>
        public IEnumerable<DalTest> GetAll() => repository.GetAll().Select(u => u.ToDalTest());

        /// <summary>
        /// Gets a single test with given id.
        /// </summary>
        /// <param name="key"> Test id.</param>
        /// <returns> Test with given id.</returns>
        public DalTest GetById(int key) => repository.GetById(key)?.ToDalTest();

        /// <summary>
        /// Gets all tests that satisfy the predicate.
        /// </summary>
        /// <param name="filter"> Predicate by wich tests must be filtered.</param>
        /// <returns> IEnumerable`1 of tests.</returns>
        public IEnumerable<DalTest> GetByPredicate(Expression<Func<DalTest, bool>> filter) => repository.GetByPredicate(filter?.Convert<DalTest, Test>()).Select(u => u.ToDalTest());

        /// <summary>
        /// Updates test in data storage.
        /// </summary>
        /// <param name="test"> Test to update.</param>
        /// <exception> System.ArgumentNullException if test is null.</exception>
        public void Update(DalTest test)
        {
            if (test == null) throw new ArgumentNullException(nameof(test));

            var dbTest = context.Set<Test>().Find(test.Id);
            var testQuestions = dbTest.Questions.ToList();

            context.Entry(dbTest).CurrentValues.SetValues(test);

            foreach (var testQuestion in testQuestions)
            {
                var question = test.Questions?.SingleOrDefault(q => q.Id == testQuestion.Id);
                if (question != null)
                    context.Entry(testQuestion).CurrentValues.SetValues(question);
                else
                {
                    context.Set<Question>().Remove(testQuestion);
                }

                var dbQuestion = context.Set<Question>().Find(testQuestion.Id);
                var questionAnswers = dbQuestion?.Answers.ToList();

                foreach (var questionAnswer in questionAnswers)
                {
                    var answer = question.Answers?.SingleOrDefault(a => a.Id == questionAnswer.Id);
                    if (answer != null)
                        context.Entry(questionAnswer).CurrentValues.SetValues(answer);
                    else
                        context.Set<Answer>().Remove(questionAnswer);
                }
            }

            foreach (var question in test.Questions)
            {
                if (!testQuestions.Any(q => q.Id == question.Id))
                    dbTest.Questions.Add(question.ToQuestion());
                else
                {
                    foreach (var answer in question.Answers)
                    {
                        if (!testQuestions.SingleOrDefault(q => q.Id == question.Id).Answers.Any(a => a.Id == answer.Id))
                            dbTest.Questions.SingleOrDefault(q => q.Id == question.Id).Answers.Add(answer.ToAnswer());
                    }
                }
            }
        }

        /// <summary>
        /// Free up unmanaged resources.
        /// </summary>
        public void Dispose() => repository.Dispose();
        #endregion
    }
}
