using Microsoft.EntityFrameworkCore;
using XCWED2_HFT_2021221.Models.Entities;

namespace XCWED2_HFT_2021221.Repository.DbContexts
{
    public class XCWED2_HFT_2021221DbContexts : DbContext
    {
        public virtual DbSet<Publisher> Publishers { get; set; }

        public virtual DbSet<BoardGame> BoardGames { get; set; }

        public virtual DbSet<Designer> Designers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\XCWED2_HFT_2021221Db.mdf;Integrated Security=true;MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Set Relations
            modelBuilder.Entity<BoardGame>(e =>
            e.HasOne(b => b.Publisher)
            .WithMany(p => p.BoardGames)
            .HasForeignKey(b => b.PublisherID)
            .OnDelete(DeleteBehavior.ClientSetNull));

            modelBuilder.Entity<BoardGame>(e =>
            e.HasOne(b => b.Designer)
            .WithMany(d => d.BoardGames)
            .HasForeignKey(b => b.DesignerID)
            .OnDelete(DeleteBehavior.ClientSetNull));
        }

        //seed



    }
}
