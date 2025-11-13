//HintName: test_parent+Dual_Impl.gen.cs
// Generated from parent+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_Dual;

public class testPrntDual
  : testRefPrntDual
  , ItestPrntDual
{
  public testPrntDual PrntDual { get; set; }
}

public class testRefPrntDual
  : ItestRefPrntDual
{
  public testNumber parent { get; set; }
  public testString AsString { get; set; }
  public testRefPrntDual RefPrntDual { get; set; }
}
