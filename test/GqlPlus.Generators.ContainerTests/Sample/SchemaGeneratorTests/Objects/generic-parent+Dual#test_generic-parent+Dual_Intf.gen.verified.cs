//HintName: test_generic-parent+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_Dual;

public interface ItestGnrcPrntDual<TType>
  : IGqlpInterfaceBase
{
  TType? As_Parent { get; }
  ItestGnrcPrntDualObject<TType>? As_GnrcPrntDual { get; }
}

public interface ItestGnrcPrntDualObject<TType>
  : IGqlpInterfaceBase
{
}
