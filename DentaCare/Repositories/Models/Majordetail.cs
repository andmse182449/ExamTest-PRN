using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Majordetail
{
    public string MajorId { get; set; } = null!;

    public string AccountId { get; set; } = null!;

    public string? Introduction { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Major Major { get; set; } = null!;
}
