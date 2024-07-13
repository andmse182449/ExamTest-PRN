using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Score
{
    public string Username { get; set; } = null!;

    public string LessonId { get; set; } = null!;

    public int Score1 { get; set; }

    public DateTime TakenAt { get; set; }

    public virtual Lesson Lesson { get; set; } = null!;

    public virtual Account UsernameNavigation { get; set; } = null!;
}
