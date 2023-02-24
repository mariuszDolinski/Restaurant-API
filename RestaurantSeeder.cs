using Restaurant_API.Entities;

namespace Restaurant_API
{
    public class RestaurantSeeder
    {
        private RestaurantDBContext _dbContext;
        public RestaurantSeeder(RestaurantDBContext dbContext)
        {
            _dbContext= dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())//sprawdzamy czy można zawiązać połączenie z bazą danych
            {
                //jeśli tabela Restaurants nie zawiera żadnych danych, to możemy dodać te które mają być zawsze
                if(!_dbContext.Restaurants.Any())
                {
                    var restaurant = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurant);//dodanie wierszy do tabeli Restaurants
                    _dbContext.SaveChanges();//trzeba zaisać dane aby dodały się do bazy danych
                }
            }
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Description =
                        "KFC (short for Kentucky Fried Chicken) is an American fast food restaurant chain headquartered in Louisville, Kentucky, that specializes in fried chicken.",
                    ContactEmail = "contact@kfc.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Nashville Hot Chicken",
                            Price = 10.30M,
                        },

                        new Dish()
                        {
                            Name = "Chicken Nuggets",
                            Price = 5.30M,
                        },
                    },
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Długa 5",
                        PostalCode = "30-001"
                    }
                },
                new Restaurant()
                {
                    Name = "McDonald Szewska",
                    Description =
                        "McDonald's Corporation (McDonald's), incorporated on December 21, 1964, operates and franchises McDonald's restaurants.",
                    ContactEmail = "contact@mcdonald.com",
                    HasDelivery = true,
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Szewska 2",
                        PostalCode = "30-001"
                    }
                }
            };

            return restaurants;
        }
    }
}
