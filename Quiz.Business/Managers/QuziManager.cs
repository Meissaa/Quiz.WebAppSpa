using log4net;
using Quiz.Common.Entities;
using Quiz.Common.Exceptions;
using Quiz.Common.Managers;
using Quiz.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Business.Managers
{
    public class QuziManager : IQuizManager
    {
        private static ILog _log;
        private IAuthManager _authManager;
        private QuizDbContext _db = new QuizDbContext();

        public QuziManager(IAuthManager authManager)
        {

            _log = LogManager.GetLogger(this.GetType().FullName);
            _authManager = authManager;
        }

        public void AddChoice(int questionId, Choice answer)
        {
            if (answer == null)
                throw new ArgumentNullException("answer");

            if (string.IsNullOrEmpty(answer.Answer))
                throw new QuizException("Answer is required");

            var question = _db.Questions.FirstOrDefault(e => e.QuestionId == questionId);
            if (question == null)
                throw new QuizException(string.Format("Question id {0} not found",questionId));

            answer.Question = question;
            question.Choices.Add(answer);
            _db.SaveChanges();
        }

        public bool CheckIsCorrectAnswer(int choiceId)
        {
            var answer = _db.Choices.Find(choiceId);

            if (answer == null)
                throw new QuizException("answer not found");

            return answer.IsCorrect;

        }

        public void CreateQuestion(Question item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            if (string.IsNullOrEmpty(item.QuestionText))
                throw new QuizException("Question is required");

            var userId = _authManager.GetLoggedUser().UserId;
            item.User = _db.Users.First(e => e.UserId == userId);

            _db.Questions.Add(item);
            _db.SaveChanges();
        }

        public void DeleteQuestion(int questionId)
        {
            var userId = _authManager.GetLoggedUser().UserId;
            var question = _db.Questions.FirstOrDefault(e => e.QuestionId == questionId && e.User.UserId == userId);
            if (question != null)
            {
                _db.Entry<Question>(question).State = System.Data.Entity.EntityState.Deleted;
                _db.SaveChanges();
            }
            else
            {
                throw new QuizException("Question not found");
            }
        }

        public IList<Question> GetQuestions()
        {
            var userId = _authManager.GetLoggedUser().UserId;
            var listquestions = _db.Questions.Where(e => e.User.UserId == userId);
            return listquestions.ToList();
        }

        public void UpdatedChoice(Choice answer)
        {
            if (answer == null)
                throw new QuizException("answer");

            var answerItem = _db.Choices.Find(answer.ChoiceId);

            if (answerItem == null)
                throw new QuizException("answer not found");

            _db.Entry(answerItem).CurrentValues.SetValues(answer);
            _db.SaveChanges();
        }

        public void UpdateQuestion(Question item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            var question = _db.Questions.Find(item.QuestionId);

            if(question == null)
                throw new ArgumentNullException("question not found");

            _db.Entry(item).CurrentValues.SetValues(item);
            _db.SaveChanges();
        }
    }
}
