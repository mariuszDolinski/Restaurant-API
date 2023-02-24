using Restaurant_API;
using Restaurant_API.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<RestaurantDBContext>();//inicjujemy serwis bazy danych
builder.Services.AddScoped<RestaurantSeeder>();//incjujemy serwis seeduj¹cy 

var app = builder.Build();

// Configure the HTTP request pipeline.

var scope = app.Services.CreateScope();//tworzymy scope bo tak dodane by³o RestaurantSeeder
//pobieramy serwis RestaurantSeeder aby wywo³aæ jego metodê Seed()
var seeder = scope.ServiceProvider.GetRequiredService<RestaurantSeeder>();
seeder.Seed();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
