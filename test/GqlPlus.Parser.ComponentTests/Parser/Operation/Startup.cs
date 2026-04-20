using GqlPlus.Ast.Operation;
using GqlPlus.Parsing.Operation;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parser.Operation;

public static class Startup
{
  public static void ConfigureServices(IServiceCollection services)
    => services
      .AddOneChecks<IParserArg, IAstArg>()
      .AddOneChecks<IAstArg>()
      .AddManyChecks<IAstDirective>()
      .AddOneChecks<IAstField>()
      .AddManyChecks<IParserStartFragments, IAstFragment>()
      .AddManyChecks<IParserEndFragments, IAstFragment>()
      .AddManyChecks<IAstSelection>()
      .AddOneChecks<IAstSelection>()
      .AddManyChecks<IAstVariable>()
      .AddOneChecks<IAstVariable>()
      .AddOneChecks<IParserVarType, string>()

      .AddComponentTest()
      .AddParsers(b => b.AddOperationParsers());
}
