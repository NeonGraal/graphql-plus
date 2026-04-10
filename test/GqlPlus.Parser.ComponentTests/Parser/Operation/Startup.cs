using GqlPlus.Abstractions.Operation;
using GqlPlus.Parsing.Operation;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parser.Operation;

public static class Startup
{
  public static void ConfigureServices(IServiceCollection services)
    => services
      .AddOneChecks<IParserArg, IGqlpArg>()
      .AddOneChecks<IGqlpArg>()
      .AddManyChecks<IAstDirective>()
      .AddOneChecks<IGqlpField>()
      .AddManyChecks<IParserStartFragments, IAstFragment>()
      .AddManyChecks<IParserEndFragments, IAstFragment>()
      .AddManyChecks<IGqlpSelection>()
      .AddOneChecks<IGqlpSelection>()
      .AddManyChecks<IAstVariable>()
      .AddOneChecks<IAstVariable>()
      .AddOneChecks<IParserVarType, string>()

      .AddComponentTest()
      .AddParsers(b => b.AddOperationParsers());
}
