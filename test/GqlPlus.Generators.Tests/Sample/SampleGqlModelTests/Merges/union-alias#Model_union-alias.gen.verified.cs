//HintName: Model_union-alias.gen.cs
// Generated from union-alias.graphql+

/*
*/

namespace GqlTest.Model_union_alias;

public interface IUnionAlias
{
  Boolean AsBoolean { get; }
  Number AsNumber { get; }
}
public class UnionUnionAlias
  : IUnionAlias
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }
}
