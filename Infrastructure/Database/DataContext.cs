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

    public virtual DbSet<Post> Post { get; set; }

    public virtual DbSet<Posting> Posting { get; set; }

    public virtual DbSet<Role> Role { get; set; }

    public virtual DbSet<RoleMapping> RoleMapping { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    public virtual DbSet<WorkDetail> WorkDetail { get; set; }

    public virtual DbSet<WorkPeriod> WorkPeriod { get; set; }

    public virtual DbSet<WorkingDetail> WorkingDetail { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<AcceptedWork>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("accepted_work_pkey");

            entity.ToTable("accepted_work");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CaretakerId).HasColumnName("caretaker_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Rating).HasColumnName("rating");

            entity.HasOne(d => d.Caretaker).WithMany(p => p.AcceptedWork)
                .HasForeignKey(d => d.CaretakerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("accepted_work_caretaker_id_fkey");

            entity.HasOne(d => d.Post).WithMany(p => p.AcceptedWork)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("accepted_work_post_id_fkey");
        });

        modelBuilder.Entity<Caretaker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("caretaker_pkey");

            entity.ToTable("caretaker");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Education)
                .HasColumnType("character varying")
                .HasColumnName("education");
            entity.Property(e => e.Skill)
                .HasColumnType("character varying")
                .HasColumnName("skill");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WorkHistory)
                .HasColumnType("character varying")
                .HasColumnName("work_history");

            entity.HasOne(d => d.User).WithMany(p => p.Caretaker)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("caretaker_user_id_fkey");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("payment_pkey");

            entity.ToTable("payment");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.PaymentMethod).HasColumnName("payment_method");
            entity.Property(e => e.PaymentStatus).HasColumnName("payment_status");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.UpdateDate).HasColumnName("update_date");

            entity.HasOne(d => d.Post).WithMany(p => p.Payment)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("payment_post_id_fkey");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("post_pkey");

            entity.ToTable("post");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Description).HasColumnName("description");
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
            entity.Property(e => e.StartTime).HasColumnName("start_time");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Tel)
                .HasColumnType("character varying")
                .HasColumnName("tel");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WorkingDate).HasColumnName("working_date");

            entity.HasOne(d => d.User).WithMany(p => p.Post)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("post_user_id_fkey");
        });

        modelBuilder.Entity<Posting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("posting_pkey");

            entity.ToTable("posting");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Description).HasColumnName("description");
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
            entity.Property(e => e.StartTime).HasColumnName("start_time");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Tel)
                .HasColumnType("character varying")
                .HasColumnName("tel");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WorkingDate).HasColumnName("working_date");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_pkey");

            entity.ToTable("role");

            entity.HasIndex(e => e.RoleName, "role_role_name_key").IsUnique();

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
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("role_mapping_role_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.RoleMapping)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("role_mapping_user_id_fkey");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Username, "users_username_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
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
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
            entity.Property(e => e.Username)
                .HasColumnType("character varying")
                .HasColumnName("username");
        });

        modelBuilder.Entity<WorkDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("work_detail_pkey");

            entity.ToTable("work_detail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AcceptWorkId).HasColumnName("accept_work_id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.UpdateDate).HasColumnName("update_date");
            entity.Property(e => e.WorkPeriodId).HasColumnName("work_period_id");

            entity.HasOne(d => d.AcceptWork).WithMany(p => p.WorkDetail)
                .HasForeignKey(d => d.AcceptWorkId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("work_detail_accept_work_id_fkey");

            entity.HasOne(d => d.WorkPeriod).WithMany(p => p.WorkDetail)
                .HasForeignKey(d => d.WorkPeriodId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("work_detail_work_period_id_fkey");
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
                .OnDelete(DeleteBehavior.Cascade)
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
