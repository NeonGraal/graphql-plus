//HintName: Model_generic-parent-dual+Dual.gen.cs
// Generated from generic-parent-dual+Dual.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_dual_Dual;

public interface IGnrcPrntDualDual
  : IRefGnrcPrntDualDual
{
}
public class DualGnrcPrntDualDual
  : DualRefGnrcPrntDualDual
  , IGnrcPrntDualDual
{
}

public interface IRefGnrcPrntDualDual<Tref>
{
  Tref Asref { get; }
}
public class DualRefGnrcPrntDualDual<Tref>
  : IRefGnrcPrntDualDual<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltGnrcPrntDualDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltGnrcPrntDualDual
  : IAltGnrcPrntDualDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
