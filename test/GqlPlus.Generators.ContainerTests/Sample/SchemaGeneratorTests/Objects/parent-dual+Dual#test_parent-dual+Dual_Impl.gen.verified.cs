//HintName: test_parent-dual+Dual_Impl.gen.cs
// Generated from parent-dual+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Dual;

public class testPrntDualDual
  : testRefPrntDualDual
  , ItestPrntDualDual
{
}

public class testRefPrntDualDual
  : ItestRefPrntDualDual
{
  public ItestNumber Parent { get; set; }
  public ItestString AsString { get; set; }
}
