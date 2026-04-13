//HintName: test_enum-parent-dup_Enc.gen.cs
// Generated from {CurrentDirectory}enum-parent-dup.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_parent_dup;

internal class testEnumPrntDupEncoder : IEncoder<testEnumPrntDup>
{
  public Structured Encode(testEnumPrntDup input)
    => new(input.ToString(), "_EnumPrntDup");
}

internal class testPrntEnumPrntDupEncoder : IEncoder<testPrntEnumPrntDup>
{
  public Structured Encode(testPrntEnumPrntDup input)
    => new(input.ToString(), "_PrntEnumPrntDup");
}
