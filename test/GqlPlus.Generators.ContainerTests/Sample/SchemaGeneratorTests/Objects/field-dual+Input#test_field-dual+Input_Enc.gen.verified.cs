//HintName: test_field-dual+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Input;

internal class testFieldDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldDualInpObject>
{
  private readonly IEncoder<ItestFldFieldDualInp> _itestFldFieldDualInp = encoders.EncoderFor<ItestFldFieldDualInp>();
  public Structured Encode(ItestFieldDualInpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldFieldDualInp);
}

internal class testFldFieldDualInpEncoder : IEncoder<ItestFldFieldDualInpObject>
{
  public Structured Encode(ItestFldFieldDualInpObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}
