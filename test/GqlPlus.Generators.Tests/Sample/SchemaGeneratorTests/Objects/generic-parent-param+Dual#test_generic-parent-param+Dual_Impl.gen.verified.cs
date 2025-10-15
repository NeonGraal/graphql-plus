//HintName: test_generic-parent-param+Dual_Impl.gen.cs
// Generated from generic-parent-param+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Dual;

public class DualtestGnrcPrntParamDual
  : DualtestRefGnrcPrntParamDual
  , ItestGnrcPrntParamDual
{
}

public class DualtestRefGnrcPrntParamDual<Tref>
  : ItestRefGnrcPrntParamDual<Tref>
{
  public Tref Asref { get; set; }
}

public class DualtestAltGnrcPrntParamDual
  : ItestAltGnrcPrntParamDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
