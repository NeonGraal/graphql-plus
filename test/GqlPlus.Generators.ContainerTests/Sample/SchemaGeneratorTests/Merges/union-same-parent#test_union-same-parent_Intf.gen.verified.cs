//HintName: test_union-same-parent_Intf.gen.cs
// Generated from {CurrentDirectory}union-same-parent.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_same_parent;

public interface ItestUnionSamePrnt
  : ItestPrntUnionSamePrnt
{
  Boolean AsBoolean { get; }
}

public interface ItestPrntUnionSamePrnt
  : IGqlpModelImplementationBase
{
  String AsString { get; }
}
