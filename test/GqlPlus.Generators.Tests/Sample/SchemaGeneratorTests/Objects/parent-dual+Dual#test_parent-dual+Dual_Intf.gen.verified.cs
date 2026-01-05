//HintName: test_parent-dual+Dual_Intf.gen.cs
// Generated from parent-dual+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Dual;

public interface ItestPrntDualDual
  : ItestRefPrntDualDual
{
  public testPrntDualDual PrntDualDual { get; set; }
}

public interface ItestPrntDualDualField
  : ItestRefPrntDualDualField
{
}

public interface ItestRefPrntDualDual
{
  public testString AsString { get; set; }
  public testRefPrntDualDual RefPrntDualDual { get; set; }
}

public interface ItestRefPrntDualDualField
{
  public testNumber parent { get; set; }
}
