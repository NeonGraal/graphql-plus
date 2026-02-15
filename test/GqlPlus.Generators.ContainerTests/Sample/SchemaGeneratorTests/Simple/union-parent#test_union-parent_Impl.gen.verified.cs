//HintName: test_union-parent_Impl.gen.cs
// Generated from union-parent.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_parent;

public class testUnionPrnt
  : testPrntUnionPrnt
  , ItestUnionPrnt
{
  public String AsString { get; set; }
}

public class testPrntUnionPrnt
  : ItestPrntUnionPrnt
{
  public Number AsNumber { get; set; }
}
