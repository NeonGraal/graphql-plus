//HintName: Model_union-parent-descr.gen.cs
// Generated from union-parent-descr.graphql+

/*
*/

namespace GqlTest.Model_union_parent_descr;

public interface IUnionPrntDescr
  : I( 'Parent comment' !Tr I@041/0001 PrntUnionPrntDescr )
{
  Number AsNumber { get; }
}
public class UnionUnionPrntDescr
  : Union( 'Parent comment' !Tr I@041/0001 PrntUnionPrntDescr )
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
