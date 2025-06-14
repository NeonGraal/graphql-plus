//HintName: Model_union-parent.gen.cs
// Generated from union-parent.graphql+

/*
*/

namespace GqlTest.Model_union_parent;

public interface IUnionPrnt
  : I( !Tr I@020/0001 PrntUnionPrnt )
{
  String AsString { get; }
}
public class UnionUnionPrnt
  : Union( !Tr I@020/0001 PrntUnionPrnt )
  , IUnionPrnt
{
  public String AsString { get; set; }
}

public interface IPrntUnionPrnt
{
  Number AsNumber { get; }
}
public class UnionPrntUnionPrnt
  : IPrntUnionPrnt
{
  public Number AsNumber { get; set; }
}
