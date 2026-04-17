//HintName: test_union-same-parent_Intf.gen.cs
// Generated from {CurrentDirectory}union-same-parent.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_same_parent;

public interface ItestUnionSamePrnt
  : ItestPrntUnionSamePrnt
{
}

public interface ItestPrntUnionSamePrnt
  : IGqlpInterfaceBase
{
  bool HasA<T>();
  T AsA<T>();
}
