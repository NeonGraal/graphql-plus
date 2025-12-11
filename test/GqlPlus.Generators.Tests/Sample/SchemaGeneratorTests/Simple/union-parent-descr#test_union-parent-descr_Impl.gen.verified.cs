//HintName: test_union-parent-descr_Impl.gen.cs
// Generated from union-parent-descr.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_parent_descr;

public class testUnionPrntDescr
  : testPrntUnionPrntDescr
  , ItestUnionPrntDescr
{
  public Number AsNumber { get; set; }
}

public class testPrntUnionPrntDescr
  : ItestPrntUnionPrntDescr
{
  public Number AsNumber { get; set; }
}
