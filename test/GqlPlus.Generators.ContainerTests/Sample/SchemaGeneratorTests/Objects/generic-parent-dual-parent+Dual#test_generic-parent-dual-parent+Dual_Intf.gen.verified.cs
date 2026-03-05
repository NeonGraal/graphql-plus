//HintName: test_generic-parent-dual-parent+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Dual;

public interface ItestGnrcPrntDualPrntDual
  : ItestRefGnrcPrntDualPrntDual<ItestAltGnrcPrntDualPrntDual>
{
  ItestGnrcPrntDualPrntDualObject? As_GnrcPrntDualPrntDual { get; }
}

public interface ItestGnrcPrntDualPrntDualObject
  : ItestRefGnrcPrntDualPrntDualObject<ItestAltGnrcPrntDualPrntDual>
{
}

public interface ItestRefGnrcPrntDualPrntDual<TRef>
  : IGqlpModelImplementationBase
{
  TRef? As_Parent { get; }
  ItestRefGnrcPrntDualPrntDualObject<TRef>? As_RefGnrcPrntDualPrntDual { get; }
}

public interface ItestRefGnrcPrntDualPrntDualObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestAltGnrcPrntDualPrntDual
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestAltGnrcPrntDualPrntDualObject? As_AltGnrcPrntDualPrntDual { get; }
}

public interface ItestAltGnrcPrntDualPrntDualObject
  : IGqlpModelImplementationBase
{
  decimal Alt { get; }
}
