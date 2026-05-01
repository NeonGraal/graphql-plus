//HintName: test_enum-value-alias_Dec.gen.cs
// Generated from {CurrentDirectory}enum-value-alias.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_value_alias;

internal class testEnumValueAliasDecoder : IDecoder<testEnumValueAlias?>
{
  public IMessages Decode(IValue input, out testEnumValueAlias? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumValueAlias value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumValueAlias".AnError();
  }

  internal static testEnumValueAliasDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_enum_value_aliasDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_enum_value_aliasDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumValueAlias?>(testEnumValueAliasDecoder.Factory);
}
