//HintName: test_union-alias_Intf.gen.cs
// Generated from {CurrentDirectory}union-alias.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_alias;

public interface ItestUnionAlias
  : IGqlpInterfaceBase
{
  bool HasA<T>();
  T AsA<T>();
}
