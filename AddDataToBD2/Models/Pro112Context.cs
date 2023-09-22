using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AddDataToBD2;

public partial class Pro112Context : DbContext
{
    public Pro112Context()
    {
    }

    public Pro112Context(DbContextOptions<Pro112Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Requirement> Requirements { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=10.10.1.24;port=3306;database=pro1_12;user=user_01;password=user01pro", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.15-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");
        

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId)
                .HasColumnType("int(11)")
                .HasColumnName("EmployeeID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Skills).HasColumnType("text");
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => e.ModuleId).HasName("PRIMARY");

            entity.ToTable("Module");

            entity.HasIndex(e => e.ProjectId, "Module_Project_ProjectID_fk");

            entity.Property(e => e.ModuleId)
                .HasColumnType("int(11)")
                .HasColumnName("ModuleID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.NameModule).HasMaxLength(50);
            entity.Property(e => e.ProjectId)
                .HasColumnType("int(11)")
                .HasColumnName("ProjectID");

            entity.HasOne(d => d.Project).WithMany(p => p.Modules)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Module_Project_ProjectID_fk");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PRIMARY");

            entity.ToTable("Project");

            entity.Property(e => e.ProjectId)
                .HasColumnType("int(11)")
                .HasColumnName("ProjectID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.NameProject).HasMaxLength(50);
        });

        modelBuilder.Entity<Requirement>(entity =>
        {
            entity.HasKey(e => e.RequirementsId).HasName("PRIMARY");

            entity.HasIndex(e => e.ModuleId, "Requirements_Module_ModuleID_fk");

            entity.Property(e => e.RequirementsId)
                .HasColumnType("int(11)")
                .HasColumnName("RequirementsID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.ModuleId)
                .HasColumnType("int(11)")
                .HasColumnName("ModuleID");

            entity.HasOne(d => d.Module).WithMany(p => p.Requirements)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Requirements_Module_ModuleID_fk");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PRIMARY");

            entity.ToTable("Status");

            entity.Property(e => e.StatusId)
                .HasColumnType("int(11)")
                .HasColumnName("StatusID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PRIMARY");

            entity.ToTable("Task");

            entity.HasIndex(e => e.EmployeeId, "Task_Employee_EmployeeID_fk");

            entity.HasIndex(e => e.ModuleId, "Task_Module_ModuleID_fk");

            entity.HasIndex(e => e.StatusId, "Task_Status_StatusID_fk");

            entity.Property(e => e.TaskId)
                .HasColumnType("int(11)")
                .HasColumnName("TaskID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.EmployeeId)
                .HasColumnType("int(11)")
                .HasColumnName("EmployeeID");
            entity.Property(e => e.ModuleId)
                .HasColumnType("int(11)")
                .HasColumnName("ModuleID");
            entity.Property(e => e.NameTask).HasMaxLength(50);
            entity.Property(e => e.StatusId)
                .HasColumnType("int(11)")
                .HasColumnName("StatusID");

            entity.HasOne(d => d.Employee).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Task_Employee_EmployeeID_fk");

            entity.HasOne(d => d.Module).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Task_Module_ModuleID_fk");

            entity.HasOne(d => d.Status).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Task_Status_StatusID_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
