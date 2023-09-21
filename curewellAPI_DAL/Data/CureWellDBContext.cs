using curewellAPI_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace curewellAPI_DAL.Data
{
    public partial class CureWellDBContext : DbContext
    {
        public CureWellDBContext(DbContextOptions<CureWellDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<DoctorSpecialization> DoctorSpecializations { get; set; } = null!;
        public virtual DbSet<Specialization> Specializations { get; set; } = null!;
        public virtual DbSet<Surgery> Surgeries { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("Doctor");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.DoctorName)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DoctorSpecialization>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DoctorSpecialization");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.SpecializationCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SpecializationDate).HasColumnType("date");

                entity.HasOne(d => d.Doctor)
                    .WithMany()
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoctorSpecialization_Doctor");

                entity.HasOne(d => d.SpecializationCodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.SpecializationCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoctorSpecialization_Specialization");
            });

            modelBuilder.Entity<Specialization>(entity =>
            {
                entity.HasKey(e => e.SpecializationCode);

                entity.ToTable("Specialization");

                entity.Property(e => e.SpecializationCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SpecializationName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Surgery>(entity =>
            {
                entity.ToTable("Surgery");

                entity.Property(e => e.SurgeryId).HasColumnName("SurgeryID");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.EndTime).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.StartTime).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.SurgeryCategory)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SurgeryDate).HasColumnType("date");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Surgeries)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Surgery_Doctor");

                entity.HasOne(d => d.SurgeryCategoryNavigation)
                    .WithMany(p => p.Surgeries)
                    .HasForeignKey(d => d.SurgeryCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Surgery_Specialization");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
