//HintName: test_input-field-String_Enc.gen.cs
// Generated from {CurrentDirectory}input-field-String.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_String;

internal class testInpFieldStrEncoder : IEncoder<ItestInpFieldStrObject>
{
  public Structured Encode(ItestInpFieldStrObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}
