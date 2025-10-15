//HintName: test_union-parent-dup_Intf.gen.cs
// Generated from union-parent-dup.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_union_parent_dup;

public interface ItestUnionPrntDup
  : ItestPrntUnionPrntDup
{
  Number AsNumber { get; }
}

public interface ItestPrntUnionPrntDup
{
  Number AsNumber { get; }
}
