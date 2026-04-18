//HintName: test_generic-field+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-field+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_Dual;

public interface ItestGnrcFieldDual<TType>
  : IGqlpInterfaceBase
{
  ItestGnrcFieldDualObject<TType>? As_GnrcFieldDual { get; }
}

public interface ItestGnrcFieldDualObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}
