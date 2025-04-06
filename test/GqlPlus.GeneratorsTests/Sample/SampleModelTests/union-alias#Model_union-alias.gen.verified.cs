//HintName: Model_union-alias.gen.cs
// Generated from union-alias.graphql+

/*
*/

namespace GqlTest.Model_union_alias;

public class IUnionAlias
{
  public Boolean AsBoolean { get; }
  public Number AsNumber { get; }
}

public class UnionUnionAlias
  : IUnionAlias
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }
}
