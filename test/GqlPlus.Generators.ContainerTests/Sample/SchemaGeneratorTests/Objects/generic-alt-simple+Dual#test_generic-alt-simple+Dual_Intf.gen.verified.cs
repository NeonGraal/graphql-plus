//HintName: test_generic-alt-simple+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-simple+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Dual;

public interface ItestGnrcAltSmplDual
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltSmplDual<string>? AsRefGnrcAltSmplDual { get; }
  ItestGnrcAltSmplDualObject? As_GnrcAltSmplDual { get; }
}

public interface ItestGnrcAltSmplDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltSmplDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltSmplDualObject<TRef>? As_RefGnrcAltSmplDual { get; }
}

public interface ItestRefGnrcAltSmplDualObject<TRef>
  : IGqlpInterfaceBase
{
}
