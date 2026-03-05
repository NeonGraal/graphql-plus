WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

WebApplication app = builder.Build();
app.MapControllers();

app.Run();

// Expose Program class for WebApplicationFactory discovery in tests
#pragma warning disable ASP0027 // Unnecessary public Program class declaration
public partial class Program { }
#pragma warning restore ASP0027 // Unnecessary public Program class declaration
