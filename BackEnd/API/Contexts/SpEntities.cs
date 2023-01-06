using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using API.Domains;

namespace API.Contexts
{
    public partial class SpEntities : DbContext
    {
        public SpEntities()
        {
        }

        public SpEntities(DbContextOptions<SpEntities> options)
            : base(options)
        {
        }

        public virtual DbSet<Competitor> Competitors { get; set; } = null!;
        public virtual DbSet<Expense> Expenses { get; set; } = null!;
        public virtual DbSet<ExpenseType> ExpenseTypes { get; set; } = null!;
        public virtual DbSet<Frequency> Frequencies { get; set; } = null!;
        public virtual DbSet<School> Schools { get; set; } = null!;
        public virtual DbSet<Skill> Skills { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserType> UserTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-3O2A4AI\\SQLEXPRESS; initial catalog=SPSkills; Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Competitor>(entity =>
            {
                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Image).HasColumnType("image");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Competitors)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_Competidores_Usuarios");
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.IdCompetitorNavigation)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.IdCompetitor)
                    .HasConstraintName("FK_Despesas_Competidores");

                entity.HasOne(d => d.IdExpenseTypeNavigation)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.IdExpenseType)
                    .HasConstraintName("FK_Despesas_TiposDespesa");
            });

            modelBuilder.Entity<ExpenseType>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Frequency>(entity =>
            {
                entity.ToTable("Frequency");

                entity.Property(e => e.CheckIn).HasColumnType("datetime");

                entity.Property(e => e.CheckOut).HasColumnType("datetime");

                entity.HasOne(d => d.IdCompetitorNavigation)
                    .WithMany(p => p.Frequencies)
                    .HasForeignKey(d => d.IdCompetitor)
                    .HasConstraintName("FK_Frequencias_Competidores");
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Cpf)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSchoolNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdSchool)
                    .HasConstraintName("FK_Usuarios_Escola");

                entity.HasOne(d => d.IdSkillNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdSkill)
                    .HasConstraintName("FK_Usuarios_Modalidades");

                entity.HasOne(d => d.IdUserTypeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdUserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_TiposUsuario");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
