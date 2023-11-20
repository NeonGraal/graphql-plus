using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifier.Parse.Operation;

public class Startup
{
  public void ConfigureServices(IServiceCollection services)
    => services.AddOperationParsers();
}
