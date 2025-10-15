//HintName: test_generic-parent-param-parent+Dual_Impl.gen.cs
// Generated from generic-parent-param-parent+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Dual;

public class DualtestGnrcPrntParamPrntDual
  : DualtestRefGnrcPrntParamPrntDual
  , ItestGnrcPrntParamPrntDual
{
}

public class DualtestRefGnrcPrntParamPrntDual<Tref>
  : Dualtestref
  , ItestRefGnrcPrntParamPrntDual<Tref>
{
}

public class DualtestAltGnrcPrntParamPrntDual
  : ItestAltGnrcPrntParamPrntDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
