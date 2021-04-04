using Microsoft.EntityFrameworkCore;


namespace mysqlefcore
{
    public class Voilier : DbContext
    {
        public DbSet<Course> Course { get; set; }

        public DbSet<Etape> Etape { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=library;user=phpmyadmin;password=Clementine1011%");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Etape>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.ISBN);
                entity.Property(e => e.Title).IsRequired();
                entity.HasOne(d => d.Etape)
                    .WithMany(p => p.Books);
            });
        }
    }
}