// Boostrap the application
// Config de service of the application
using Store.Api.Dtos;
const string EndpointName = "GetGames";
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games =
[
    new (1, "The Legend of Zelda: Breath of the Wild", "Action-Adventure", 59.99m, new DateOnly(2017, 3, 3)),
    new (2, "Super Mario Odyssey", "Platformer", 59.99m, new DateOnly(2017, 10, 27)),
    new (3, "Red Dead Redemption 2", "Action-Adventure", 59.99m, new DateOnly(2018, 10, 26)),
    new (4, "The Witcher 3: Wild Hunt", "RPG", 39.99m, new DateOnly(2015, 5, 19)),
    new (5, "God of War", "Action-Adventure", 49.99m, new DateOnly(2018, 4, 20))
];

//GET endpoint /games
// what happen when we start the application
app.MapGet("/games", () => games);
app.MapGet("/games/{id}", (int id) => games.Find(game => game.Id == id))
    .WithName(EndpointName);


//POST endpoint /games
app.MapPost("/games", (CreateGameDto createGameDto) =>
{
  GameDto game = new(
    games.Count + 1,
    createGameDto.Name,
    createGameDto.Genre,
    createGameDto.Price,
    createGameDto.ReleaseDate
  );

  games.Add(game);

  return Results.CreatedAtRoute(EndpointName, new { id = game.Id }, game);
});

app.Run();


// Host the application
// Use builder pattern
