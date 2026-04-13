//HintName: test_generic-field-dual+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Input;

internal class testGnrcFieldDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldDualInpObject>
{
  private readonly IEncoder<ItestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp>> _itestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp> = encoders.EncoderFor<ItestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp>>();
  public Structured Encode(ItestGnrcFieldDualInpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp>);
}

internal class testRefGnrcFieldDualInpEncoder : IEncoder<ItestRefGnrcFieldDualInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcFieldDualInpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcFieldDualInpEncoder : IEncoder<ItestAltGnrcFieldDualInpObject>
{
  public Structured Encode(ItestAltGnrcFieldDualInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}
