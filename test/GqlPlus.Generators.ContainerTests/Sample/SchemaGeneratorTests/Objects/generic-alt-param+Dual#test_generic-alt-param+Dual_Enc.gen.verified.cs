//HintName: test_generic-alt-param+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Dual;

internal class testGnrcAltParamDualEncoder : IEncoder<ItestGnrcAltParamDualObject>
{
  public Structured Encode(ItestGnrcAltParamDualObject input)
    => Structured.Empty();
}

internal class testRefGnrcAltParamDualEncoder<TRef> : IEncoder<ItestRefGnrcAltParamDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltParamDualObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcAltParamDualEncoder : IEncoder<ItestAltGnrcAltParamDualObject>
{
  public Structured Encode(ItestAltGnrcAltParamDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}
