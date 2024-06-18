using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Major
{
    public string MajorId { get; set; } = null!;

    public string? MajorName { get; set; }

    public string? MajorDescription { get; set; }

    public virtual ICollection<Majordetail> Majordetails { get; set; } = new List<Majordetail>();
}
