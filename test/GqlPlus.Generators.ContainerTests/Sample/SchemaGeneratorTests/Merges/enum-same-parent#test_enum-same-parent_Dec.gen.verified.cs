//HintName: test_enum-same-parent_Dec.gen.cs
// Generated from {CurrentDirectory}enum-same-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_same_parent;

internal class testEnumSamePrntDecoder
{
  public string prnt_enumSamePrnt { get; set; }
  public string enumSamePrnt { get; set; }

  internal static testEnumSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumSamePrntDecoder
{
  public string prnt_enumSamePrnt { get; set; }

  internal static testPrntEnumSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_enum_same_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_enum_same_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumSamePrnt>(testEnumSamePrntDecoder.Factory)
      .AddDecoder<testPrntEnumSamePrnt>(testPrntEnumSamePrntDecoder.Factory);
}
