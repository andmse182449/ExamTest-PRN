using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Dayoffschedule
{
    public int DayOffScheduleId { get; set; }

    public DateOnly? DayOff { get; set; }

    public string? Description { get; set; }

    public int? ClinicId { get; set; }

    public virtual Clinic? Clinic { get; set; }
}
