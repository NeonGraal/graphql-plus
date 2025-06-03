//HintName: Model_generic-parent-dual+Dual.gen.cs
// Generated from generic-parent-dual+Dual.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_dual_Dual;

public interface IDualGnrcPrntDual
  : IRefDualGnrcPrntDual
{
}
public class DualDualGnrcPrntDual
  : DualRefDualGnrcPrntDual
  , IDualGnrcPrntDual
{
}

public interface IRefDualGnrcPrntDual<Tref>
{
  Tref Asref { get; }
}
public class DualRefDualGnrcPrntDual<Tref>
  : IRefDualGnrcPrntDual<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltDualGnrcPrntDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltDualGnrcPrntDual
  : IAltDualGnrcPrntDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
