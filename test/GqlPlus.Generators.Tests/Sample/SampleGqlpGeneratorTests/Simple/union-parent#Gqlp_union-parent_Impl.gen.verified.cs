//HintName: Gqlp_union-parent_Impl.gen.cs
// Generated from union-parent.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_union_parent;
public class UnionUnionPrnt
  : UnionPrntUnionPrnt
  , IUnionPrnt
{
  public String AsString { get; set; }
}
public class UnionPrntUnionPrnt
  : IPrntUnionPrnt
{
  public Number AsNumber { get; set; }
}
