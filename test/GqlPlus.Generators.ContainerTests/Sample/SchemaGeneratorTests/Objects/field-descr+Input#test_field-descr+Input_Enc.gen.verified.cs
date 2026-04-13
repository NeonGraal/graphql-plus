//HintName: test_field-descr+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_descr_Input;

internal class testFieldDescrInpEncoder : IEncoder<ItestFieldDescrInpObject>
{
  public Structured Encode(ItestFieldDescrInpObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}
