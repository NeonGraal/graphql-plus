using GqlPlus.Parsing.Operation;

namespace GqlPlus.Parsing;

public static class OperationParsers
{
  public static IParserRepositoryBuilder AddOperationParsers([NotNull] this IParserRepositoryBuilder builder)
    => builder
        .AddInterfaceSingle<IParserArg>(p => new ParseArg(p))
        .AddValueParsers(p => new ParseArgValue(p))
        .AddArray(p => new ParseDirectives(p))
        .AddInterfaceArray<IParserStartFragments>(p => new ParseStartFragments(p))
        .AddInterfaceArray<IParserEndFragments>(p => new ParseEndFragments(p))
        .AddArray(p => new ParseObject(p))
        .AddSingle(p => new ParseSelection(p))
        .AddSingle(p => new ParseField(p))
        .AddSingle(p => new ParseOperation(p))
        .AddSingle(p => new ParseVariable(p))
        .AddArray(p => new ParseVariables(p))
        .AddInterfaceSingle<IParserVarType>(_ => new ParseVarType());
}
