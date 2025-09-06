//HintName: Gqlp_generic-parent-param+Dual_Impl.gen.cs
// Generated from generic-parent-param+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_param_Dual;

public class DualGnrcPrntParamDual
  : DualRefGnrcPrntParamDual
  , IGnrcPrntParamDual
{
}

public class DualRefGnrcPrntParamDual<Tref>
  : IRefGnrcPrntParamDual<Tref>
{
  public Tref Asref { get; set; }
}

public class DualAltGnrcPrntParamDual
  : IAltGnrcPrntParamDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
