//HintName: Model_union-parent-dup.gen.cs
// Generated from union-parent-dup.graphql+

/*
*/

namespace GqlTest.Model_union_parent_dup;

public interface IUnionPrntDup
  : IPrntUnionPrntDup
{
  Number AsNumber { get; }
}
public class UnionUnionPrntDup
  : UnionPrntUnionPrntDup
  , IUnionPrntDup
{
  public Number AsNumber { get; set; }
}

public interface IPrntUnionPrntDup
{
  Number AsNumber { get; }
}
public class UnionPrntUnionPrntDup
  : IPrntUnionPrntDup
{
  public Number AsNumber { get; set; }
}
