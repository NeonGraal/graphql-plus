//HintName: test_generic-alt-simple+Dual_Intf.gen.cs
// Generated from generic-alt-simple+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Dual;

public interface ItestGnrcAltSmplDual
{
  public ItestRefGnrcAltSmplDual<ItestString> AsRefGnrcAltSmplDual { get; set; }
  public ItestGnrcAltSmplDualObject AsGnrcAltSmplDual { get; set; }
}

public interface ItestGnrcAltSmplDualObject
{
}

public interface ItestRefGnrcAltSmplDual<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcAltSmplDualObject AsRefGnrcAltSmplDual { get; set; }
}

public interface ItestRefGnrcAltSmplDualObject<Tref>
{
}
