using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Account
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public int Role { get; set; }

    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();
}
