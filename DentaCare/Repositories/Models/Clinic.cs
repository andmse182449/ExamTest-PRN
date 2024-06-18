using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Clinic
{
    public int ClinicId { get; set; }

    public string? ClinicName { get; set; }

    public string? ClinicAddress { get; set; }

    public string? City { get; set; }

    public string? Hotline { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Dayoffschedule> Dayoffschedules { get; set; } = new List<Dayoffschedule>();
}
