//HintName: Model_union-diff.gen.cs
// Generated from union-diff.graphql+

/*
*/

namespace GqlTest.Model_union_diff;

public class IUnionDiff
{
  public Boolean AsBoolean { get; }
  public Number AsNumber { get; }
}

public class UnionUnionDiff
  : IUnionDiff
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }
}
