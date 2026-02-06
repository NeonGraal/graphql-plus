WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

WebApplication app = builder.Build();
app.MapControllers();

app.Run();

// Expose Program class for WebApplicationFactory discovery in tests
public partial class Program { }
