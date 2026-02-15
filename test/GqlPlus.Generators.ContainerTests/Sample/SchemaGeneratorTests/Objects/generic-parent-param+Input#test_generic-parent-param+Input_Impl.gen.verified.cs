//HintName: test_generic-parent-param+Input_Impl.gen.cs
// Generated from generic-parent-param+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Input;

public class testGnrcPrntParamInp
  : testRefGnrcPrntParamInp<ItestAltGnrcPrntParamInp>
  , ItestGnrcPrntParamInp
{
}

public class testRefGnrcPrntParamInp<TRef>
  : ItestRefGnrcPrntParamInp<TRef>
{
}

public class testAltGnrcPrntParamInp
  : ItestAltGnrcPrntParamInp
{
  public decimal Alt { get; set; }
}
