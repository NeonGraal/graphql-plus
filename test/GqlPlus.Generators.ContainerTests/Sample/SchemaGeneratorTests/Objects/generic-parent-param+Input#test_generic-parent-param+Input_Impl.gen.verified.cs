//HintName: test_generic-parent-param+Input_Impl.gen.cs
// Generated from generic-parent-param+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Input;

public class testGnrcPrntParamInp
  : testRefGnrcPrntParamInp<ItestAltGnrcPrntParamInp>
  , ItestGnrcPrntParamInp
{
  public ItestGnrcPrntParamInpObject AsGnrcPrntParamInp { get; set; }
}

public class testRefGnrcPrntParamInp<TRef>
  : ItestRefGnrcPrntParamInp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcPrntParamInpObject AsRefGnrcPrntParamInp { get; set; }
}

public class testAltGnrcPrntParamInp
  : ItestAltGnrcPrntParamInp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcPrntParamInpObject AsAltGnrcPrntParamInp { get; set; }
}
