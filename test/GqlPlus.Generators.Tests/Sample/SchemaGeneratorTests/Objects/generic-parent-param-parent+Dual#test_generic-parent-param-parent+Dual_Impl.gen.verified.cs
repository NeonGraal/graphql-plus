//HintName: test_generic-parent-param-parent+Dual_Impl.gen.cs
// Generated from generic-parent-param-parent+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Dual;

public class testGnrcPrntParamPrntDual
  : testRefGnrcPrntParamPrntDual
  , ItestGnrcPrntParamPrntDual
{
  public testGnrcPrntParamPrntDual GnrcPrntParamPrntDual { get; set; }
}

public class testRefGnrcPrntParamPrntDual<Tref>
  : testref
  , ItestRefGnrcPrntParamPrntDual<Tref>
{
  public testRefGnrcPrntParamPrntDual RefGnrcPrntParamPrntDual { get; set; }
}

public class testAltGnrcPrntParamPrntDual
  : ItestAltGnrcPrntParamPrntDual
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltGnrcPrntParamPrntDual AltGnrcPrntParamPrntDual { get; set; }
}
