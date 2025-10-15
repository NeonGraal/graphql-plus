//HintName: test_union-parent-dup_Impl.gen.cs
// Generated from union-parent-dup.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_union_parent_dup;

public class UniontestUnionPrntDup
  : UniontestPrntUnionPrntDup
  , ItestUnionPrntDup
{
  public Number AsNumber { get; set; }
}

public class UniontestPrntUnionPrntDup
  : ItestPrntUnionPrntDup
{
  public Number AsNumber { get; set; }
}
