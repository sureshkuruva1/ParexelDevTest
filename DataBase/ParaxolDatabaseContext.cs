using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ParexelDevTest.DataBase
{
    public partial class ParaxolDatabaseContext : DbContext
    {
        public ParaxolDatabaseContext()
        {
        }

        public ParaxolDatabaseContext(DbContextOptions<ParaxolDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<UserTask> UserTask { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ParaxolDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserTask>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("PK_Task");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.Property(e => e.AssignedUserId).HasColumnName("AssignedUserID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateDue).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.EscalationUserId).HasColumnName("EscalationUserID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.AssignedUser)
                    .WithMany(p => p.UserTaskAssignedUser)
                    .HasForeignKey(d => d.AssignedUserId)
                    .HasConstraintName("FK_Task_UserInfo_AssignedUser");

                entity.HasOne(d => d.EscalationUser)
                    .WithMany(p => p.UserTaskEscalationUser)
                    .HasForeignKey(d => d.EscalationUserId)
                    .HasConstraintName("FK_Task_Task_EscalationUser");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
