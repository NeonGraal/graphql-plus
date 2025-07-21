//HintName: Gqlp_generic-parent-dual+Dual_Impl.gen.cs
// Generated from generic-parent-dual+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_dual_Dual;
public class DualGnrcPrntDualDual
  : DualRefGnrcPrntDualDual
  , IGnrcPrntDualDual
{
}
public class DualRefGnrcPrntDualDual<Tref>
  : IRefGnrcPrntDualDual<Tref>
{
  public Tref Asref { get; set; }
}
public class DualAltGnrcPrntDualDual
  : IAltGnrcPrntDualDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
