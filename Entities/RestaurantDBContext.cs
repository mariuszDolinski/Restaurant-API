using Microsoft.EntityFrameworkCore;
//konfiguracja bazy danych
//wymaga dodania pakietów z using przez menadzera NuGet
namespace Restaurant_API.Entities
{
    public class RestaurantDBContext : DbContext
    {
        //można połączyć się z bazą danych przez Server Management Studio lub Azure Data Studio
        //wpisując w server name nazwę (localdb)\mssqllocaldb i autoryzację na Windows Authentication
        private string _connectionString =
            "Server=(localdb)\\mssqllocaldb;Database=RestaurantDb;Trusted_Connection=True;";
        public DbSet<Restaurant> Restaurants { get; set;}//tworzy tabelę Restautants na podstawie klasy Restaurant
        public DbSet<Address> Addresses { get; set;}
        public DbSet<Dish> Dishes { get; set;}
        
        //nadpisujemy metodę OnModelCreating aby dodać ograniczenia do tabel
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Name)
                .IsRequired()//nazwa restauracji musi być podana
                .HasMaxLength(25);//ustawiamy maksymalną długość nazwy restauracji

            modelBuilder.Entity<Dish>()
                .Property(d => d.Name)
                .IsRequired();

            //modelBuilder.Entity<Dish>()
            //    .Property(d => d.Price)
            //    .HasColumnType("decimal")//ustawiamy typ danych na decimal i precyzję
            //    .HasPrecision(5, 4);//5 cyfr łącznie, 2 po przecinku

            modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Address>()
                .Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(50);
        }

        //konfiguracja połączenia do bazy danych
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        //aby dokonać migracji wchodzimy w Tools->Nuget Package Manager->Package Manager Console
        //w konsoli wywołuemy polecenie add-migration nazwa_migracji
        //zostanie utworzony noy folder z dwoma klasami, których nie należy ręcznie zmieniać
        //pierwsza klasa ma w nazwie podaną nazwę migraci i służy do utworzenia tabel
        //druga zapisuje aktualny stan bazy danych aby kolejne migracje mogły być dokonywane
        //na podstawie tej klasy i klasy dbcontext
        //
        //potem w tej samej konsoli należy wywołać polecenie update-database

        //zasilanie bazy danych danymi (seedowanie) odbywa się przez serwis w klasie RestaurantSeeder
    }
}
