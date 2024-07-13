using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repositories
{
    public class QuestionRepository
    {
        private ExamTestContext? _exam;
        public List<Question> GetAll(string lessonID)
        {
            _exam = new ExamTestContext();
            /*   return _context.Books.ToList();*/
            // LOAD LUON INFO CATEGORY
            return _exam.Questions.Where(x => x.LessonId.Equals(lessonID)).ToList();

        }
        public Question? Get(int questionID)
        {
            _exam = new ExamTestContext();
            /*   return _context.Books.ToList();*/
            // LOAD LUON INFO CATEGORY
            return _exam.Questions.FirstOrDefault(x => x.QuestionId == questionID);


        }
        public List<Question> Get(string lessonID)
        {
            ExamTestContext examTestContext = new ExamTestContext();
            return examTestContext.Questions
                .Where(q => q.LessonId == lessonID)
                .ToList();
        }

        public void Add(Question question)
        {
            ExamTestContext examTestContext = new ExamTestContext();
            examTestContext.Questions.Add(question);
            examTestContext.SaveChanges();
        }
    }
}
