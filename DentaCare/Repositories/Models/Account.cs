using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Account
{
    public string AccountId { get; set; } = null!;

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? FullName { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public DateOnly? Dob { get; set; }

    public bool? Gender { get; set; }

    public string? Image { get; set; }

    public string? GoogleId { get; set; }

    public string? GoogleName { get; set; }

    public int? RoleId { get; set; }

    public int? Status { get; set; }

    public int? ClinicId { get; set; }

    public virtual ICollection<Booking> BookingCustomers { get; set; } = new List<Booking>();

    public virtual ICollection<Booking> BookingDentists { get; set; } = new List<Booking>();

    public virtual Clinic? Clinic { get; set; }

    public virtual ICollection<Dentistschedule> Dentistschedules { get; set; } = new List<Dentistschedule>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Majordetail> Majordetails { get; set; } = new List<Majordetail>();

    public virtual Role? Role { get; set; }
}
