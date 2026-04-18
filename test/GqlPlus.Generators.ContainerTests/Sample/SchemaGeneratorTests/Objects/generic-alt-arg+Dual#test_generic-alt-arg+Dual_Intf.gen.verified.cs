//HintName: test_generic-alt-arg+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Dual;

public interface ItestGnrcAltArgDual<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltArgDual<TType>? AsRefGnrcAltArgDual { get; }
  ItestGnrcAltArgDualObject<TType>? As_GnrcAltArgDual { get; }
}

public interface ItestGnrcAltArgDualObject<TType>
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltArgDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltArgDualObject<TRef>? As_RefGnrcAltArgDual { get; }
}

public interface ItestRefGnrcAltArgDualObject<TRef>
  : IGqlpInterfaceBase
{
}
