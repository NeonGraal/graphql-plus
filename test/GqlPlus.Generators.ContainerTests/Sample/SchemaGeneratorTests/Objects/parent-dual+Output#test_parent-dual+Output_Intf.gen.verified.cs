//HintName: test_parent-dual+Output_Intf.gen.cs
// Generated from parent-dual+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Output;

public interface ItestPrntDualOutp
  : ItestRefPrntDualOutp
{
  public ItestPrntDualOutpObject AsPrntDualOutp { get; set; }
}

public interface ItestPrntDualOutpObject
  : ItestRefPrntDualOutpObject
{
}

public interface ItestRefPrntDualOutp
{
  public string AsString { get; set; }
  public ItestRefPrntDualOutpObject AsRefPrntDualOutp { get; set; }
}

public interface ItestRefPrntDualOutpObject
{
  public decimal Parent { get; set; }
}
