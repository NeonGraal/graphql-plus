//HintName: test_generic-parent-param-parent+Input_Impl.gen.cs
// Generated from generic-parent-param-parent+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Input;

public class testGnrcPrntParamPrntInp
  : testRefGnrcPrntParamPrntInp
  , ItestGnrcPrntParamPrntInp
{
  public testGnrcPrntParamPrntInp GnrcPrntParamPrntInp { get; set; }
}

public class testRefGnrcPrntParamPrntInp<Tref>
  : testref
  , ItestRefGnrcPrntParamPrntInp<Tref>
{
  public testRefGnrcPrntParamPrntInp RefGnrcPrntParamPrntInp { get; set; }
}

public class testAltGnrcPrntParamPrntInp
  : ItestAltGnrcPrntParamPrntInp
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltGnrcPrntParamPrntInp AltGnrcPrntParamPrntInp { get; set; }
}
