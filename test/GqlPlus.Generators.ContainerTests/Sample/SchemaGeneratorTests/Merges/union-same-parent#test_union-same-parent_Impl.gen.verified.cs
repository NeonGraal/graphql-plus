//HintName: test_union-same-parent_Impl.gen.cs
// Generated from {CurrentDirectory}union-same-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
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
  : GqlpModelImplementationBase
  , ItestPrntUnionSamePrnt
{
  public String AsString { get; set; }
}
