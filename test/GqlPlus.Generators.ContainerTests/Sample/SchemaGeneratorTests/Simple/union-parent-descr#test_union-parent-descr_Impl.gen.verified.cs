//HintName: test_union-parent-descr_Impl.gen.cs
// Generated from {CurrentDirectory}union-parent-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
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
  : GqlpModelImplementationBase
  , ItestPrntUnionPrntDescr
{
  public Number AsNumber { get; set; }
}
