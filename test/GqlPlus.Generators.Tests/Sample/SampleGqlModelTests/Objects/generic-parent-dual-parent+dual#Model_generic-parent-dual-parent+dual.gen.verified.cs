//HintName: Model_generic-parent-dual-parent+dual.gen.cs
// Generated from generic-parent-dual-parent+dual.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_dual_parent_dual;

public interface IDualGnrcPrntDualPrnt
  : IRefDualGnrcPrntDualPrnt
{
}
public class DualDualGnrcPrntDualPrnt
  : DualRefDualGnrcPrntDualPrnt
  , IDualGnrcPrntDualPrnt
{
}

public interface IRefDualGnrcPrntDualPrnt<Tref>
  : Iref
{
}
public class DualRefDualGnrcPrntDualPrnt<Tref>
  : Dualref
  , IRefDualGnrcPrntDualPrnt<Tref>
{
}

public interface IAltDualGnrcPrntDualPrnt
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltDualGnrcPrntDualPrnt
  : IAltDualGnrcPrntDualPrnt
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
