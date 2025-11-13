//HintName: test_union-parent-dup_Impl.gen.cs
// Generated from union-parent-dup.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_union_parent_dup;

public class testUnionPrntDup
  : testPrntUnionPrntDup
  , ItestUnionPrntDup
{
  public Number AsNumber { get; set; }
}

public class testPrntUnionPrntDup
  : ItestPrntUnionPrntDup
{
  public Number AsNumber { get; set; }
}
