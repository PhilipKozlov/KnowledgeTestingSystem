namespace ORM
{
    /// <summary>
    /// Represents single answer to the question.
    /// </summary>
    public class Answer
    {
        /// <summary>
        /// Gets or sets Answer identificator.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets Question identificator.
        /// </summary>
        public int QuestionId { get; set; }
        /// <summary>
        /// Gets or sets Answer text.
        /// </summary>
        public string AnswerText { get; set; }
        /// <summary>
        /// Gets or sets weather the answer is correct.
        /// </summary>
        public bool IsCorrect { get; set; }

        /// <summary>
        /// Gets or sets Question.
        /// </summary>
        public virtual Question Question { get; set; }
    }
}
