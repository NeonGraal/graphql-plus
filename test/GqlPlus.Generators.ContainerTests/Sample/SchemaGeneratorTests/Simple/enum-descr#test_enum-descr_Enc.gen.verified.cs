//HintName: test_enum-descr_Enc.gen.cs
// Generated from {CurrentDirectory}enum-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_descr;

internal class testEnumDescrEncoder : IEncoder<testEnumDescr>
{
  public Structured Encode(testEnumDescr input)
    => new(input.ToString(), "_EnumDescr");
}
