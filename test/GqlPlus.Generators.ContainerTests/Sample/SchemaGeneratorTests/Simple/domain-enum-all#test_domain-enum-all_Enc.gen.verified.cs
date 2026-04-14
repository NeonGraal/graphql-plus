//HintName: test_domain-enum-all_Enc.gen.cs
// Generated from {CurrentDirectory}domain-enum-all.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_all;

internal class testDmnEnumAllEncoder : IEncoder<ItestDmnEnumAll>
{
  public Structured Encode(ItestDmnEnumAll input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumAllEncoder : IEncoder<testEnumDmnEnumAll>
{
  public Structured Encode(testEnumDmnEnumAll input)
    => new(input.ToString(), "_EnumDmnEnumAll");
}
