using GqlPlus.Ast;
using GqlPlus.Ast.Operation;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parse.Operation;

public static class OperationParsers
{
  public static IServiceCollection AddOperationParsers(this IServiceCollection services)
    => services
      .AddParser<IParserArgument, ArgumentAst, ParseArgument>()
      .AddValueParsers<ArgumentAst, ParseArgumentValue>()
      .AddParserArray<DirectiveAst, ParseDirectives>()
      .AddParserArray<IParserStartFragments, FragmentAst, ParseStartFragments>()
      .AddParserArray<IParserEndFragments, FragmentAst, ParseEndFragments>()
      .AddParserArray<IAstSelection, ParseObject>()
      .AddParser<IAstSelection, ParseSelection>()
      .AddParser<FieldAst, ParseField>()
      .AddParser<OperationAst, ParseOperation>()
      .AddParser<VariableAst, ParseVariable>()
      .AddParserArray<VariableAst, ParseVariables>()
      .AddParser<IParserVarType, string, ParseVarType>();
}
