//HintName: test_generic-field-dual+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Input;

internal class testGnrcFieldDualInpEncoder
{
  public ItestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp> Field { get; set; }
}

internal class testRefGnrcFieldDualInpEncoder<TRef>
{
}

internal class testAltGnrcFieldDualInpEncoder
{
  public decimal Alt { get; set; }
}
