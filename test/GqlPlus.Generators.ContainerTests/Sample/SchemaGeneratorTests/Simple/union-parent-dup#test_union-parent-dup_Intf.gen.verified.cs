//HintName: test_union-parent-dup_Intf.gen.cs
// Generated from {CurrentDirectory}union-parent-dup.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_parent_dup;

public interface ItestUnionPrntDup
  : ItestPrntUnionPrntDup
{
  Number AsNumber { get; }
}

public interface ItestPrntUnionPrntDup
  : IGqlpInterfaceBase
{
  Number AsNumber { get; }
}
