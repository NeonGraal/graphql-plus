using GqlPlus.Parsing.Operation;

namespace GqlPlus.Parsing;

public static class OperationParsers
{
  public static IParserRepositoryBuilder AddOperationParsers([NotNull] this IParserRepositoryBuilder builder)
    => builder
        .AddSingle(p => new ParseOperation(p))
        .AddOperationVariableParsers()
        .AddOperationPrefixParsers()
        .AddOperationResultParsers();

  public static IParserRepositoryBuilder AddOperationVariableParsers([NotNull] this IParserRepositoryBuilder builder)
    => builder
        .AddSingle(p => new ParseVariable(p))
        .AddArray(p => new ParseVariables(p))
        .AddInterfaceSingle<IParserVarType>(_ => new ParseVarType());

  public static IParserRepositoryBuilder AddOperationPrefixParsers([NotNull] this IParserRepositoryBuilder builder)
    => builder
        .AddArray(p => new ParseDirectives(p))
        .AddInterfaceArray<IParserStartFragments>(p => new ParseStartFragments(p))
        .AddInterfaceArray<IParserEndFragments>(p => new ParseEndFragments(p));

  public static IParserRepositoryBuilder AddOperationResultParsers([NotNull] this IParserRepositoryBuilder builder)
    => builder
        .AddArray(p => new ParseObject(p))
        .AddSingle(p => new ParseSelection(p))
        .AddSingle(p => new ParseField(p))
        .AddInterfaceSingle<IParserArg>(p => new ParseArg(p))
        .AddValueParsers(p => new ParseArgValue(p));
}
