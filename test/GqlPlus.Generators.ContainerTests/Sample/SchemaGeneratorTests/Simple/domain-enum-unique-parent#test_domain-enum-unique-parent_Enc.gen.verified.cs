//HintName: test_domain-enum-unique-parent_Enc.gen.cs
// Generated from {CurrentDirectory}domain-enum-unique-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_unique_parent;

internal class testDmnEnumUnqPrntEncoder : IEncoder<ItestDmnEnumUnqPrnt>
{
  public Structured Encode(ItestDmnEnumUnqPrnt input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumUnqPrntEncoder : IEncoder<testEnumDmnEnumUnqPrnt>
{
  public Structured Encode(testEnumDmnEnumUnqPrnt input)
    => new(input.ToString(), "_EnumDmnEnumUnqPrnt");
}

internal class testPrntDmnEnumUnqPrntEncoder : IEncoder<testPrntDmnEnumUnqPrnt>
{
  public Structured Encode(testPrntDmnEnumUnqPrnt input)
    => new(input.ToString(), "_PrntDmnEnumUnqPrnt");
}

internal class testDupDmnEnumUnqPrntEncoder : IEncoder<testDupDmnEnumUnqPrnt>
{
  public Structured Encode(testDupDmnEnumUnqPrnt input)
    => new(input.ToString(), "_DupDmnEnumUnqPrnt");
}
