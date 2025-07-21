//HintName: Gqlp_generic-parent-dual-parent+Dual_Impl.gen.cs
// Generated from generic-parent-dual-parent+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_dual_parent_Dual;
public class DualGnrcPrntDualPrntDual
  : DualRefGnrcPrntDualPrntDual
  , IGnrcPrntDualPrntDual
{
}
public class DualRefGnrcPrntDualPrntDual<Tref>
  : Dualref
  , IRefGnrcPrntDualPrntDual<Tref>
{
}
public class DualAltGnrcPrntDualPrntDual
  : IAltGnrcPrntDualPrntDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
