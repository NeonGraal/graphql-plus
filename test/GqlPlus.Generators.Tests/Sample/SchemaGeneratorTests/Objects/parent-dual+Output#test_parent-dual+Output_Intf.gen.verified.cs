//HintName: test_parent-dual+Output_Intf.gen.cs
// Generated from parent-dual+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Output;

public interface ItestPrntDualOutp
  : ItestRefPrntDualOutp
{
  public testPrntDualOutp PrntDualOutp { get; set; }
}

public interface ItestPrntDualOutpField
  : ItestRefPrntDualOutpField
{
}

public interface ItestRefPrntDualOutp
{
  public testString AsString { get; set; }
  public testRefPrntDualOutp RefPrntDualOutp { get; set; }
}

public interface ItestRefPrntDualOutpField
{
  public testNumber parent { get; set; }
}
