//HintName: test_generic-parent-param-parent+Dual_Impl.gen.cs
// Generated from generic-parent-param-parent+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Dual;

public class testGnrcPrntParamPrntDual
  : testRefGnrcPrntParamPrntDual<ItestAltGnrcPrntParamPrntDual>
  , ItestGnrcPrntParamPrntDual
{
}

public class testRefGnrcPrntParamPrntDual<TRef>
  : ItestRefGnrcPrntParamPrntDual<TRef>
{
}

public class testAltGnrcPrntParamPrntDual
  : ItestAltGnrcPrntParamPrntDual
{
  public decimal Alt { get; set; }
}
