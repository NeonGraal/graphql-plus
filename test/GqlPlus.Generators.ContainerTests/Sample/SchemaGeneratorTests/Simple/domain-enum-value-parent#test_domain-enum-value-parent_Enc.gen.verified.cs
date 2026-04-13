//HintName: test_domain-enum-value-parent_Enc.gen.cs
// Generated from {CurrentDirectory}domain-enum-value-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_value_parent;

internal class testDmnEnumValuePrntEncoder : IEncoder<ItestDmnEnumValuePrnt>
{
  public Structured Encode(ItestDmnEnumValuePrnt input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumValuePrntEncoder : IEncoder<testEnumDmnEnumValuePrnt>
{
  public Structured Encode(testEnumDmnEnumValuePrnt input)
    => new(input.ToString(), "_EnumDmnEnumValuePrnt");
}

internal class testPrntDmnEnumValuePrntEncoder : IEncoder<testPrntDmnEnumValuePrnt>
{
  public Structured Encode(testPrntDmnEnumValuePrnt input)
    => new(input.ToString(), "_PrntDmnEnumValuePrnt");
}
