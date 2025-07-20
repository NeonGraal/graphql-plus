//HintName: Model_parent-dual+Dual.gen.cs
// Generated from parent-dual+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_parent_dual_Dual;

public interface IPrntDualDual
  : IRefPrntDualDual
{
}
public class DualPrntDualDual
  : DualRefPrntDualDual
  , IPrntDualDual
{
}

public interface IRefPrntDualDual
{
  Number parent { get; }
  String AsString { get; }
}
public class DualRefPrntDualDual
  : IRefPrntDualDual
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
