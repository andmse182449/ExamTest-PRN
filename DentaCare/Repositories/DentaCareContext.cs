using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repositories.Models;

namespace Repositories;
public partial class DentaCareContext : DbContext
{
    public DentaCareContext()
    {
    }

    public DentaCareContext(DbContextOptions<DentaCareContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Clinic> Clinics { get; set; }

    public virtual DbSet<Dayoffschedule> Dayoffschedules { get; set; }

    public virtual DbSet<Dentistschedule> Dentistschedules { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Major> Majors { get; set; }

    public virtual DbSet<Majordetail> Majordetails { get; set; }

    public virtual DbSet<Mediicalrecord> Mediicalrecords { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Timeslot> Timeslots { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString());
    private string? GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true, true).Build();
        return configuration["ConnectionStrings:DefaultConnectionStringDB"];
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__ACCOUNT__F267253E165173F7");

            entity.ToTable("ACCOUNT");

            entity.Property(e => e.AccountId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("accountID");
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .HasColumnName("address");
            entity.Property(e => e.ClinicId).HasColumnName("clinicID");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("fullName");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.GoogleId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("googleID");
            entity.Property(e => e.GoogleName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("googleName");
            entity.Property(e => e.Image)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone");
            entity.Property(e => e.RoleId).HasColumnName("roleID");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Username)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.Clinic).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.ClinicId)
                .HasConstraintName("FK_clinicID1");

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_roleID1");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__BOOKING__C6D03BEDDA530291");

            entity.ToTable("BOOKING");

            entity.Property(e => e.BookingId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("bookingID");
            entity.Property(e => e.AppointmentDay).HasColumnName("appointmentDay");
            entity.Property(e => e.ClinicId).HasColumnName("clinicID");
            entity.Property(e => e.CreateDay).HasColumnName("createDay");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("customerID");
            entity.Property(e => e.DentistId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("dentistID");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.ServiceId).HasColumnName("serviceID");
            entity.Property(e => e.SlotId).HasColumnName("slotID");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Clinic).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ClinicId)
                .HasConstraintName("FK_clinicID3");

            entity.HasOne(d => d.Customer).WithMany(p => p.BookingCustomers)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_accountID4");

            entity.HasOne(d => d.Dentist).WithMany(p => p.BookingDentists)
                .HasForeignKey(d => d.DentistId)
                .HasConstraintName("FK_accountID5");

            entity.HasOne(d => d.Service).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_serviceID1");

            entity.HasOne(d => d.Slot).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.SlotId)
                .HasConstraintName("FK_slotID1");
        });

        modelBuilder.Entity<Clinic>(entity =>
        {
            entity.HasKey(e => e.ClinicId).HasName("PK__CLINIC__F6C582984E3E7C88");

            entity.ToTable("CLINIC");

            entity.Property(e => e.ClinicId).HasColumnName("clinicID");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.ClinicAddress)
                .HasMaxLength(100)
                .HasColumnName("clinicAddress");
            entity.Property(e => e.ClinicName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("clinicName");
            entity.Property(e => e.Hotline)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("hotline");
        });

        modelBuilder.Entity<Dayoffschedule>(entity =>
        {
            entity.HasKey(e => e.DayOffScheduleId).HasName("PK__DAYOFFSC__188DF8BEF03F954E");

            entity.ToTable("DAYOFFSCHEDULE");

            entity.Property(e => e.DayOffScheduleId).HasColumnName("dayOffScheduleID");
            entity.Property(e => e.ClinicId).HasColumnName("clinicID");
            entity.Property(e => e.DayOff).HasColumnName("dayOff");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");

            entity.HasOne(d => d.Clinic).WithMany(p => p.Dayoffschedules)
                .HasForeignKey(d => d.ClinicId)
                .HasConstraintName("FK_clinicID2");
        });

        modelBuilder.Entity<Dentistschedule>(entity =>
        {
            entity.HasKey(e => e.DentistScheduleId).HasName("PK__DENTISTS__51525D0A0F469F44");

            entity.ToTable("DENTISTSCHEDULE");

            entity.Property(e => e.DentistScheduleId).HasColumnName("dentistScheduleID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("accountID");
            entity.Property(e => e.WorkingDate).HasColumnName("workingDate");

            entity.HasOne(d => d.Account).WithMany(p => p.Dentistschedules)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_accountID1");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__FEEDBACK__2613FDC4DBDF03CE");

            entity.ToTable("FEEDBACK");

            entity.Property(e => e.FeedbackId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("feedbackID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("accountID");
            entity.Property(e => e.FeedbackContent).HasColumnName("feedbackContent");
            entity.Property(e => e.FeedbackDay)
                .HasColumnType("datetime")
                .HasColumnName("feedbackDay");

            entity.HasOne(d => d.Account).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_accountID3");
        });

        modelBuilder.Entity<Major>(entity =>
        {
            entity.HasKey(e => e.MajorId).HasName("PK__MAJOR__A5B1B494CDB567C9");

            entity.ToTable("MAJOR");

            entity.Property(e => e.MajorId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("majorID");
            entity.Property(e => e.MajorDescription)
                .HasMaxLength(250)
                .HasColumnName("majorDescription");
            entity.Property(e => e.MajorName)
                .HasMaxLength(30)
                .HasColumnName("majorName");
        });

        modelBuilder.Entity<Majordetail>(entity =>
        {
            entity.HasKey(e => new { e.MajorId, e.AccountId }).HasName("PK__MAJORDET__5A97C6C72A36F1E6");

            entity.ToTable("MAJORDETAIL");

            entity.Property(e => e.MajorId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("majorID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("accountID");
            entity.Property(e => e.Introduction)
                .HasMaxLength(500)
                .HasColumnName("introduction");

            entity.HasOne(d => d.Account).WithMany(p => p.Majordetails)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_accountID2");

            entity.HasOne(d => d.Major).WithMany(p => p.Majordetails)
                .HasForeignKey(d => d.MajorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_majorID1");
        });

        modelBuilder.Entity<Mediicalrecord>(entity =>
        {
            entity.HasKey(e => e.MedicalRecordId).HasName("PK__MEDIICAL__14A80D25FFDBE1A8");

            entity.ToTable("MEDIICALRECORDS");

            entity.Property(e => e.MedicalRecordId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("medicalRecordID");
            entity.Property(e => e.BookingId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("bookingID");
            entity.Property(e => e.ReExanime).HasColumnName("reExanime");
            entity.Property(e => e.Results).HasColumnName("results");

            entity.HasOne(d => d.Booking).WithMany(p => p.Mediicalrecords)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK_bookingID1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__ROLE__CD98460A28BAB345");

            entity.ToTable("ROLE");

            entity.Property(e => e.RoleId).HasColumnName("roleID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("roleName");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__SERVICE__4550733F629803BA");

            entity.ToTable("SERVICE");

            entity.Property(e => e.ServiceId).HasColumnName("serviceID");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(50)
                .HasColumnName("serviceName");
            entity.Property(e => e.ServiceType)
                .HasMaxLength(50)
                .HasColumnName("serviceType");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Timeslot>(entity =>
        {
            entity.HasKey(e => e.SlotId).HasName("PK__TIMESLOT__9C4A67F331E5F026");

            entity.ToTable("TIMESLOT");

            entity.Property(e => e.SlotId).HasColumnName("slotID");
            entity.Property(e => e.TimePeriod)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("timePeriod");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
