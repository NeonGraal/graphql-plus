//HintName: test_enum-same-parent_Dec.gen.cs
// Generated from {CurrentDirectory}enum-same-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_same_parent;

internal class testEnumSamePrntDecoder : NullDecoder<testEnumSamePrnt>
{
  public string prnt_enumSamePrnt { get; set; } = default!;
  public string enumSamePrnt { get; set; } = default!;

  internal static testEnumSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumSamePrntDecoder : NullDecoder<testPrntEnumSamePrnt>
{
  public string prnt_enumSamePrnt { get; set; } = default!;

  internal static testPrntEnumSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_enum_same_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_enum_same_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumSamePrnt>(testEnumSamePrntDecoder.Factory)
      .AddDecoder<testPrntEnumSamePrnt>(testPrntEnumSamePrntDecoder.Factory);
}
