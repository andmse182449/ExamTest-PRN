using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Mediicalrecord
{
    public string MedicalRecordId { get; set; } = null!;

    public string? Results { get; set; }

    public string? BookingId { get; set; }

    public DateOnly? ReExanime { get; set; }

    public virtual Booking? Booking { get; set; }
}
