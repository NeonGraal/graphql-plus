using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifier.Parse.Operation;

public static class OperationParsers
{
  public static IServiceCollection AddOperationParsers(this IServiceCollection services)
    => services
      .AddParser<IParserArgument, ArgumentAst, ParseArgument>()
      .AddValueParsers<ArgumentAst, ParseArgumentValue>()
      .AddParserArray<DirectiveAst, ParseDirectives>()
      .AddSingleton<IParserStartFragments, ParseStartFragments>()
      .AddSingleton<IParserEndFragments, ParseEndFragments>()
      .AddSingleton<ParseObject>()
      .AddSingleton<IParserArray<IAstSelection>>(x => x.GetRequiredService<ParseObject>())
      .AddSingleton<IParser<IAstSelection>>(x => x.GetRequiredService<ParseObject>())
      .AddSingleton<IParser<FieldAst>>(x => x.GetRequiredService<ParseObject>())
      .AddSingleton<IParser<OperationAst>, ParseOperation>()
      .AddSingleton<IParser<VariableAst>, ParseVariable>()
      .AddSingleton<IParserArray<VariableAst>, ParseVariables>()
      .AddSingleton<IParserVarType, ParseVarType>();
}
