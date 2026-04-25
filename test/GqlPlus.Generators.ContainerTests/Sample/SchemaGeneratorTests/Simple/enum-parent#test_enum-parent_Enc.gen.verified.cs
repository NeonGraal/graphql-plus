//HintName: test_enum-parent_Enc.gen.cs
// Generated from {CurrentDirectory}enum-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_parent;

internal class testEnumPrntEncoder : IEncoder<testEnumPrnt>
{
  public Structured Encode(testEnumPrnt input)
    => input.EncodeEnum("EnumPrnt");

  internal static testEnumPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntEnumPrntEncoder : IEncoder<testPrntEnumPrnt>
{
  public Structured Encode(testPrntEnumPrnt input)
    => input.EncodeEnum("PrntEnumPrnt");

  internal static testPrntEnumPrntEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_enum_parentEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_enum_parentEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<testEnumPrnt>(testEnumPrntEncoder.Factory)
      .AddEncoder<testPrntEnumPrnt>(testPrntEnumPrntEncoder.Factory);
}
