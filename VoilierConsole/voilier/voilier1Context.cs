using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsoleApp1.voilier
{
    public partial class voilier1Context : DbContext
    {
        public voilier1Context()
        {
        }

        public voilier1Context(DbContextOptions<voilier1Context> options)
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

                entity.HasIndex(e => e.VoilierEtapeIdVoilierEtape)
                    .HasName("fk_Course_VoilierEtape1_idx");

                entity.HasIndex(e => e.VoilierIdVoilier)
                    .HasName("fk_Course_Voilier1_idx");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.EtapeIdEtape).HasColumnName("Etape_idEtape");

                entity.Property(e => e.Nom)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.VoilierEtapeIdVoilierEtape).HasColumnName("VoilierEtape_idVoilierEtape");

                entity.Property(e => e.VoilierIdVoilier).HasColumnName("Voilier_idVoilier");

                entity.HasOne(d => d.EtapeIdEtapeNavigation)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.EtapeIdEtape)
                    .HasConstraintName("fk_Course_Etape");

                entity.HasOne(d => d.VoilierEtapeIdVoilierEtapeNavigation)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.VoilierEtapeIdVoilierEtape)
                    .HasConstraintName("fk_Course_VoilierEtape1");

                entity.HasOne(d => d.VoilierIdVoilierNavigation)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.VoilierIdVoilier)
                    .HasConstraintName("fk_Course_Voilier1");
            });

            modelBuilder.Entity<Etape>(entity =>
            {
                entity.HasKey(e => e.IdEtape)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.VoilierEtapeIdVoilierEtape)
                    .HasName("fk_Etape_VoilierEtape1_idx");

                entity.HasIndex(e => e.VoilierIdVoilier)
                    .HasName("fk_Etape_Voilier1_idx");

                entity.Property(e => e.IdEtape).HasColumnName("idEtape");

                entity.Property(e => e.DateFin).HasColumnName("DateFIn");

                entity.Property(e => e.Nom)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.VoilierEtapeIdVoilierEtape).HasColumnName("VoilierEtape_idVoilierEtape");

                entity.Property(e => e.VoilierIdVoilier).HasColumnName("Voilier_idVoilier");

                entity.HasOne(d => d.VoilierEtapeIdVoilierEtapeNavigation)
                    .WithMany(p => p.Etape)
                    .HasForeignKey(d => d.VoilierEtapeIdVoilierEtape)
                    .HasConstraintName("fk_Etape_VoilierEtape1");

                entity.HasOne(d => d.VoilierIdVoilierNavigation)
                    .WithMany(p => p.Etape)
                    .HasForeignKey(d => d.VoilierIdVoilier)
                    .HasConstraintName("fk_Etape_Voilier1");
            });

            modelBuilder.Entity<Penalite>(entity =>
            {
                entity.HasKey(e => e.IdPenalite)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdPenalite).HasColumnName("idPenalite");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

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
                    .HasConstraintName("fk_Voilier_Personne1");
            });

            modelBuilder.Entity<VoilierEtape>(entity =>
            {
                entity.HasKey(e => e.IdVoilierEtape)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.PenaliteIdPenalite)
                    .HasName("fk_VoilierEtape_Penalite1_idx");

                entity.HasIndex(e => e.VoilierIdVoilier)
                    .HasName("fk_VoilierEtape_Voilier1_idx");

                entity.Property(e => e.IdVoilierEtape).HasColumnName("idVoilierEtape");

                entity.Property(e => e.DateFin).HasColumnName("DateFIn");

                entity.Property(e => e.PenaliteIdPenalite).HasColumnName("Penalite_idPenalite");

                entity.Property(e => e.VoilierIdVoilier).HasColumnName("Voilier_idVoilier");

                entity.HasOne(d => d.PenaliteIdPenaliteNavigation)
                    .WithMany(p => p.VoilierEtape)
                    .HasForeignKey(d => d.PenaliteIdPenalite)
                    .HasConstraintName("fk_VoilierEtape_Penalite1");

                entity.HasOne(d => d.VoilierIdVoilierNavigation)
                    .WithMany(p => p.VoilierEtape)
                    .HasForeignKey(d => d.VoilierIdVoilier)
                    .HasConstraintName("fk_VoilierEtape_Voilier1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
