//HintName: test_generic-parent-dual+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Dual;

public interface ItestGnrcPrntDualDual
  : ItestRefGnrcPrntDualDual<ItestAltGnrcPrntDualDual>
{
  ItestGnrcPrntDualDualObject? As_GnrcPrntDualDual { get; }
}

public interface ItestGnrcPrntDualDualObject
  : ItestRefGnrcPrntDualDualObject<ItestAltGnrcPrntDualDual>
{
}

public interface ItestRefGnrcPrntDualDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcPrntDualDualObject<TRef>? As_RefGnrcPrntDualDual { get; }
}

public interface ItestRefGnrcPrntDualDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcPrntDualDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcPrntDualDualObject? As_AltGnrcPrntDualDual { get; }
}

public interface ItestAltGnrcPrntDualDualObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}
