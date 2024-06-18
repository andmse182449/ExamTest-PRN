using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Feedback
{
    public string FeedbackId { get; set; } = null!;

    public string? FeedbackContent { get; set; }

    public string? AccountId { get; set; }

    public DateTime? FeedbackDay { get; set; }

    public virtual Account? Account { get; set; }
}
