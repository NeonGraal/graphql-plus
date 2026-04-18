//HintName: test_enum-same-parent_Enc.gen.cs
// Generated from {CurrentDirectory}enum-same-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_same_parent;

internal class testEnumSamePrntEncoder : IEncoder<testEnumSamePrnt>
{
  public Structured Encode(testEnumSamePrnt input)
    => new(input.ToString(), "_EnumSamePrnt");

  internal static testEnumSamePrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntEnumSamePrntEncoder : IEncoder<testPrntEnumSamePrnt>
{
  public Structured Encode(testPrntEnumSamePrnt input)
    => new(input.ToString(), "_PrntEnumSamePrnt");

  internal static testPrntEnumSamePrntEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_enum_same_parentEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_enum_same_parentEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<testEnumSamePrnt>(testEnumSamePrntEncoder.Factory)
      .AddEncoder<testPrntEnumSamePrnt>(testPrntEnumSamePrntEncoder.Factory);
}
