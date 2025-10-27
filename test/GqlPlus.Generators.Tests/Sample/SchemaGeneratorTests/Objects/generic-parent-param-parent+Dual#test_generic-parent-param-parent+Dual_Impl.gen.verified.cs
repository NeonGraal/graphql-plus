//HintName: test_generic-parent-param-parent+Dual_Impl.gen.cs
// Generated from generic-parent-param-parent+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Dual;

public class testGnrcPrntParamPrntDual
  : testRefGnrcPrntParamPrntDual
  , ItestGnrcPrntParamPrntDual
{
}

public class testRefGnrcPrntParamPrntDual<Tref>
  : testref
  , ItestRefGnrcPrntParamPrntDual<Tref>
{
}

public class testAltGnrcPrntParamPrntDual
  : ItestAltGnrcPrntParamPrntDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
