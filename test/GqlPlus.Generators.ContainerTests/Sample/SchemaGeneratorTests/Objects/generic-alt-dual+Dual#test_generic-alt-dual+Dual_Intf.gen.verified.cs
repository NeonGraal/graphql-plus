//HintName: test_generic-alt-dual+Dual_Intf.gen.cs
// Generated from generic-alt-dual+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Dual;

public interface ItestGnrcAltDualDual
{
  ItestRefGnrcAltDualDual<ItestAltGnrcAltDualDual> AsRefGnrcAltDualDual { get; }
  ItestGnrcAltDualDualObject AsGnrcAltDualDual { get; }
}

public interface ItestGnrcAltDualDualObject
{
}

public interface ItestRefGnrcAltDualDual<TRef>
{
  TRef Asref { get; }
  ItestRefGnrcAltDualDualObject<TRef> AsRefGnrcAltDualDual { get; }
}

public interface ItestRefGnrcAltDualDualObject<TRef>
{
}

public interface ItestAltGnrcAltDualDual
{
  string AsString { get; }
  ItestAltGnrcAltDualDualObject AsAltGnrcAltDualDual { get; }
}

public interface ItestAltGnrcAltDualDualObject
{
  decimal Alt { get; }
}
