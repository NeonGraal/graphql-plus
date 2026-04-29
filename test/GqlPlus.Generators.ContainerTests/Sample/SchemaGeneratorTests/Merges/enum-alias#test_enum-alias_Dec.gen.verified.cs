//HintName: test_enum-alias_Dec.gen.cs
// Generated from {CurrentDirectory}enum-alias.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_alias;

internal class testEnumAliasDecoder : IDecoder<testEnumAlias?>
{
  public IMessages Decoder(IValue input, out testEnumAlias? output)
    => input.DecodeEnum("EnumAlias", out output);

  internal static testEnumAliasDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_enum_aliasDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_enum_aliasDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumAlias?>(testEnumAliasDecoder.Factory);
}
