//HintName: test_generic-parent-param+Input_Impl.gen.cs
// Generated from generic-parent-param+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Input;

public class testGnrcPrntParamInp
  : testRefGnrcPrntParamInp
  , ItestGnrcPrntParamInp
{
  public testGnrcPrntParamInp GnrcPrntParamInp { get; set; }
}

public class testRefGnrcPrntParamInp<Tref>
  : ItestRefGnrcPrntParamInp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcPrntParamInp RefGnrcPrntParamInp { get; set; }
}

public class testAltGnrcPrntParamInp
  : ItestAltGnrcPrntParamInp
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltGnrcPrntParamInp AltGnrcPrntParamInp { get; set; }
}
