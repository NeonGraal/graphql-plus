using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parsing.Operation;

public static class OperationParsers
{
  public static IServiceCollection AddOperationParsers(this IServiceCollection services)
    => services
      .AddParser<IParserArgument, ArgumentAst, ParseArgument>()
      .AddValueParsers<ArgumentAst, ParseArgumentValue>()
      .AddParserArray<IGqlpDirective, ParseDirectives>()
      .AddParserArray<IParserStartFragments, IGqlpFragment, ParseStartFragments>()
      .AddParserArray<IParserEndFragments, IGqlpFragment, ParseEndFragments>()
      .AddParserArray<IGqlpSelection, ParseObject>()
      .AddParser<IGqlpSelection, ParseSelection>()
      .AddParser<IGqlpField, ParseField>()
      .AddParser<IGqlpOperation, ParseOperation>()
      .AddParser<IGqlpVariable, ParseVariable>()
      .AddParserArray<IGqlpVariable, ParseVariables>()
      .AddParser<IParserVarType, string, ParseVarType>();
}
