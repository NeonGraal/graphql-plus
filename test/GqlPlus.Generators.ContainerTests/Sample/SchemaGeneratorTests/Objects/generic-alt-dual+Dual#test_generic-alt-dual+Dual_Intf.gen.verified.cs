//HintName: test_generic-alt-dual+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Dual;

public interface ItestGnrcAltDualDual
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltDualDual<ItestAltGnrcAltDualDual>? AsRefGnrcAltDualDual { get; }
  ItestGnrcAltDualDualObject? As_GnrcAltDualDual { get; }
}

public interface ItestGnrcAltDualDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltDualDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltDualDualObject<TRef>? As_RefGnrcAltDualDual { get; }
}

public interface ItestRefGnrcAltDualDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcAltDualDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcAltDualDualObject? As_AltGnrcAltDualDual { get; }
}

public interface ItestAltGnrcAltDualDualObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}
