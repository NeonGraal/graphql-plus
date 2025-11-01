//HintName: test_parent-dual+Output_Impl.gen.cs
// Generated from parent-dual+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Output;

public class testPrntDualOutp
  : testRefPrntDualOutp
  , ItestPrntDualOutp
{
  public testPrntDualOutp PrntDualOutp { get; set; }
}

public class testRefPrntDualOutp
  : ItestRefPrntDualOutp
{
  public testNumber parent { get; set; }
  public testString AsString { get; set; }
  public testRefPrntDualOutp RefPrntDualOutp { get; set; }
}
