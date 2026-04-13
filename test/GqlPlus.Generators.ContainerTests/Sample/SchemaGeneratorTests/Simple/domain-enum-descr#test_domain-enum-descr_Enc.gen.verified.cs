//HintName: test_domain-enum-descr_Enc.gen.cs
// Generated from {CurrentDirectory}domain-enum-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_descr;

internal class testDmnEnumDescrEncoder : IEncoder<ItestDmnEnumDescr>
{
  public Structured Encode(ItestDmnEnumDescr input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumDescrEncoder : IEncoder<testEnumDmnEnumDescr>
{
  public Structured Encode(testEnumDmnEnumDescr input)
    => new(input.ToString(), "_EnumDmnEnumDescr");
}
