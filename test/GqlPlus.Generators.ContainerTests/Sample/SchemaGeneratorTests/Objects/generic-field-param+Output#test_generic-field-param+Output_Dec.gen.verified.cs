//HintName: test_generic-field-param+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Output;

internal class testGnrcFieldParamOutpDecoder
{
  public ItestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp> Field { get; set; }
}

internal class testRefGnrcFieldParamOutpDecoder<TRef>
{
}

internal class testAltGnrcFieldParamOutpDecoder
{
  public decimal Alt { get; set; }
}
