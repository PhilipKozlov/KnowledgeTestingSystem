using MvcPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.Interfaces;
using MvcPL.Infrastructure.Mappers;

namespace MvcPL.Controllers
{
    /// <summary>
    /// Provides methods that respond to HTTP requests for testing.
    /// </summary>
    [Authorize]
    public class TestingController : Controller
    {
        #region Fields
        private readonly IUserService userService;
        private readonly ITestEvaluationService testEvalService;
        #endregion

        #region Constructors
        /// <summary>
        /// Instanciates TestingController with specified parameters.
        /// </summary>
        /// <param name="userService"> UserService instance.</param>
        /// <param name="testEvalService"> TestEvaluationService instance.</param>
        public TestingController(IUserService userService, ITestEvaluationService testEvalService)
        {
            this.userService = userService;
            this.testEvalService = testEvalService;
        }
        #endregion

        #region Actions
        /// <summary>
        /// Displays question and answers for specified index.
        /// </summary>
        /// <param name="index"> Question number.</param>
        /// <returns> Testing view.</returns>
        public ActionResult Testing(int index)
        {
            if (Session["Test"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var test = (TestViewModel)Session["Test"];
            ViewBag.NumberOfQuestions = test.Questions.Count;

            if (index > test.Questions.Count)
            {
                try
                {
                    var result = GetResult(test);
                    return RedirectToAction("TestingResult", "TestResult", result);
                }
                catch
                {
                    return RedirectToAction("Error", "Error");
                }
            }
            return View(test.Questions.Where(q => q.QuestionNumber == index).SingleOrDefault());
        }

        /// <summary>
        /// Posts question with user selected answers.
        /// </summary>
        /// <param name="question"> QuestionViewModel instance.</param>
        /// <returns> Testing view.</returns>
        [HttpPost]
        public ActionResult Testing(QuestionViewModel question)
        {
            SaveAnswersToSession(question);
            return RedirectToAction("Testing", new { index = ++question.QuestionNumber});
        }
        #endregion

        #region Private Methods
        private TestResultViewModel GetResult(TestViewModel test)
        {
            var completedTest = new CompletedTestViewModel
            {
                Test = test,
                UserId = userService.GetUserByEmail(User.Identity.Name).Id,
                ChoosenAnswers = (ICollection<AnswerViewModel>)Session["Answers"],
                TimeSpent = TimeSpan.FromMinutes(0)
            };
            Session.Clear();
            return testEvalService.EvaluateTest(completedTest.ToBllCompletedTest()).ToTestResultViewModel();
        }

        private void SaveAnswersToSession(QuestionViewModel question)
        {
            var answers = new List<AnswerViewModel>();
            question.Answers.Where(a => a.IsSelected == true).ToList().ForEach(a => answers.Add(a));
            if (Session["Answers"] != null)
            {
                answers.ForEach(a => ((ICollection<AnswerViewModel>)Session["Answers"]).Add(a));
            }
            else Session["Answers"] = answers;
        }
        #endregion
    }
}