//HintName: test_generic-parent-param-parent+Output_Impl.gen.cs
// Generated from generic-parent-param-parent+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Output;

public class testGnrcPrntParamPrntOutp
  : testRefGnrcPrntParamPrntOutp<ItestAltGnrcPrntParamPrntOutp>
  , ItestGnrcPrntParamPrntOutp
{
  public ItestGnrcPrntParamPrntOutpObject AsGnrcPrntParamPrntOutp { get; set; }
}

public class testRefGnrcPrntParamPrntOutp<TRef>
  : ItestRefGnrcPrntParamPrntOutp<TRef>
{
  public TRef AsParent { get; set; }
  public ItestRefGnrcPrntParamPrntOutpObject<TRef> AsRefGnrcPrntParamPrntOutp { get; set; }
}

public class testAltGnrcPrntParamPrntOutp
  : ItestAltGnrcPrntParamPrntOutp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcPrntParamPrntOutpObject AsAltGnrcPrntParamPrntOutp { get; set; }
}
