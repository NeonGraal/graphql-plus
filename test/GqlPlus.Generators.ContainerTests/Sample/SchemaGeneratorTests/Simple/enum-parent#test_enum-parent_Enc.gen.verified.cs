//HintName: test_enum-parent_Enc.gen.cs
// Generated from {CurrentDirectory}enum-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_parent;

internal class testEnumPrntEncoder : IEncoder<testEnumPrnt>
{
  public Structured Encode(testEnumPrnt input)
    => new(input.ToString(), "_EnumPrnt");
}

internal class testPrntEnumPrntEncoder : IEncoder<testPrntEnumPrnt>
{
  public Structured Encode(testPrntEnumPrnt input)
    => new(input.ToString(), "_PrntEnumPrnt");
}
