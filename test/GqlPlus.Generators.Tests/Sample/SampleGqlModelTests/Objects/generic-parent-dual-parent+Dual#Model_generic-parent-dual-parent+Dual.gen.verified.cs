//HintName: Model_generic-parent-dual-parent+Dual.gen.cs
// Generated from generic-parent-dual-parent+Dual.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_dual_parent_Dual;

public interface IGnrcPrntDualPrntDual
  : IRefGnrcPrntDualPrntDual
{
}
public class DualGnrcPrntDualPrntDual
  : DualRefGnrcPrntDualPrntDual
  , IGnrcPrntDualPrntDual
{
}

public interface IRefGnrcPrntDualPrntDual<Tref>
  : Iref
{
}
public class DualRefGnrcPrntDualPrntDual<Tref>
  : Dualref
  , IRefGnrcPrntDualPrntDual<Tref>
{
}

public interface IAltGnrcPrntDualPrntDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltGnrcPrntDualPrntDual
  : IAltGnrcPrntDualPrntDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
