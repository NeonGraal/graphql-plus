using GqlPlus.Verifier.Ast.Operation;
using GqlPlus.Verifier.Parse.Common;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifier.Parse.Operation;

public static class OperationParsers
{
  public static IServiceCollection AddOperationParsers(this IServiceCollection services)
    => services
      .AddCommonParsers()
      .AddSingleton<IParserArgument, ParseArgument>()
      .AddSingleton<IParser<ArgumentAst>, ParseArgumentValue>()
      .AddSingleton<IParserArray<DirectiveAst>, ParseDirectives>()
      .AddSingleton<IParser<VariableAst>, ParseVariable>();
}
