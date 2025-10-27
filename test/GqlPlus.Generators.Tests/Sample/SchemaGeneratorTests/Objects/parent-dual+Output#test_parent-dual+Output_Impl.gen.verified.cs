//HintName: test_parent-dual+Output_Impl.gen.cs
// Generated from parent-dual+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Output;

public class testPrntDualOutp
  : testRefPrntDualOutp
  , ItestPrntDualOutp
{
}

public class testRefPrntDualOutp
  : ItestRefPrntDualOutp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
