//HintName: test_union-parent_Model.gen.cs
// Generated from {CurrentDirectory}union-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
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
  : GqlpModelImplementationBase
  , ItestPrntUnionPrnt
{
  public Number AsNumber { get; set; }
}
