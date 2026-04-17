//HintName: test_generic-parent-descr+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_descr_Dual;

public interface ItestGnrcPrntDescrDual<TType>
  : IGqlpInterfaceBase
{
  TType? As_Parent { get; }
  ItestGnrcPrntDescrDualObject<TType>? As_GnrcPrntDescrDual { get; }
}

public interface ItestGnrcPrntDescrDualObject<TType>
  : IGqlpInterfaceBase
{
}
