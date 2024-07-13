using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Models;


namespace Repositories
{
    public class ScoreRepository
    {
        ExamTestContext _context;
        public void Create(Score score)
        {
            _context = new ExamTestContext();
            _context.Add(score);
            _context.SaveChanges();
        }
        public Score? Get(String lesID)
        {
            _context = new ExamTestContext();
            return _context.Scores.FirstOrDefault(s => s.LessonId.Equals(lesID));

        }

        public Score? Get(String lesID, String accID)
        {
            _context = new ExamTestContext();
            return _context.Scores.FirstOrDefault(s => s.LessonId.Equals(lesID) && s.Username.Equals(accID));

        }
        public List<Score> GetAll(string lessonID)
        {
            ExamTestContext examTestContext = new ExamTestContext();
            return examTestContext.Scores
                .Include(s => s.UsernameNavigation)
                .Include(s => s.Lesson)
                .Where(s => s.LessonId == lessonID)
                .ToList();
        }
    }
}
