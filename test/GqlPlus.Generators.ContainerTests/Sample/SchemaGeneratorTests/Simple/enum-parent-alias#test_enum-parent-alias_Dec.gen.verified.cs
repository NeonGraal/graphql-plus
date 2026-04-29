//HintName: test_enum-parent-alias_Dec.gen.cs
// Generated from {CurrentDirectory}enum-parent-alias.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_parent_alias;

internal class testEnumPrntAliasDecoder : IDecoder<testEnumPrntAlias?>
{
  public IMessages Decoder(IValue input, out testEnumPrntAlias? output)
    => input.DecodeEnum("EnumPrntAlias", out output);

  internal static testEnumPrntAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumPrntAliasDecoder : IDecoder<testPrntEnumPrntAlias?>
{
  public IMessages Decoder(IValue input, out testPrntEnumPrntAlias? output)
    => input.DecodeEnum("PrntEnumPrntAlias", out output);

  internal static testPrntEnumPrntAliasDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_enum_parent_aliasDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_enum_parent_aliasDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumPrntAlias?>(testEnumPrntAliasDecoder.Factory)
      .AddDecoder<testPrntEnumPrntAlias?>(testPrntEnumPrntAliasDecoder.Factory);
}
