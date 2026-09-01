using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parser;

public sealed class ParserTestServices : IConfiguresServices
{
  public static IServiceCollection Configure(IServiceCollection services)
    => services
      .AddManyChecks<IParserCollections, IAstModifier>()
      .AddOneChecks<IAstConstant>()
      .AddOneChecks<IParserDefault, IAstConstant>()
      .AddOneChecks<IAstFieldKey>()
      .AddOneChecks<KeyValue<IAstConstant>>()
      .AddManyChecks<IAstModifier>()

      .AddComponentTest();
}
