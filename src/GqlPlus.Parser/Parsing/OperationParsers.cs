using GqlPlus.Parsing.Operation;

namespace GqlPlus.Parsing;

public static class OperationParsers
{
  public static IParserRepositoryBuilder AddOperationParsers([NotNull] this IParserRepositoryBuilder builder)
    => builder
        .AddSingle(ParseOperation.Factory)
        .AddOperationVariableParsers()
        .AddOperationPrefixParsers()
        .AddOperationResultParsers();

  public static IParserRepositoryBuilder AddOperationVariableParsers([NotNull] this IParserRepositoryBuilder builder)
    => builder
        .AddSingle(ParseVariable.Factory)
        .AddArray(ParseVariables.Factory)
        .AddInterfaceSingle<IParserVarType>(ParseVarType.Factory);

  public static IParserRepositoryBuilder AddOperationPrefixParsers([NotNull] this IParserRepositoryBuilder builder)
    => builder
        .AddArray(ParseDirectives.Factory)
        .AddInterfaceArray<IParserStartFragments>(ParseStartFragments.Factory)
        .AddInterfaceArray<IParserEndFragments>(ParseEndFragments.Factory);

  public static IParserRepositoryBuilder AddOperationResultParsers([NotNull] this IParserRepositoryBuilder builder)
    => builder
        .AddArray(ParseObject.Factory)
        .AddSingle(ParseSelection.Factory)
        .AddSingle(ParseField.Factory)
        .AddInterfaceSingle<IParserArg>(ParseArg.Factory)
        .AddValueParsers(ParseArgValue.Factories);
}
