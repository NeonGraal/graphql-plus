//HintName: test_union-same-parent_Impl.gen.cs
// Generated from union-same-parent.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_union_same_parent;

public class testUnionSamePrnt
  : testPrntUnionSamePrnt
  , ItestUnionSamePrnt
{
  public Boolean AsBoolean { get; set; }
}

public class testPrntUnionSamePrnt
  : ItestPrntUnionSamePrnt
{
  public String AsString { get; set; }
}
