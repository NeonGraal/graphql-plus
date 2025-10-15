//HintName: test_union-parent-descr_Impl.gen.cs
// Generated from union-parent-descr.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_union_parent_descr;

public class UniontestUnionPrntDescr
  : UniontestPrntUnionPrntDescr
  , ItestUnionPrntDescr
{
  public Number AsNumber { get; set; }
}

public class UniontestPrntUnionPrntDescr
  : ItestPrntUnionPrntDescr
{
  public Number AsNumber { get; set; }
}
