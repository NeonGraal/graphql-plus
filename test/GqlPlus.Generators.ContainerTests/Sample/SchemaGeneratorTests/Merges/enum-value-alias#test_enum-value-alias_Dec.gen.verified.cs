//HintName: test_enum-value-alias_Dec.gen.cs
// Generated from {CurrentDirectory}enum-value-alias.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_value_alias;

internal class testEnumValueAliasDecoder
{
  public string enumValueAlias { get; set; }
  public string val1 { get; set; }
  public string val2 { get; set; }

  internal static testEnumValueAliasDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_enum_value_aliasDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_enum_value_aliasDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumValueAlias>(testEnumValueAliasDecoder.Factory);
}
