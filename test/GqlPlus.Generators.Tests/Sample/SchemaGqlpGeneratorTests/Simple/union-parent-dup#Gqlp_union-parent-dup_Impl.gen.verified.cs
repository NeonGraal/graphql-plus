//HintName: Gqlp_union-parent-dup_Impl.gen.cs
// Generated from union-parent-dup.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_union_parent_dup;

public class UnionUnionPrntDup
  : UnionPrntUnionPrntDup
  , IUnionPrntDup
{
  public Number AsNumber { get; set; }
}

public class UnionPrntUnionPrntDup
  : IPrntUnionPrntDup
{
  public Number AsNumber { get; set; }
}
