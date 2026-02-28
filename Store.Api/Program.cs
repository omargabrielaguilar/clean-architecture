// Boostrap the application
// Config de service of the application
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//GET endpoint /games


// what happen when we start the application
app.MapGet("/", () => "Hello World!");
app.Run();
// Host the application
// Use builder pattern
