//HintName: test_enum-value-alias_Dec.gen.cs
// Generated from {CurrentDirectory}enum-value-alias.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_value_alias;

internal class testEnumValueAliasDecoder : NullDecoder<testEnumValueAlias>
{
  public string enumValueAlias { get; set; } = default!;
  public string val1 { get; set; } = default!;
  public string val2 { get; set; } = default!;

  internal static testEnumValueAliasDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_enum_value_aliasDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_enum_value_aliasDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumValueAlias>(testEnumValueAliasDecoder.Factory);
}
