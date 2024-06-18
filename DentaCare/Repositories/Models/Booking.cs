using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Booking
{
    public string BookingId { get; set; } = null!;

    public DateOnly? CreateDay { get; set; }

    public DateOnly? AppointmentDay { get; set; }

    public int? Status { get; set; }

    public decimal? Price { get; set; }

    public int? ServiceId { get; set; }

    public int? SlotId { get; set; }

    public string? CustomerId { get; set; }

    public string? DentistId { get; set; }

    public int? ClinicId { get; set; }

    public virtual Clinic? Clinic { get; set; }

    public virtual Account? Customer { get; set; }

    public virtual Account? Dentist { get; set; }

    public virtual ICollection<Mediicalrecord> Mediicalrecords { get; set; } = new List<Mediicalrecord>();

    public virtual Service? Service { get; set; }

    public virtual Timeslot? Slot { get; set; }
}
