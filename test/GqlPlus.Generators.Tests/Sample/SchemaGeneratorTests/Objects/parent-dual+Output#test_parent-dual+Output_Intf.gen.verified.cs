//HintName: test_parent-dual+Output_Intf.gen.cs
// Generated from parent-dual+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Output;

public interface ItestPrntDualOutp
  : ItestRefPrntDualOutp
{
}

public interface ItestRefPrntDualOutp
{
  Number parent { get; }
  String AsString { get; }
}
