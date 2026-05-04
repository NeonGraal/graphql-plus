// Expose Program class for WebApplicationFactory discovery in tests
#pragma warning disable CA1050 // Declare types in namespaces
public partial class Program
{
  private static void Main(string[] args)
  {
    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
    builder.Services.AddControllers();

    WebApplication app = builder.Build();
    app.MapControllers();

    app.Run();
  }
}
#pragma warning restore CA1050 // Declare types in namespaces
