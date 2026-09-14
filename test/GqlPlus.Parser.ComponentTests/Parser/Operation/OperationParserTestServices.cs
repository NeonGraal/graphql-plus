using GqlPlus.Ast.Operation;
using GqlPlus.Parsing.Operation;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parser.Operation;

public sealed class OperationParserTestServices : IConfiguresServices
{
  public static IServiceCollection Configure(IServiceCollection services)
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
