//HintName: test_field-dual+Output_Enc.gen.cs
// Generated from {CurrentDirectory}field-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Output;

internal class testFieldDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldDualOutpObject>
{
  private readonly IEncoder<ItestFldFieldDualOutp> _itestFldFieldDualOutp = encoders.EncoderFor<ItestFldFieldDualOutp>();
  public Structured Encode(ItestFieldDualOutpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldFieldDualOutp);
}

internal class testFldFieldDualOutpEncoder : IEncoder<ItestFldFieldDualOutpObject>
{
  public Structured Encode(ItestFldFieldDualOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}
