//HintName: test_union-parent_Intf.gen.cs
// Generated from {CurrentDirectory}union-parent.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_parent;

public interface ItestUnionPrnt
  : ItestPrntUnionPrnt
{
}

public interface ItestPrntUnionPrnt
  : IGqlpInterfaceBase
{
  bool HasA<T>();
  T AsA<T>();
}
