//HintName: Model_parent-dual+Dual.gen.cs
// Generated from parent-dual+Dual.graphql+

/*
*/

namespace GqlTest.Model_parent_dual_Dual;

public interface IDualPrntDual
  : IRefDualPrntDual
{
}
public class DualDualPrntDual
  : DualRefDualPrntDual
  , IDualPrntDual
{
}

public interface IRefDualPrntDual
{
  Number parent { get; }
  String AsString { get; }
}
public class DualRefDualPrntDual
  : IRefDualPrntDual
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
