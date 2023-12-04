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
      .AddParserArray<IParserStartFragments, FragmentAst, ParseStartFragments>()
      .AddParserArray<IParserEndFragments, FragmentAst, ParseEndFragments>()
      .AddSingleton<ParseObject>()
      .AddSingleton<IParserArray<IAstSelection>>(x => x.GetRequiredService<ParseObject>())
      .AddSingleton<IParser<IAstSelection>>(x => x.GetRequiredService<ParseObject>())
      .AddSingleton<IParser<FieldAst>>(x => x.GetRequiredService<ParseObject>())
      .AddParser<OperationAst, ParseOperation>()
      .AddParser<VariableAst, ParseVariable>()
      .AddParserArray<VariableAst, ParseVariables>()
      .AddSingleton<IParserVarType, ParseVarType>();
}
