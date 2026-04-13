//HintName: test_input-field-null_Enc.gen.cs
// Generated from {CurrentDirectory}input-field-null.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_null;

internal class testInpFieldNullEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestInpFieldNullObject>
{
  private readonly IEncoder<ItestFldInpFieldNull> _itestFldInpFieldNull = encoders.EncoderFor<ItestFldInpFieldNull>();
  public Structured Encode(ItestInpFieldNullObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldInpFieldNull);
}

internal class testFldInpFieldNullEncoder : IEncoder<ItestFldInpFieldNullObject>
{
  public Structured Encode(ItestFldInpFieldNullObject input)
    => Structured.Empty();
}
