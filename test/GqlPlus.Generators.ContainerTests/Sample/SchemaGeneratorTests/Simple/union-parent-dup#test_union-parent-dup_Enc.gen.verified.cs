//HintName: test_union-parent-dup_Enc.gen.cs
// Generated from {CurrentDirectory}union-parent-dup.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
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
  : GqlpEncoderBase
  , ItestPrntUnionPrntDup
{
  public Number AsNumber { get; set; }
}
