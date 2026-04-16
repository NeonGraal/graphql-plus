//HintName: test_enum-alias_Dec.gen.cs
// Generated from {CurrentDirectory}enum-alias.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_alias;

internal class testEnumAliasDecoder
{
  public string enumAlias { get; set; }

  internal static testEnumAliasDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_enum_aliasDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_enum_aliasDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumAlias>(testEnumAliasDecoder.Factory);
}
