//HintName: test_union-same-parent_Enc.gen.cs
// Generated from {CurrentDirectory}union-same-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
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
  : GqlpEncoderBase
  , ItestPrntUnionSamePrnt
{
  public String AsString { get; set; }
}
