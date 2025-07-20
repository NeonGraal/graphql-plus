//HintName: Model_union-alias.gen.cs
// Generated from union-alias.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_union_alias;

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
