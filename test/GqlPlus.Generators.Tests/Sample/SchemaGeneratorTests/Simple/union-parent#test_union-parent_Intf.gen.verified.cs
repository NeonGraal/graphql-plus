//HintName: test_union-parent_Intf.gen.cs
// Generated from union-parent.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_parent;

public interface ItestUnionPrnt
  : ItestPrntUnionPrnt
{
  String AsString { get; }
}

public interface ItestPrntUnionPrnt
{
  Number AsNumber { get; }
}
