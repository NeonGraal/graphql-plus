//HintName: test_generic-field-dual+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Output;

internal class testGnrcFieldDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldDualOutpObject>
{
  private readonly IEncoder<ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp>> _itestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp> = encoders.EncoderFor<ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp>>();
  public Structured Encode(ItestGnrcFieldDualOutpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp>);
}

internal class testRefGnrcFieldDualOutpEncoder : IEncoder<ItestRefGnrcFieldDualOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcFieldDualOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcFieldDualOutpEncoder : IEncoder<ItestAltGnrcFieldDualOutpObject>
{
  public Structured Encode(ItestAltGnrcFieldDualOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}
