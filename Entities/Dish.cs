namespace Restaurant_API.Entities
{
    public class Dish
    {
        public int Id { get; set; }//primary key
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int RestaurantId { get; set; }//foreign key for Restaurant entity
        public Restaurant Restaurant { get; set; }
    }
}
