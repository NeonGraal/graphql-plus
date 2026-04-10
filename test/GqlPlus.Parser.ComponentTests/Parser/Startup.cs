using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parser;

public static class Startup
{
  public static void ConfigureServices(IServiceCollection services)
    => services
      .AddManyChecks<IParserCollections, IAstModifier>()
      .AddOneChecks<IAstConstant>()
      .AddOneChecks<IParserDefault, IAstConstant>()
      .AddOneChecks<IAstFieldKey>()
      .AddOneChecks<KeyValue<IAstConstant>>()
      .AddManyChecks<IAstModifier>()

      .AddComponentTest();
}
