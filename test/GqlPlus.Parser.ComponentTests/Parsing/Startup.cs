using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parsing;

public static class Startup
{
  public static void ConfigureServices(IServiceCollection services)
    => services
      .AddManyChecks<IParserCollections, IGqlpModifier>()
      .AddOneChecks<IGqlpConstant>()
      .AddOneChecks<IParserDefault, IGqlpConstant>()
      .AddOneChecks<IGqlpFieldKey>()
      .AddOneChecks<KeyValue<IGqlpConstant>>()
      .AddManyChecks<IGqlpModifier>()

      .AddComponentTest();
}
