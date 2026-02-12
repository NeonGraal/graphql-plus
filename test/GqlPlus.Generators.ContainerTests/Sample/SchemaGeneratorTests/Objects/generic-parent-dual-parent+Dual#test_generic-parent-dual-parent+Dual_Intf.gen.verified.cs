//HintName: test_generic-parent-dual-parent+Dual_Intf.gen.cs
// Generated from generic-parent-dual-parent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Dual;

public interface ItestGnrcPrntDualPrntDual
  : ItestRefGnrcPrntDualPrntDual<ItestAltGnrcPrntDualPrntDual>
{
  ItestGnrcPrntDualPrntDualObject AsGnrcPrntDualPrntDual { get; }
}

public interface ItestGnrcPrntDualPrntDualObject
  : ItestRefGnrcPrntDualPrntDualObject<ItestAltGnrcPrntDualPrntDual>
{
}

public interface ItestRefGnrcPrntDualPrntDual<TRef>
{
  TRef AsParent { get; }
  ItestRefGnrcPrntDualPrntDualObject<TRef> AsRefGnrcPrntDualPrntDual { get; }
}

public interface ItestRefGnrcPrntDualPrntDualObject<TRef>
{
}

public interface ItestAltGnrcPrntDualPrntDual
{
  string AsString { get; }
  ItestAltGnrcPrntDualPrntDualObject AsAltGnrcPrntDualPrntDual { get; }
}

public interface ItestAltGnrcPrntDualPrntDualObject
{
  decimal Alt { get; }
}
