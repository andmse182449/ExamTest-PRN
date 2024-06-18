using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Dentistschedule
{
    public int DentistScheduleId { get; set; }

    public string? AccountId { get; set; }

    public DateOnly? WorkingDate { get; set; }

    public virtual Account? Account { get; set; }
}
