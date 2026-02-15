//HintName: test_parent-dual+Output_Intf.gen.cs
// Generated from parent-dual+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Output;

public interface ItestPrntDualOutp
  : ItestRefPrntDualOutp
{
  ItestPrntDualOutpObject AsPrntDualOutp { get; }
}

public interface ItestPrntDualOutpObject
  : ItestRefPrntDualOutpObject
{
}

public interface ItestRefPrntDualOutp
{
  string AsString { get; }
  ItestRefPrntDualOutpObject AsRefPrntDualOutp { get; }
}

public interface ItestRefPrntDualOutpObject
{
  decimal Parent { get; }
}
