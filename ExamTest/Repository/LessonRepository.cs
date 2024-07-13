using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repositories
{
    public class LessonRepository
    {
        private ExamTestContext? _context;
        public Lesson? Get(string lesID)
        {
            _context = new ExamTestContext();
            return _context.Lessons.FirstOrDefault(x => x.LessonId.Equals(lesID));

        }
        public List<Lesson> GetAll()
        {
            ExamTestContext examTestContext = new ExamTestContext();
            return examTestContext.Lessons.ToList();
        }

        public void Add(Lesson lesson)
        {
            ExamTestContext examTestContext = new ExamTestContext();
            examTestContext.Lessons.Add(lesson);
            examTestContext.SaveChanges();
        }

        public bool Check(string lessonID)
        {
            ExamTestContext examTestContext = new ExamTestContext();
            return examTestContext.Lessons.Any(x => x.LessonId.Equals(lessonID));
        }

    }
}
