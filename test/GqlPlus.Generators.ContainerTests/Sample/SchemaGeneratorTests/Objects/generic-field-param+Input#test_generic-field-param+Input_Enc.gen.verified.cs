//HintName: test_generic-field-param+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Input;

internal class testGnrcFieldParamInpEncoder
{
  public ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp> Field { get; set; }
}

internal class testRefGnrcFieldParamInpEncoder<TRef>
{
}

internal class testAltGnrcFieldParamInpEncoder
{
  public decimal Alt { get; set; }
}
