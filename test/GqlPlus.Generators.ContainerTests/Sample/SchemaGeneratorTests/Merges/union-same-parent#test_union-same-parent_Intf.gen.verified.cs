//HintName: test_union-same-parent_Intf.gen.cs
// Generated from union-same-parent.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_same_parent;

public interface ItestUnionSamePrnt
  : ItestPrntUnionSamePrnt
{
  Boolean AsBoolean { get; }
}

public interface ItestPrntUnionSamePrnt
{
  String AsString { get; }
}
