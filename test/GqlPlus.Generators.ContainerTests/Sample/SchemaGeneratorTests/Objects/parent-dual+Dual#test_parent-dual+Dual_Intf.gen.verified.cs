//HintName: test_parent-dual+Dual_Intf.gen.cs
// Generated from parent-dual+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Dual;

public interface ItestPrntDualDual
  : ItestRefPrntDualDual
{
}

public interface ItestPrntDualDualObject
  : ItestRefPrntDualDualObject
{
}

public interface ItestRefPrntDualDual
{
  public ItestString AsString { get; set; }
}

public interface ItestRefPrntDualDualObject
{
  public ItestNumber Parent { get; set; }
}
