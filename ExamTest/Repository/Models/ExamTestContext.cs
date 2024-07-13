using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repository.Models;

public partial class ExamTestContext : DbContext
{
    public ExamTestContext()
    {
    }

    public ExamTestContext(DbContextOptions<ExamTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Score> Scores { get; set; }

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
            entity.HasKey(e => e.Username).HasName("PK__account__F3DBC573337C4167");

            entity.ToTable("account");

            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("fullName");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Role).HasColumnName("role");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.LessonId).HasName("PK__lessons__F88A9798994B1EF5");

            entity.ToTable("lessons");

            entity.Property(e => e.LessonId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("lessonID");
            entity.Property(e => e.DateCreate).HasColumnName("dateCreate");
            entity.Property(e => e.LessonName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("lessonName");
            entity.Property(e => e.LessonStatus).HasColumnName("lessonStatus");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__question__6238D49249DA0E4C");

            entity.ToTable("questions");

            entity.Property(e => e.QuestionId).HasColumnName("questionID");
            entity.Property(e => e.CorrectAnswer)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("correctAnswer");
            entity.Property(e => e.LessonId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("lessonID");
            entity.Property(e => e.OptionA)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("optionA");
            entity.Property(e => e.OptionB)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("optionB");
            entity.Property(e => e.OptionC)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("optionC");
            entity.Property(e => e.OptionD)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("optionD");
            entity.Property(e => e.QuestionText)
                .HasColumnType("text")
                .HasColumnName("questionText");

            entity.HasOne(d => d.Lesson).WithMany(p => p.Questions)
                .HasForeignKey(d => d.LessonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__questions__lesso__75A278F5");
        });

        modelBuilder.Entity<Score>(entity =>
        {
            entity.HasKey(e => new { e.Username, e.LessonId }).HasName("PK__score__6C536C0A5DEFF152");

            entity.ToTable("score");

            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.LessonId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("lessonID");
            entity.Property(e => e.Score1).HasColumnName("score");
            entity.Property(e => e.TakenAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("takenAt");

            entity.HasOne(d => d.Lesson).WithMany(p => p.Scores)
                .HasForeignKey(d => d.LessonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__score__lessonID__7A672E12");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.Scores)
                .HasForeignKey(d => d.Username)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__score__username__797309D9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
