using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;
using Repository.Models;

namespace Services
{
    public class QuestionService
    {
        private QuestionRepository questionRepository = new();

        public Question? GetAQuestion(int id)
        {
            return questionRepository.Get(id);

        }
        public List<Question> GetAllQuestions(string lesID)
        {
            return questionRepository.GetAll(lesID);

        }
        public List<Question> GetQuestionByLessonID(string lessonID)
        {
            QuestionRepository questionRepository = new QuestionRepository();
            return questionRepository.Get(lessonID);
        }

        public void CreateNewQuestion(Question question)
        {
            QuestionRepository questionRepository = new QuestionRepository();
            questionRepository.Add(question);
        }
    }
}
