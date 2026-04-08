//HintName: test_generic-field-dual+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Output;

internal class testGnrcFieldDualOutpEncoder
{
  public ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp> Field { get; set; }
}

internal class testRefGnrcFieldDualOutpEncoder<TRef>
{
}

internal class testAltGnrcFieldDualOutpEncoder
{
  public decimal Alt { get; set; }
}
