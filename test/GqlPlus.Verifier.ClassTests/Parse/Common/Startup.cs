using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifier.Parse.Common;

public class Startup
{
  public void ConfigureServices(IServiceCollection services)
    => services
      .AddSingleton<IParser<FieldKeyAst>, ParseFieldKey>();
}
