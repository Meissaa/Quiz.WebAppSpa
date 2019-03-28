using Quiz.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Common.Managers
{
    public interface IQuizManager
    {
        void CreateQuestion(Question item);
        void UpdateQuestion(Question item);
        void DeleteQuestion(int questionId);
        IList<Question> GetQuestions();
        void AddChoice(int questionId, Choice answer);
        void UpdatedChoice(Choice answer);
        bool CheckIsCorrectAnswer(int choiceId);        
    }
}
