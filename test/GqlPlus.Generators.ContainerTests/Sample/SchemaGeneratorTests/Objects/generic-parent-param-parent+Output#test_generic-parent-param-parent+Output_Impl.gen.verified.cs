//HintName: test_generic-parent-param-parent+Output_Impl.gen.cs
// Generated from generic-parent-param-parent+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Output;

public class testGnrcPrntParamPrntOutp
  : testRefGnrcPrntParamPrntOutp
  , ItestGnrcPrntParamPrntOutp
{
  public ItestGnrcPrntParamPrntOutpObject AsGnrcPrntParamPrntOutp { get; set; }
}

public class testRefGnrcPrntParamPrntOutp<Tref>
  : testref
  , ItestRefGnrcPrntParamPrntOutp<Tref>
{
  public ItestRefGnrcPrntParamPrntOutpObject AsRefGnrcPrntParamPrntOutp { get; set; }
}

public class testAltGnrcPrntParamPrntOutp
  : ItestAltGnrcPrntParamPrntOutp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcPrntParamPrntOutpObject AsAltGnrcPrntParamPrntOutp { get; set; }
}
