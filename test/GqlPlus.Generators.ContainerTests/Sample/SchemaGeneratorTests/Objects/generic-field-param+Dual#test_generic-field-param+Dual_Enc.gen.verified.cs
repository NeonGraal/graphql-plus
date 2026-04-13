//HintName: test_generic-field-param+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Dual;

internal class testGnrcFieldParamDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldParamDualObject>
{
  private readonly IEncoder<ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual>> _itestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual> = encoders.EncoderFor<ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual>>();
  public Structured Encode(ItestGnrcFieldParamDualObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual>);
}

internal class testRefGnrcFieldParamDualEncoder : IEncoder<ItestRefGnrcFieldParamDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcFieldParamDualObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcFieldParamDualEncoder : IEncoder<ItestAltGnrcFieldParamDualObject>
{
  public Structured Encode(ItestAltGnrcFieldParamDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}
