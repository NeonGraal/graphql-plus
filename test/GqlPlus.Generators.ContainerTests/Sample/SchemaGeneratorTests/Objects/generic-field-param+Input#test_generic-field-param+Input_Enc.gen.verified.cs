//HintName: test_generic-field-param+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Input;

internal class testGnrcFieldParamInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldParamInpObject>
{
  private readonly IEncoder<ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp>> _itestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp> = encoders.EncoderFor<ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp>>();
  public Structured Encode(ItestGnrcFieldParamInpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp>);
}

internal class testRefGnrcFieldParamInpEncoder : IEncoder<ItestRefGnrcFieldParamInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcFieldParamInpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcFieldParamInpEncoder : IEncoder<ItestAltGnrcFieldParamInpObject>
{
  public Structured Encode(ItestAltGnrcFieldParamInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}
