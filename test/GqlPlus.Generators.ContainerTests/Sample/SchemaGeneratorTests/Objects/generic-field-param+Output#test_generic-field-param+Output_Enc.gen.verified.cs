//HintName: test_generic-field-param+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Output;

internal class testGnrcFieldParamOutpEncoder
{
  public ItestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp> Field { get; set; }
}

internal class testRefGnrcFieldParamOutpEncoder<TRef>
{
}

internal class testAltGnrcFieldParamOutpEncoder
{
  public decimal Alt { get; set; }
}
