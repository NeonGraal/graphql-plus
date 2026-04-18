//HintName: test_generic-alt+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_Dual;

public interface ItestGnrcAltDual<TType>
  : IGqlpInterfaceBase
{
  TType? Astype { get; }
  ItestGnrcAltDualObject<TType>? As_GnrcAltDual { get; }
}

public interface ItestGnrcAltDualObject<TType>
  : IGqlpInterfaceBase
{
}
