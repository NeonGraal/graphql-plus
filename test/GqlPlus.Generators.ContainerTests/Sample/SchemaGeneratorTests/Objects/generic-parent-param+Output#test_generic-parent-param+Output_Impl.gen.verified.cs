//HintName: test_generic-parent-param+Output_Impl.gen.cs
// Generated from generic-parent-param+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Output;

public class testGnrcPrntParamOutp
  : testRefGnrcPrntParamOutp<ItestAltGnrcPrntParamOutp>
  , ItestGnrcPrntParamOutp
{
  public ItestGnrcPrntParamOutpObject AsGnrcPrntParamOutp { get; set; }
}

public class testRefGnrcPrntParamOutp<TRef>
  : ItestRefGnrcPrntParamOutp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcPrntParamOutpObject AsRefGnrcPrntParamOutp { get; set; }
}

public class testAltGnrcPrntParamOutp
  : ItestAltGnrcPrntParamOutp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcPrntParamOutpObject AsAltGnrcPrntParamOutp { get; set; }
}
