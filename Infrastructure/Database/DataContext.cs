using System;
using System.Collections.Generic;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public partial class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AcceptedWork> AcceptedWork { get; set; }

    public virtual DbSet<Caretaker> Caretaker { get; set; }

    public virtual DbSet<Payment> Payment { get; set; }

    public virtual DbSet<Posting> Posting { get; set; }

    public virtual DbSet<Role> Role { get; set; }

    public virtual DbSet<RoleMapping> RoleMapping { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    public virtual DbSet<WorkPeriod> WorkPeriod { get; set; }

    public virtual DbSet<WorkingDetail> WorkingDetail { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcceptedWork>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("accepted_work_pkey");

            entity.ToTable("accepted_work");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CaretakerId).HasColumnName("caretaker_id");
            entity.Property(e => e.PostingId).HasColumnName("posting_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.WorkingDetailId).HasColumnName("working_detail_id");

            entity.HasOne(d => d.Caretaker).WithMany(p => p.AcceptedWork)
                .HasForeignKey(d => d.CaretakerId)
                .HasConstraintName("accepted_work_caretaker_id_fkey");

            entity.HasOne(d => d.Posting).WithMany(p => p.AcceptedWork)
                .HasForeignKey(d => d.PostingId)
                .HasConstraintName("accepted_work_posting_id_fkey");

            entity.HasOne(d => d.WorkingDetail).WithMany(p => p.AcceptedWork)
                .HasForeignKey(d => d.WorkingDetailId)
                .HasConstraintName("accepted_work_working_detail_id_fkey");
        });

        modelBuilder.Entity<Caretaker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("caretaker_pkey");

            entity.ToTable("caretaker");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Education)
                .HasColumnType("character varying")
                .HasColumnName("education");
            entity.Property(e => e.Skill)
                .HasColumnType("character varying")
                .HasColumnName("skill");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WorkingHistory)
                .HasColumnType("character varying")
                .HasColumnName("working_history");

            entity.HasOne(d => d.User).WithMany(p => p.Caretaker)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("caretaker_user_id_fkey");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("payment_pkey");

            entity.ToTable("payment");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.PaymentMethod).HasColumnName("payment_method");
            entity.Property(e => e.PaymentStatus).HasColumnName("payment_status");
            entity.Property(e => e.PostingId).HasColumnName("posting_id");
            entity.Property(e => e.UpdateDate).HasColumnName("update_date");

            entity.HasOne(d => d.Posting).WithMany(p => p.Payment)
                .HasForeignKey(d => d.PostingId)
                .HasConstraintName("payment_posting_id_fkey");
        });

        modelBuilder.Entity<Posting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("posting_pkey");

            entity.ToTable("posting");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Disease)
                .HasColumnType("character varying")
                .HasColumnName("disease");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.Gender)
                .HasColumnType("character varying")
                .HasColumnName("gender");
            entity.Property(e => e.Location)
                .HasColumnType("character varying")
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Tel)
                .HasColumnType("character varying")
                .HasColumnName("tel");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WorkingDate).HasColumnName("working_date");

            entity.HasOne(d => d.User).WithMany(p => p.Posting)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("posting_user_id_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_pkey");

            entity.ToTable("role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleName)
                .HasColumnType("character varying")
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<RoleMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_mapping_pkey");

            entity.ToTable("role_mapping");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Role).WithMany(p => p.RoleMapping)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("role_mapping_role_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.RoleMapping)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("role_mapping_user_id_fkey");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasColumnType("character varying")
                .HasColumnName("address");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Gender)
                .HasColumnType("character varying")
                .HasColumnName("gender");
            entity.Property(e => e.Image)
                .HasColumnType("character varying")
                .HasColumnName("image");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.Tel)
                .HasColumnType("character varying")
                .HasColumnName("tel");
            entity.Property(e => e.Username)
                .HasColumnType("character varying")
                .HasColumnName("username");
        });

        modelBuilder.Entity<WorkPeriod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("work_period_pkey");

            entity.ToTable("work_period");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CaretakerId).HasColumnName("caretaker_id");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
            entity.Property(e => e.WorkingDate).HasColumnName("working_date");

            entity.HasOne(d => d.Caretaker).WithMany(p => p.WorkPeriod)
                .HasForeignKey(d => d.CaretakerId)
                .HasConstraintName("work_period_caretaker_id_fkey");
        });

        modelBuilder.Entity<WorkingDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("working_detail_pkey");

            entity.ToTable("working_detail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AcceptWorkId).HasColumnName("accept_work_id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.UpdateDate).HasColumnName("update_date");
            entity.Property(e => e.WorkDetail)
                .HasColumnType("character varying")
                .HasColumnName("work_detail");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
