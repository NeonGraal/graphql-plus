//HintName: Gqlp_generic-parent-param-parent+Dual_Impl.gen.cs
// Generated from generic-parent-param-parent+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_param_parent_Dual;

public class DualGnrcPrntParamPrntDual
  : DualRefGnrcPrntParamPrntDual
  , IGnrcPrntParamPrntDual
{
}

public class DualRefGnrcPrntParamPrntDual<Tref>
  : Dualref
  , IRefGnrcPrntParamPrntDual<Tref>
{
}

public class DualAltGnrcPrntParamPrntDual
  : IAltGnrcPrntParamPrntDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
