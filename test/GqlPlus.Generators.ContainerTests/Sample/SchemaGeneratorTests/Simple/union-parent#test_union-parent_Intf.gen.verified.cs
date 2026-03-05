//HintName: test_union-parent_Intf.gen.cs
// Generated from {CurrentDirectory}union-parent.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_parent;

public interface ItestUnionPrnt
  : ItestPrntUnionPrnt
{
  String AsString { get; }
}

public interface ItestPrntUnionPrnt
  : IGqlpModelImplementationBase
{
  Number AsNumber { get; }
}
