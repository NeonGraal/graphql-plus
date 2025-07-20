//HintName: Model_union-parent-descr.gen.cs
// Generated from union-parent-descr.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_union_parent_descr;

public interface IUnionPrntDescr
  : IPrntUnionPrntDescr
{
  Number AsNumber { get; }
}
public class UnionUnionPrntDescr
  : UnionPrntUnionPrntDescr
  , IUnionPrntDescr
{
  public Number AsNumber { get; set; }
}

public interface IPrntUnionPrntDescr
{
  Number AsNumber { get; }
}
public class UnionPrntUnionPrntDescr
  : IPrntUnionPrntDescr
{
  public Number AsNumber { get; set; }
}
