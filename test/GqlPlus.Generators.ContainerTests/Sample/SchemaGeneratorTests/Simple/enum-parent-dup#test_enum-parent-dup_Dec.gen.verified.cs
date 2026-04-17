//HintName: test_enum-parent-dup_Dec.gen.cs
// Generated from {CurrentDirectory}enum-parent-dup.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_parent_dup;

internal class testEnumPrntDupDecoder
{
  public string prnt_enumPrntDup { get; set; }
  public string enumPrntDup { get; set; }
  public string enumPrntDup { get; set; }

  internal static testEnumPrntDupDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumPrntDupDecoder
{
  public string prnt_enumPrntDup { get; set; }
  public string enumPrntDup { get; set; }

  internal static testPrntEnumPrntDupDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_enum_parent_dupDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_enum_parent_dupDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumPrntDup>(testEnumPrntDupDecoder.Factory)
      .AddDecoder<testPrntEnumPrntDup>(testPrntEnumPrntDupDecoder.Factory);
}
