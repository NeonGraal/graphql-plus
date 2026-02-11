//HintName: test_generic-parent-param-parent+Dual_Impl.gen.cs
// Generated from generic-parent-param-parent+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Dual;

public class testGnrcPrntParamPrntDual
  : testRefGnrcPrntParamPrntDual<ItestAltGnrcPrntParamPrntDual>
  , ItestGnrcPrntParamPrntDual
{
  public ItestGnrcPrntParamPrntDualObject AsGnrcPrntParamPrntDual { get; set; }
}

public class testRefGnrcPrntParamPrntDual<TRef>
  : testref
  , ItestRefGnrcPrntParamPrntDual<TRef>
{
  public ItestRefGnrcPrntParamPrntDualObject AsRefGnrcPrntParamPrntDual { get; set; }
}

public class testAltGnrcPrntParamPrntDual
  : ItestAltGnrcPrntParamPrntDual
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcPrntParamPrntDualObject AsAltGnrcPrntParamPrntDual { get; set; }
}
