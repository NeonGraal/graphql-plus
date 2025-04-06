//HintName: Model_union-parent.gen.cs
// Generated from union-parent.graphql+

/*
*/

namespace GqlTest.Model_union_parent;

public class IUnionPrnt
  : IPrntUnionPrnt
{
  public String AsString { get; }
}

public class UnionUnionPrnt
  : UnionPrntUnionPrnt
  , IUnionPrnt
{
  public String AsString { get; set; }
}

public class IPrntUnionPrnt
{
  public Number AsNumber { get; }
}

public class UnionPrntUnionPrnt
  : IPrntUnionPrnt
{
  public Number AsNumber { get; set; }
}
