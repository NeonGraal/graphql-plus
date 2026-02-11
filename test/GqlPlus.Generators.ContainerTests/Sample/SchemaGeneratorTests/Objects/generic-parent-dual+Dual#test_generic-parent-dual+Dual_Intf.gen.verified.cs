//HintName: test_generic-parent-dual+Dual_Intf.gen.cs
// Generated from generic-parent-dual+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Dual;

public interface ItestGnrcPrntDualDual
  : ItestRefGnrcPrntDualDual
{
  ItestGnrcPrntDualDualObject AsGnrcPrntDualDual { get; }
}

public interface ItestGnrcPrntDualDualObject
  : ItestRefGnrcPrntDualDualObject
{
}

public interface ItestRefGnrcPrntDualDual<Tref>
{
  Tref Asref { get; }
  ItestRefGnrcPrntDualDualObject AsRefGnrcPrntDualDual { get; }
}

public interface ItestRefGnrcPrntDualDualObject<Tref>
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
