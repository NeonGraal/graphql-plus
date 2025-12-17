//HintName: test_generic-field-param+Input_Impl.gen.cs
// Generated from generic-field-param+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Input;

public class testGnrcFieldParamInp
  : ItestGnrcFieldParamInp
{
  public testRefGnrcFieldParamInp<testAltGnrcFieldParamInp> field { get; set; }
  public testGnrcFieldParamInp GnrcFieldParamInp { get; set; }
}

public class testRefGnrcFieldParamInp<Tref>
  : ItestRefGnrcFieldParamInp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcFieldParamInp RefGnrcFieldParamInp { get; set; }
}

public class testAltGnrcFieldParamInp
  : ItestAltGnrcFieldParamInp
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltGnrcFieldParamInp AltGnrcFieldParamInp { get; set; }
}
