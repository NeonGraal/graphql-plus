//HintName: test_generic-alt-param+Input_Impl.gen.cs
// Generated from generic-alt-param+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Input;

public class testGnrcAltParamInp
  : ItestGnrcAltParamInp
{
  public testRefGnrcAltParamInp<testAltGnrcAltParamInp> AsRefGnrcAltParamInp { get; set; }
  public testGnrcAltParamInp GnrcAltParamInp { get; set; }
}

public class testRefGnrcAltParamInp<Tref>
  : ItestRefGnrcAltParamInp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcAltParamInp RefGnrcAltParamInp { get; set; }
}

public class testAltGnrcAltParamInp
  : ItestAltGnrcAltParamInp
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltGnrcAltParamInp AltGnrcAltParamInp { get; set; }
}
