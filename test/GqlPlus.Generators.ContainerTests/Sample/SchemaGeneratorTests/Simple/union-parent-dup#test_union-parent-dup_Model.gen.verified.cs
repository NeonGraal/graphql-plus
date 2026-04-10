//HintName: test_union-parent-dup_Model.gen.cs
// Generated from {CurrentDirectory}union-parent-dup.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_parent_dup;

public class testUnionPrntDup
  : testPrntUnionPrntDup
  , ItestUnionPrntDup
{
  public Number AsNumber { get; set; }
}

public class testPrntUnionPrntDup
  : GqlpModelBase
  , ItestPrntUnionPrntDup
{
  public Number AsNumber { get; set; }
}
