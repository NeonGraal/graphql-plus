//HintName: test_union-parent-descr_Intf.gen.cs
// Generated from {CurrentDirectory}union-parent-descr.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_parent_descr;

public interface ItestUnionPrntDescr
  : ItestPrntUnionPrntDescr
{
}

public interface ItestPrntUnionPrntDescr
  : IGqlpInterfaceBase
{
  bool HasA<T>();
  T AsA<T>();
}
