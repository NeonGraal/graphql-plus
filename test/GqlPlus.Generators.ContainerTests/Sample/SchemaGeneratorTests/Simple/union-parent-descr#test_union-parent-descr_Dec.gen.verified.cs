//HintName: test_union-parent-descr_Dec.gen.cs
// Generated from {CurrentDirectory}union-parent-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_parent_descr;

public interface ItestUnionPrntDescr
  : ItestPrntUnionPrntDescr
{
  Number AsNumber { get; }
}

public interface ItestPrntUnionPrntDescr
  // No Base because it's Class
{
  Number AsNumber { get; }
}
