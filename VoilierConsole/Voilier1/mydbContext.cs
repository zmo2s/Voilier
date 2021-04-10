using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsoleApp1.Voilier1
{
    public partial class mydbContext : DbContext
    {
        public mydbContext()
        {
        }

        public mydbContext(DbContextOptions<mydbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Etape> Etape { get; set; }
        public virtual DbSet<Penalite> Penalite { get; set; }
        public virtual DbSet<Personne> Personne { get; set; }
        public virtual DbSet<Voilier> Voilier { get; set; }
        public virtual DbSet<VoilierEtape> VoilierEtape { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=127.0.0.1;port=3306;user=phpmyadmin;password=Clementine1011%;database=voilier1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.IdCourse)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.EtapeIdEtape)
                    .HasName("fk_Course_Etape_idx");

                entity.HasIndex(e => new { e.VoilierEtapeIdVoilierEtape, e.VoilierEtapeVoilierIdVoilier })
                    .HasName("fk_Course_VoilierEtape1_idx");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.EtapeIdEtape).HasColumnName("Etape_idEtape");

                entity.Property(e => e.Nom)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.VoilierEtapeIdVoilierEtape).HasColumnName("VoilierEtape_idVoilierEtape");

                entity.Property(e => e.VoilierEtapeVoilierIdVoilier).HasColumnName("VoilierEtape_Voilier_idVoilier");

                entity.HasOne(d => d.EtapeIdEtapeNavigation)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.EtapeIdEtape)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Course_Etape");

                entity.HasOne(d => d.VoilierEtape)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => new { d.VoilierEtapeIdVoilierEtape, d.VoilierEtapeVoilierIdVoilier })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Course_VoilierEtape1");
            });

            modelBuilder.Entity<Etape>(entity =>
            {
                entity.HasKey(e => e.IdEtape)
                    .HasName("PRIMARY");

                entity.HasIndex(e => new { e.VoilierEtapeIdVoilierEtape, e.VoilierEtapeVoilierIdVoilier })
                    .HasName("fk_Etape_VoilierEtape1_idx");

                entity.Property(e => e.IdEtape).HasColumnName("idEtape");

                entity.Property(e => e.DateFin).HasColumnName("DateFIn");

                entity.Property(e => e.Nom)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.VoilierEtapeIdVoilierEtape).HasColumnName("VoilierEtape_idVoilierEtape");

                entity.Property(e => e.VoilierEtapeVoilierIdVoilier).HasColumnName("VoilierEtape_Voilier_idVoilier");

                entity.HasOne(d => d.VoilierEtape)
                    .WithMany(p => p.Etape)
                    .HasForeignKey(d => new { d.VoilierEtapeIdVoilierEtape, d.VoilierEtapeVoilierIdVoilier })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Etape_VoilierEtape1");
            });

            modelBuilder.Entity<Penalite>(entity =>
            {
                entity.HasKey(e => e.IdPenalite)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdPenalite).HasColumnName("idPenalite");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Personne>(entity =>
            {
                entity.HasKey(e => e.IdPersonne)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdPersonne).HasColumnName("idPersonne");

                entity.Property(e => e.Equipage)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Sponsors)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Voilier>(entity =>
            {
                entity.HasKey(e => e.IdVoilier)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.PersonneIdPersonne)
                    .HasName("fk_Voilier_Personne1_idx");

                entity.Property(e => e.IdVoilier).HasColumnName("idVoilier");

                entity.Property(e => e.Marque)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PersonneIdPersonne).HasColumnName("Personne_idPersonne");

                entity.HasOne(d => d.PersonneIdPersonneNavigation)
                    .WithMany(p => p.Voilier)
                    .HasForeignKey(d => d.PersonneIdPersonne)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Voilier_Personne1");
            });

            modelBuilder.Entity<VoilierEtape>(entity =>
            {
                entity.HasKey(e => new { e.IdVoilierEtape, e.VoilierIdVoilier })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.PenaliteIdPenalite)
                    .HasName("fk_VoilierEtape_Penalite1_idx");

                entity.HasIndex(e => e.VoilierIdVoilier)
                    .HasName("fk_VoilierEtape_Voilier1_idx");

                entity.Property(e => e.IdVoilierEtape).HasColumnName("idVoilierEtape");

                entity.Property(e => e.VoilierIdVoilier).HasColumnName("Voilier_idVoilier");

                entity.Property(e => e.PenaliteIdPenalite).HasColumnName("Penalite_idPenalite");

                entity.HasOne(d => d.PenaliteIdPenaliteNavigation)
                    .WithMany(p => p.VoilierEtape)
                    .HasForeignKey(d => d.PenaliteIdPenalite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_VoilierEtape_Penalite1");

                entity.HasOne(d => d.VoilierIdVoilierNavigation)
                    .WithMany(p => p.VoilierEtape)
                    .HasForeignKey(d => d.VoilierIdVoilier)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_VoilierEtape_Voilier1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
