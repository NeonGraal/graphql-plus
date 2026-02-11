//HintName: test_generic-alt-simple+Dual_Intf.gen.cs
// Generated from generic-alt-simple+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Dual;

public interface ItestGnrcAltSmplDual
{
  ItestRefGnrcAltSmplDual<string> AsRefGnrcAltSmplDual { get; }
  ItestGnrcAltSmplDualObject AsGnrcAltSmplDual { get; }
}

public interface ItestGnrcAltSmplDualObject
{
}

public interface ItestRefGnrcAltSmplDual<TRef>
{
  TRef Asref { get; }
  ItestRefGnrcAltSmplDualObject AsRefGnrcAltSmplDual { get; }
}

public interface ItestRefGnrcAltSmplDualObject<TRef>
{
}
