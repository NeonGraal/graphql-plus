//HintName: test_input-field-descr-Number_Enc.gen.cs
// Generated from {CurrentDirectory}input-field-descr-Number.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_descr_Number;

internal class testInpFieldDescrNmbrEncoder : IEncoder<ItestInpFieldDescrNmbrObject>
{
  public Structured Encode(ItestInpFieldDescrNmbrObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}
