//HintName: test_generic-parent-dual+Dual_Intf.gen.cs
// Generated from generic-parent-dual+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Dual;

public interface ItestGnrcPrntDualDual
  : ItestRefGnrcPrntDualDual<ItestAltGnrcPrntDualDual>
{
  ItestGnrcPrntDualDualObject AsGnrcPrntDualDual { get; }
}

public interface ItestGnrcPrntDualDualObject
  : ItestRefGnrcPrntDualDualObject<ItestAltGnrcPrntDualDual>
{
}

public interface ItestRefGnrcPrntDualDual<TRef>
{
  TRef Asref { get; }
  ItestRefGnrcPrntDualDualObject<TRef> AsRefGnrcPrntDualDual { get; }
}

public interface ItestRefGnrcPrntDualDualObject<TRef>
{
}

public interface ItestAltGnrcPrntDualDual
{
  string AsString { get; }
  ItestAltGnrcPrntDualDualObject AsAltGnrcPrntDualDual { get; }
}

public interface ItestAltGnrcPrntDualDualObject
{
  decimal Alt { get; }
}
