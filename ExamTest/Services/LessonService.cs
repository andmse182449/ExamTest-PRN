using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;
using Repository.Models;


namespace Services
{
   
    public class LessonService
    {
        private LessonRepository _repository = new LessonRepository();

        public Lesson? GetALesson(string id)
        {
            return _repository.Get(id);

        }
        public List<Lesson> GetList()
        {
            LessonRepository repository = new LessonRepository();
            return repository.GetAll();
        }

        public void CreateNewLesson(Lesson lesson)
        {
            LessonRepository lessonRepository = new LessonRepository();
            lessonRepository.Add(lesson);
        }

        public bool CheckExitLessonID(string id)
        {
            LessonRepository lessonRepository = new LessonRepository();
            if (lessonRepository.Check(id))
            {
                return true;
            }
            return false;
        }

        public void DisableLesson(Lesson lesson)
        {
            lesson.LessonStatus = false;
            _repository.Update(lesson);
        }

        public void EnableLesson(Lesson lesson)
        {
            lesson.LessonStatus = true;
            _repository.Update(lesson);
        }
    }
}
