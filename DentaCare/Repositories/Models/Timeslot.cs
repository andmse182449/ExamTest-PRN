using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Timeslot
{
    public int SlotId { get; set; }

    public string? TimePeriod { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
