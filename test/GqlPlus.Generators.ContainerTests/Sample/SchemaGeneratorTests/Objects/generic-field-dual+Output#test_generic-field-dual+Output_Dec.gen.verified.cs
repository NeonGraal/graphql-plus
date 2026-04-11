//HintName: test_generic-field-dual+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Output;

internal class testGnrcFieldDualOutpDecoder
{
  public ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp> Field { get; set; }
}

internal class testRefGnrcFieldDualOutpDecoder<TRef>
{
}

internal class testAltGnrcFieldDualOutpDecoder
{
  public decimal Alt { get; set; }
}
