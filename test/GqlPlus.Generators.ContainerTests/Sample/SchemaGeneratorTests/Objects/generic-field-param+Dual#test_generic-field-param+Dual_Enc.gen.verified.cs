//HintName: test_generic-field-param+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Dual;

internal class testGnrcFieldParamDualEncoder
{
  public ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual> Field { get; set; }
}

internal class testRefGnrcFieldParamDualEncoder<TRef>
{
}

internal class testAltGnrcFieldParamDualEncoder
{
  public decimal Alt { get; set; }
}
