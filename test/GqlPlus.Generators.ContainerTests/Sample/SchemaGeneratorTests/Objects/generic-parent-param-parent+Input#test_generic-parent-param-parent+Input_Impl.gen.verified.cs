//HintName: test_generic-parent-param-parent+Input_Impl.gen.cs
// Generated from generic-parent-param-parent+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Input;

public class testGnrcPrntParamPrntInp
  : testRefGnrcPrntParamPrntInp<ItestAltGnrcPrntParamPrntInp>
  , ItestGnrcPrntParamPrntInp
{
}

public class testRefGnrcPrntParamPrntInp<TRef>
  : ItestRefGnrcPrntParamPrntInp<TRef>
{
}

public class testAltGnrcPrntParamPrntInp
  : ItestAltGnrcPrntParamPrntInp
{
  public decimal Alt { get; set; }
}
