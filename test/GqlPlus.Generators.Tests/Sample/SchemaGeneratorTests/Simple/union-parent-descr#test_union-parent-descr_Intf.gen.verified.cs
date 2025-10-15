//HintName: test_union-parent-descr_Intf.gen.cs
// Generated from union-parent-descr.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_union_parent_descr;

public interface ItestUnionPrntDescr
  : ItestPrntUnionPrntDescr
{
  Number AsNumber { get; }
}

public interface ItestPrntUnionPrntDescr
{
  Number AsNumber { get; }
}
