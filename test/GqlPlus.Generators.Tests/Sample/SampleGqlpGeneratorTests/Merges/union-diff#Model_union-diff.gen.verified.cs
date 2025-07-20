//HintName: Model_union-diff.gen.cs
// Generated from union-diff.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_union_diff;

public interface IUnionDiff
{
  Boolean AsBoolean { get; }
  Number AsNumber { get; }
}
public class UnionUnionDiff
  : IUnionDiff
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }
}
