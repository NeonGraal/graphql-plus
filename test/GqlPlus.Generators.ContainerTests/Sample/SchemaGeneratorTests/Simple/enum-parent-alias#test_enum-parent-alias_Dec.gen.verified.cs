//HintName: test_enum-parent-alias_Dec.gen.cs
// Generated from {CurrentDirectory}enum-parent-alias.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_parent_alias;

internal class testEnumPrntAliasDecoder
{
  public string prnt_enumPrntAlias { get; set; }
  public string val_enumPrntAlias { get; set; }
  public string prnt_enumPrntAlias { get; set; }
  public string enumPrntAlias { get; set; }

  internal static testEnumPrntAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumPrntAliasDecoder
{
  public string prnt_enumPrntAlias { get; set; }

  internal static testPrntEnumPrntAliasDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_enum_parent_aliasDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_enum_parent_aliasDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumPrntAlias>(testEnumPrntAliasDecoder.Factory)
      .AddDecoder<testPrntEnumPrntAlias>(testPrntEnumPrntAliasDecoder.Factory);
}
