//HintName: test_parent+Dual_Impl.gen.cs
// Generated from parent+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_Dual;

public class testPrntDual
  : testRefPrntDual
  , ItestPrntDual
{
}

public class testRefPrntDual
  : ItestRefPrntDual
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
