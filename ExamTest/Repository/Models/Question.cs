using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Question
{
    public int QuestionId { get; set; }

    public string LessonId { get; set; } = null!;

    public string QuestionText { get; set; } = null!;

    public string OptionA { get; set; } = null!;

    public string OptionB { get; set; } = null!;

    public string OptionC { get; set; } = null!;

    public string OptionD { get; set; } = null!;

    public string CorrectAnswer { get; set; } = null!;

    public virtual Lesson Lesson { get; set; } = null!;
}
