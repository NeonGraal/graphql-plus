//HintName: test_generic-parent-param-parent+Output_Impl.gen.cs
// Generated from generic-parent-param-parent+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Output;

public class testGnrcPrntParamPrntOutp
  : testRefGnrcPrntParamPrntOutp
  , ItestGnrcPrntParamPrntOutp
{
  public testGnrcPrntParamPrntOutp GnrcPrntParamPrntOutp { get; set; }
}

public class testRefGnrcPrntParamPrntOutp<Tref>
  : testref
  , ItestRefGnrcPrntParamPrntOutp<Tref>
{
  public testRefGnrcPrntParamPrntOutp RefGnrcPrntParamPrntOutp { get; set; }
}

public class testAltGnrcPrntParamPrntOutp
  : ItestAltGnrcPrntParamPrntOutp
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltGnrcPrntParamPrntOutp AltGnrcPrntParamPrntOutp { get; set; }
}
