//HintName: test_parent-dual+Output_Impl.gen.cs
// Generated from parent-dual+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Output;

public class testPrntDualOutp
  : testRefPrntDualOutp
  , ItestPrntDualOutp
{
  public ItestPrntDualOutpObject AsPrntDualOutp { get; set; }
}

public class testRefPrntDualOutp
  : ItestRefPrntDualOutp
{
  public decimal Parent { get; set; }
  public string AsString { get; set; }
  public ItestRefPrntDualOutpObject AsRefPrntDualOutp { get; set; }
}
