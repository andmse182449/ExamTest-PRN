using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Lesson
{
    public string LessonId { get; set; } = null!;

    public string LessonName { get; set; } = null!;

    public bool LessonStatus { get; set; }

    public DateOnly? DateCreate { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();
}
