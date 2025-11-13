//HintName: test_parent-dual+Dual_Impl.gen.cs
// Generated from parent-dual+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Dual;

public class testPrntDualDual
  : testRefPrntDualDual
  , ItestPrntDualDual
{
  public testPrntDualDual PrntDualDual { get; set; }
}

public class testRefPrntDualDual
  : ItestRefPrntDualDual
{
  public testNumber parent { get; set; }
  public testString AsString { get; set; }
  public testRefPrntDualDual RefPrntDualDual { get; set; }
}
