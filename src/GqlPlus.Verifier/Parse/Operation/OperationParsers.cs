using GqlPlus.Verifier.Ast;
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
      .AddParserValue<ArgumentAst, ParseArgumentValue>()
      .AddSingleton<IParserArray<DirectiveAst>, ParseDirectives>()
      .AddSingleton<IParserStartFragments, ParseStartFragments>()
      .AddSingleton<IParserEndFragments, ParseEndFragments>()
      .AddSingleton<ParseObject>()
      .AddSingleton<IParserArray<IAstSelection>>(x => x.GetRequiredService<ParseObject>())
      .AddSingleton<IParser<IAstSelection>>(x => x.GetRequiredService<ParseObject>())
      .AddSingleton<IParser<FieldAst>>(x => x.GetRequiredService<ParseObject>())
      .AddSingleton<IParser<VariableAst>, ParseVariable>()
      .AddSingleton<IParserArray<VariableAst>, ParseVariables>()
      .AddSingleton<IParserVarType, ParseVarType>();
}
