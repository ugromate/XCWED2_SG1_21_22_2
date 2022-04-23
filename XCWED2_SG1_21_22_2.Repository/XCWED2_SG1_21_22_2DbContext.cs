using Microsoft.EntityFrameworkCore;
using XCWED2_SG1_21_22_2.Models.Entities;

namespace XCWED2_SG1_21_22_2.Repository.DbContexts
{
    public class XCWED2_SG1_21_22_2DbContext : DbContext
    {
        public virtual DbSet<Publisher> Publishers { get; set; }

        public virtual DbSet<BoardGame> BoardGames { get; set; }

        public virtual DbSet<Designer> Designers { get; set; }

        public XCWED2_SG1_21_22_2DbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\XCWED2_SG1_21_22_2Db.mdf;Integrated Security=true;MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Set Relations
            modelBuilder.Entity<BoardGame>(e =>
            e.HasOne(b => b.Publisher)
            .WithMany(p => p.BoardGames)
            .HasForeignKey(b => b.PublisherID)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<BoardGame>(e =>
            e.HasOne(b => b.Designer)
            .WithMany(d => d.BoardGames)
            .HasForeignKey(b => b.DesignerID)
            .OnDelete(DeleteBehavior.Cascade));


            //seed
            var zmangames = new Publisher() { Id = 1, Name = "Z - Man Games", Country = "US" };
            var kosmos = new Publisher() { Id = 2, Name = "KOSMOS", Country = "Germany" };
            var reflexshop = new Publisher() { Id = 3, Name = "Reflexshop", Country = "Hungary" };
            var ffg = new Publisher() { Id = 4, Name = "Fantasy Flight Games", Country = "US" };

            var pandemic = new BoardGame() { Id = 1, Name = "Pandemic", DesignerID = 1, PublisherID = 1, MinPlayer = 2, MaxPlayer = 4, MinAge = 8, Rating = 7.6, PriceHUF = 10000 };
            var carcassonne = new BoardGame() { Id = 2, Name = "Carcassone", DesignerID = 3, PublisherID = 1, MinPlayer = 2, MaxPlayer = 5, MinAge = 7, Rating = 7.4, PriceHUF = 7300 };
            var loveLetter = new BoardGame() { Id = 3, Name = "Love Letter", DesignerID = 4, PublisherID = 1, MinPlayer = 2, MaxPlayer = 4, MinAge = 10, Rating = 7.2, PriceHUF = 4700 };
            var marcoPolo = new BoardGame() { Id = 4, Name = "The Voyages of Marco Polo", DesignerID = 5, PublisherID = 1, MinPlayer = 2, MaxPlayer = 4, MinAge = 12, Rating = 7.9, PriceHUF = 15000 };
            var hamikoji = new BoardGame() { Id = 5, Name = "Hanamikoji", DesignerID = 6, PublisherID = 3, MinPlayer = 2, MaxPlayer = 2, MinAge = 10, Rating = 7.5, PriceHUF = 4000 };
            var forbiddendesert = new BoardGame() { Id = 6, Name = "Forbidden Desert", DesignerID = 1, PublisherID = 3, MinPlayer = 2, MaxPlayer = 5, MinAge = 10, Rating = 7.1, PriceHUF = 8000 };
            var forbiddenisland = new BoardGame() { Id = 7, Name = "Forbidden Island", DesignerID = 1, PublisherID = 3, MinPlayer = 2, MaxPlayer = 4, MinAge = 10, Rating = 6.8, PriceHUF = 7000 };
            var catan = new BoardGame() { Id = 8, Name = "Settlers of Catan", DesignerID = 2, PublisherID = 2, MinPlayer = 3, MaxPlayer = 4, MinAge = 10, Rating = 7.1, PriceHUF = 9000 };
            var anno1503 = new BoardGame() { Id = 9, Name = "Anno 1503", DesignerID = 2, PublisherID = 2, MinPlayer = 2, MaxPlayer = 4, MinAge = 10, Rating = 6.2, PriceHUF = 10000 };
            var arkhamhorror = new BoardGame() { Id = 10, Name = "Arkham Horror", DesignerID = 7, PublisherID = 4, MinPlayer = 1, MaxPlayer = 8, MinAge = 14, Rating = 7.3, PriceHUF = 18000 };
            var eldritchhorror = new BoardGame() { Id = 11, Name = "Eldritch Horror", DesignerID = 7, PublisherID = 4, MinPlayer = 1, MaxPlayer = 8, MinAge = 10, Rating = 7.8, PriceHUF = 19000 };
            var android = new BoardGame() { Id = 12, Name = "Android", DesignerID = 7, PublisherID = 4, MinPlayer = 3, MaxPlayer = 5, MinAge = 13, Rating = 6.7, PriceHUF = 40000 };

            var matt = new Designer() { Id = 1, Name = "Matt Leacock", Nationality = "US" };
            var klaus = new Designer() { Id = 2, Name = "Klaus Teuber", Nationality = "German" };
            var jurge = new Designer() { Id = 3, Name = "Klaus-Jürgen Wrede", Nationality = "German" };
            var seiji = new Designer() { Id = 4, Name = "Seiji Kanai", Nationality = "Japan" };
            var dennis = new Designer() { Id = 5, Name = "Dennis Lohausen", Nationality = "German" };
            var kota = new Designer() { Id = 6, Name = "Kota Nakayama", Nationality = "Japan" };
            var kevin = new Designer() { Id = 7, Name = "Kevin Wilson", Nationality = "US" };

            //upload
            modelBuilder.Entity<Publisher>().HasData(zmangames, kosmos, reflexshop, ffg);
            modelBuilder.Entity<BoardGame>().HasData(pandemic, carcassonne, loveLetter, marcoPolo, hamikoji, forbiddendesert, forbiddenisland, catan, anno1503, arkhamhorror, eldritchhorror, android);
            modelBuilder.Entity<Designer>().HasData(matt, klaus, jurge, seiji, dennis, kota, kevin);

        }



    }
}
